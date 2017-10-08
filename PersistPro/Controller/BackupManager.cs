using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Model;

namespace WabiLogic.PersistPro.Controller {
    public class BackupManager {

        public BackupManager(IPlan plan, IManager storageManager) {
            this.Plan = plan;
            this.StorageManager = storageManager;
        }

        public IPlan Plan { get; private set; }
        public IManager StorageManager { get; private set; }

        public void Backup() {
            try {
                this.StorageManager.Open();
                DirectoryInfo rootDir = new DirectoryInfo(this.Plan.Root.Folder);
                //Check if the backupRootFolder needs to be deleted...
                if (!rootDir.Exists) {
                    IFolder backupRootFolder = FindSubFolder(this.StorageManager.GetRootFolder(), BackupManager.RootFolderName(this.Plan.Root));
                    if (backupRootFolder != null) {
                        backupRootFolder.Delete(true);
                    }
                }

                if (this.BackupDirectory(rootDir)) {
                    IFolder backupRootFolder = FindOrCreateSubFolder(this.StorageManager.GetRootFolder(), BackupManager.RootFolderName(this.Plan.Root));
                    CompareFolder(rootDir, backupRootFolder);
                }

                if (!this.Plan.Root.KeepHistory) {
                    this.StorageManager.Recycle(new RootTimeSpanPurgeRules(this.Plan.Root, TimeSpan.MinValue));
                }

                this.StorageManager.Save();
            }
            finally {
                this.StorageManager.Close();
            }
        }

        public static string RootFolderName(IRoot root) {
            return string.Format("{0}_{1}", root.Name, root.Id.ToString("N"));
            //return string.Format("{0}_{1}", this.Plan.Root.Name, this.Plan.Root.Id.ToString("N"));            
        }

        private IFolder FindSubFolder(IFolder parent, string subFolderName) {
            IFolder toReturn = null;

            IEnumerable<IFolderInstance> folderInstances = parent.GetSubFolderInstances(DateTime.Now);
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

        private void CompareFolder(DirectoryInfo di, IFolder folder) {
            CompareFolderFiles(di, folder);

            if (this.Plan.Root.Sub)
                CompareFolderDirectories(di, folder);
        }

        private void CompareFolderFiles(DirectoryInfo di, IFolder folder) {
            IEnumerable<FileInfo> files = FilterFiles(di);
            IEnumerable<IFileInstance> fiFiles = folder.GetFileInstances(DateTime.Now);

            //find new files that need to be loaded
            foreach (FileInfo fi in files.Where(x => !fiFiles.Any(y => y.Name == x.Name))) {
                string md5 = WabiLogic.Foundation.Tools.IO.GenerateMD5(fi.FullName);
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
                string md5 = WabiLogic.Foundation.Tools.IO.GenerateMD5(fi.FullName);
                IFileInstance fileInstance = fiFiles.Where(y => y.Name == fi.Name).Single();
                if (fileInstance.MD5 != md5 || fileInstance.Size != fi.Length) {
                    using (Stream inputStream = File.OpenRead(fi.FullName)) {
                        fileInstance.File.UpdateFile(inputStream, fi.Length, md5, "");
                    }
                }
            }
        }

        private void CompareFolderDirectories(DirectoryInfo di, IFolder folder) {
            try {
                TryToCompareFolderDirectories(di, folder);
            }
            catch (UnauthorizedAccessException) {
                //Ignore - stuff like this happens?
                //TODO: Determine if this should be logged
            }
        }

        private void TryToCompareFolderDirectories(DirectoryInfo di, IFolder folder) {
            DirectoryInfo[] directories = di.GetDirectories();
            foreach (DirectoryInfo subDi in directories) {
                if (BackupDirectory(subDi)) {
                    IFolder subFolder = FindOrCreateSubFolder(folder, subDi.Name);
                    CompareFolder(subDi, subFolder);
                }
            }

            //Check if any folder need to be deleted because the directory is deleted
            foreach (IFolder folderToDelete in folder.GetSubFolderInstances(DateTime.Now).Where(x => !directories.Any(y => x.Name == y.Name)).Select<IFolderInstance, IFolder>(x => x.Folder)) {
                folderToDelete.Delete(true);
            }
        }

        private bool BackupDirectory(DirectoryInfo di) {
            //for directories only check excluded file types
            return ((di.Attributes & this.ExcludeFileAttributes) == 0);
        }

        private IEnumerable<FileInfo> FilterFiles(DirectoryInfo di) {
            //Create list of files that are included
            IEnumerable<FileInfo> includeFiles = new List<FileInfo>();
            foreach (IRootNameFilter filter in this.Plan.Root.NameFilters.Where(x => x.FilterType == FilterType.Include)) {
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
            foreach (IRootNameFilter filter in this.Plan.Root.NameFilters.Where(x => x.FilterType == FilterType.Exclude)) {
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
                foreach (IRootAttributeFilter filter in this.Plan.Root.AttributeFilters.Where(x => x.FilterType == FilterType.Include)) {
                    includeFileAttributes |= filter.Filter;
                }
                return includeFileAttributes;
            }
        }

        private FileAttributes ExcludeFileAttributes {
            get {
                FileAttributes excludeFileAttributes = 0;
                foreach (IRootAttributeFilter filter in this.Plan.Root.AttributeFilters.Where(x => x.FilterType == FilterType.Exclude)) {
                    excludeFileAttributes |= filter.Filter;
                }
                return excludeFileAttributes;
            }
        }
    }
}
