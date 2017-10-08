using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OnlineBackupUtility.Storage;

namespace OnlineBackupUtility.Root.FileShare {
    public class Root : OnlineBackupUtility.Root.IRoot {
        public RootDataSet.RootRow RootRow { get; private set; }
        public RootManager Manager { get; private set; }

        public int Id {
            get { return this.RootRow.RootId; }
        }

        public string Name {
            get { return this.RootRow.Name; }
            set { this.RootRow.Name = value; } 
        }

        public string Path {
            get { return this.RootRow.Path; }
            set { this.RootRow.Path = value; } 
        }

        public bool Sub {
            get { return this.RootRow.Sub; }
            set { this.RootRow.Sub = value; } 
        }

        public string Note {
            get { return this.RootRow.Note; }
            set { this.RootRow.Note = value; } 
        }

        public Root(RootDataSet.RootRow rootRow, RootManager manager) {
            this.RootRow = rootRow;
            this.Manager = manager;
        }

        #region IRoot Members

        public INameFilter CreateNameFilter(string filter, FilterType filterType, string note) {
            RootDataSet.NameFilterRow nameFilterRow = this.Manager.RootDataSet.NameFilter.AddNameFilterRow(this.RootRow, filter, filterType, note);
            return new NameFilter(nameFilterRow, this);
        }

        public void RemoveNameFilter(INameFilter nameFilter) {
            this.Manager.RootDataSet.NameFilter.RemoveNameFilterRow(((NameFilter)nameFilter).NameFilterRow);
        }

        public IEnumerable<INameFilter> NameFilters {
            get {
                foreach (RootDataSet.NameFilterRow nameFilterRow in this.Manager.RootDataSet.NameFilter.Where(x => x.RootId == this.RootRow.RootId)) {
                    yield return new NameFilter(nameFilterRow, this);
                }
            }
        }

        public IAttributeFilter CreateAttributeFilter(System.IO.FileAttributes filter, FilterType filterType, string note) {
            RootDataSet.AttributeFilterRow attributeFilterRow = this.Manager.RootDataSet.AttributeFilter.AddAttributeFilterRow(this.RootRow, filter, filterType, note);
            return new AttributeFilter(attributeFilterRow, this);
        }

        public void RemoveAttributeFilter(IAttributeFilter attributeFilter) {
            this.Manager.RootDataSet.AttributeFilter.RemoveAttributeFilterRow(((AttributeFilter)attributeFilter).AttributeFilterRow);
        }

        public IEnumerable<IAttributeFilter> AttributeFilters {
            get {
                foreach (RootDataSet.AttributeFilterRow attributeFilterRow in this.Manager.RootDataSet.AttributeFilter.Where(x => x.RootId == this.RootRow.RootId)) {
                    yield return new AttributeFilter(attributeFilterRow, this);
                }
            }
        }

        public void Backup() {
            DirectoryInfo rootDir = new DirectoryInfo(this.Path);
            //Check if the backupRootFolder needs to be deleted...
            if (!rootDir.Exists) {
                IFolder backupRootFolder = FindSubFolder(this.Manager.StorageManager.GetRootFolder(), this.Name);
                if (backupRootFolder != null) {
                    backupRootFolder.Delete(true);
                }
            }

            if (this.BackupDirectory(rootDir)) {
                IFolder backupRootFolder = FindOrCreateSubFolder(this.Manager.StorageManager.GetRootFolder(), this.Name);
                CompareFolder(this, rootDir, backupRootFolder);
            }
        }

        #endregion

        private IFolder FindSubFolder(IFolder parent, string subFolderName) {
            IFolder toReturn = null;

            IList<IFolderInstance> folderInstances = parent.GetSubFolderInstances(DateTime.Now);
            IFolderInstance folderInstance = folderInstances.Where(x => x.Name == subFolderName).DefaultIfEmpty(null).SingleOrDefault();
            if (folderInstance != null)
                toReturn = folderInstance.Folder;

            return toReturn;
        }

        private IFolder FindOrCreateSubFolder(IFolder parent, string subFolderName) {
            IFolder toReturn = FindSubFolder(parent, subFolderName);
            if (toReturn == null)
                toReturn = parent.CreateSubFolder(subFolderName);

            return toReturn;
        }

        private void CompareFolder(Root root, DirectoryInfo di, IFolder folder) {
            CompareFolderFiles(root, di, folder);

            if (root.Sub)
                CompareFolderDirectories(root, di, folder);
        }

        private void CompareFolderFiles(Root root, DirectoryInfo di, IFolder folder) {
            IEnumerable<FileInfo> files = root.FilterFiles(di);
            IList<IFileInstance> fiFiles = folder.GetFileInstances(DateTime.Now);

            //find new files that need to be loaded
            foreach (FileInfo fi in files.Where(x => !fiFiles.Any(y => y.Name == x.Name))) {
                string md5 = OnlineBackupUtility.Tools.IO.GenerateMD5(fi.FullName);
                using (Stream inputStream = File.OpenRead(fi.FullName)) {
                    folder.CreateFile(inputStream, fi.Name, fi.Length, md5, "");
                }
            }

            //find old files to be deleted
            foreach (IFileInstance fi in fiFiles.Where(x => !files.Any(y => y.Name == x.Name))) {
                fi.File.Delete();
            }

            //Check if existing files need to be updated
            foreach (FileInfo fi in files.Where(x => fiFiles.Any(y => y.Name == x.Name))) {
                string md5 = OnlineBackupUtility.Tools.IO.GenerateMD5(fi.FullName);
                IFileInstance fileInstance = fiFiles.Where(y => y.Name == fi.Name).Single();
                if (fileInstance.MD5 != md5 || fileInstance.Size != fi.Length) {
                    using (Stream inputStream = File.OpenRead(fi.FullName)) {
                        fileInstance.File.UpdateFile(inputStream, fi.Length, md5, "");
                    }
                }
            }
        }

        private void CompareFolderDirectories(Root root, DirectoryInfo di, IFolder folder) {
            try {
                TryToCompareFolderDirectories(root, di, folder);
            }
            catch (UnauthorizedAccessException) {
                //Ignore - stuff like this happens?
                //TODO: Determine if this should be logged
            }
        }

        private void TryToCompareFolderDirectories(Root root, DirectoryInfo di, IFolder folder) {
            DirectoryInfo[] directories = di.GetDirectories();
            foreach (DirectoryInfo subDi in directories) {
                if (root.BackupDirectory(subDi)) {
                    IFolder subFolder = FindOrCreateSubFolder(folder, subDi.Name);
                    CompareFolder(root, subDi, subFolder);
                }
            }

            //Check if any folder need to be deleted because the directory is deleted
            foreach (IFolder folderToDelete in folder.GetSubFolderInstances(DateTime.Now).Where(x => !directories.Any(y => x.Name == y.Name)).Select<IFolderInstance, IFolder>(x => x.Folder)) {
                folderToDelete.Delete();
            }
        }

        private bool BackupDirectory(DirectoryInfo di) {
            //for directories only check excluded file types
            return ((di.Attributes & this.ExcludeFileAttributes) == 0);
        }

        private IEnumerable<FileInfo> FilterFiles(DirectoryInfo di) {
            //Create list of files that are included
            IEnumerable<FileInfo> includeFiles = new List<FileInfo>();
            foreach (INameFilter filter in this.NameFilters.Where(x => x.FilterType == FilterType.Include)) {
                try {
                    includeFiles = di.GetFiles(filter.Filter).Union(includeFiles);
                }
                catch (UnauthorizedAccessException) {
                    //Ignore - stuff like this happens?
                    //TODO: Determine if this should be logged
                }
            }

            //Create list of files that are excluded
            IEnumerable<FileInfo> excludeFiles = new List<FileInfo>();
            foreach (INameFilter filter in this.NameFilters.Where(x => x.FilterType == FilterType.Exclude)) {
                try {
                    excludeFiles = di.GetFiles(filter.Filter).Union(excludeFiles);
                }
                catch (UnauthorizedAccessException) {
                    //Ignore - stuff like this happens?
                    //TODO: Determine if this should be logged
                }
            }

            //Subtract excludedFiles from includedFiles
            IEnumerable<FileInfo> filteredFiles = includeFiles.Where(x => !excludeFiles.Any(y => y.Name == x.Name)).Distinct();

            //Now check file attributes to ensure compliance
            return filteredFiles.Where(x => (x.Attributes & this.IncludeFileAttributes) > 0 && (x.Attributes & this.ExcludeFileAttributes) == 0);
        }

        private FileAttributes IncludeFileAttributes {
            get {
                FileAttributes includeFileAttributes = 0;
                foreach (IAttributeFilter filter in this.AttributeFilters.Where(x => x.FilterType == FilterType.Include)) {
                    includeFileAttributes |= filter.Filter;
                }
                return includeFileAttributes;
            }
        }

        private FileAttributes ExcludeFileAttributes {
            get {
                FileAttributes excludeFileAttributes = 0;
                foreach (IAttributeFilter filter in this.AttributeFilters.Where(x => x.FilterType == FilterType.Exclude)) {
                    excludeFileAttributes |= filter.Filter;
                }
                return excludeFileAttributes;
            }
        }
    }
}
