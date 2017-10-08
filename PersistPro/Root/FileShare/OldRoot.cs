//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using OnlineBackupUtility.Storage;
//using OnlineBackupUtility.Root;

//namespace OnlineBackupUtility.Backup {


//    

//    public class Root {
//        private string path;
//        private string name;
//        private bool sub;
//        //private Schedule schedule;
//        private string note;
//        private List<FileNameFilter> nameFilters;
//        private List<FileAttributeFilter> attributeFilters;

//        //public Root(string path, string name, bool sub, string note) {
//        //    this.path = path;
//        //    this.name = name;
//        //    this.sub = sub;
//            //this.schedule = schedule;
//        //    this.note = note;
            
//        //    this.nameFilters = new List<FileNameFilter>();
//        //    this.attributeFilters = new List<FileAttributeFilter>();
//        //}

//        public Root() {
//            this.nameFilters = new List<FileNameFilter>();
//            this.attributeFilters = new List<FileAttributeFilter>();
//        }

//        public string Path {
//            get { return path; }
//        }

//        public string Name {
//            get { return name; }
//        }

//        public bool Sub {
//            get { return sub; }
//        }

//        //public Schedule Schedule {
//        //    get { return schedule; }
//        //}

//        public string Note {
//            get { return note; }
//        }

//        public IList<FileNameFilter> NameFilters {
//            get { return nameFilters; }
//        }

//        public IList<FileAttributeFilter> AttributeFilters {
//            get { return attributeFilters; }
//        }

//        private FileAttributes IncludeFileAttributes {
//            get {
//                FileAttributes includeFileAttributes = 0;
//                foreach (FileAttributeFilter filter in this.AttributeFilters.Where(x => x.Type == FilterType.Include)) {
//                    includeFileAttributes |= filter.Filter;
//                }
//                return includeFileAttributes;
//            }
//        }

//        private FileAttributes ExcludeFileAttributes {
//            get {
//                FileAttributes excludeFileAttributes = 0;
//                foreach (FileAttributeFilter filter in this.AttributeFilters.Where(x => x.Type == FilterType.Exclude)) {
//                    excludeFileAttributes |= filter.Filter;
//                }
//                return excludeFileAttributes;
//            }
//        }

//        public bool BackupDirectory(DirectoryInfo di) {
//            //for directories only check excluded file types
//            return ((di.Attributes & this.ExcludeFileAttributes) == 0);
//        }

//        public IEnumerable<FileInfo> FilterFiles(DirectoryInfo di) {
//            //Create list of files that are included
//            IEnumerable<FileInfo> includeFiles = new List<FileInfo>();
//            foreach (FileNameFilter filter in this.NameFilters.Where(x => x.Type == FilterType.Include)) {
//                try {
//                    includeFiles = di.GetFiles(filter.Filter).Union(includeFiles);
//                }
//                catch (UnauthorizedAccessException) {
//                    //Ignore - stuff like this happens?
//                    //TODO: Determine if this should be logged
//                }
//            }

//            //Create list of files that are excluded
//            IEnumerable<FileInfo> excludeFiles = new List<FileInfo>();
//            foreach (FileNameFilter filter in this.NameFilters.Where(x => x.Type == FilterType.Exclude)) {
//                try {
//                    excludeFiles = di.GetFiles(filter.Filter).Union(excludeFiles);
//                }
//                catch (UnauthorizedAccessException) {
//                    //Ignore - stuff like this happens?
//                    //TODO: Determine if this should be logged
//                }
//            }

//            //Subtract excludedFiles from includedFiles
//            IEnumerable<FileInfo> filteredFiles = includeFiles.Where(x => !excludeFiles.Any(y => y.Name == x.Name)).Distinct();

//            //Now check file attributes to ensure compliance
//            return filteredFiles.Where(x => (x.Attributes & this.IncludeFileAttributes) > 0 && (x.Attributes & this.ExcludeFileAttributes) == 0);
//        }

//        #region Backup Section

//        public void Backup(IManager manager) {
//            DirectoryInfo rootDir = new DirectoryInfo(this.Path);
//            //Check if the backupRootFolder needs to be deleted...
//            if (!rootDir.Exists) {
//                IFolder backupRootFolder = FindSubFolder(manager.GetRootFolder(), this.Name);
//                if (backupRootFolder != null) {
//                    backupRootFolder.Delete(true);
//                }
//            }

//            if (this.BackupDirectory(rootDir)) {
//                IFolder backupRootFolder = FindOrCreateSubFolder(manager.GetRootFolder(), this.Name);
//                CompareFolder(this, rootDir, backupRootFolder);
//            }
//        }

//        private IFolder FindSubFolder(IFolder parent, string subFolderName) {
//            IFolder toReturn = null;

//            IList<IFolderInstance> folderInstances = parent.GetSubFolderInstances(DateTime.Now);
//            IFolderInstance folderInstance = folderInstances.Where(x => x.Name == subFolderName).DefaultIfEmpty(null).SingleOrDefault();
//            if (folderInstance != null)
//                toReturn = folderInstance.Folder;

//            return toReturn;
//        }

//        private IFolder FindOrCreateSubFolder(IFolder parent, string subFolderName) {
//            IFolder toReturn = FindSubFolder(parent, subFolderName);
//            if (toReturn == null)
//                toReturn = parent.CreateSubFolder(subFolderName);

//            return toReturn;
//        }

//        private void CompareFolder(Root root, DirectoryInfo di, IFolder folder) {
//            CompareFolderContents(root, di, folder);

//            if (root.Sub) {
//                try {
//                    DirectoryInfo[] directories = di.GetDirectories();
//                    foreach (DirectoryInfo subDi in directories) {
//                        if (root.BackupDirectory(subDi)) {
//                            IFolder subFolder = FindOrCreateSubFolder(folder, subDi.Name);
//                            CompareFolder(root, subDi, subFolder);
//                        }
//                    }

//                    //Check if any folder need to be deleted because the directory is deleted
//                    foreach (IFolder folderToDelete in folder.GetSubFolderInstances(DateTime.Now).Where(x => !directories.Any(y => x.Name == y.Name)).Select<IFolderInstance, IFolder>(x => x.Folder)) {
//                        folderToDelete.Delete();
//                    }
//                }
//                catch (UnauthorizedAccessException) {
//                    //Ignore - stuff like this happens?
//                    //TODO: Determine if this should be logged
//                }
//            }
//        }

//        private void CompareFolderContents(Root root, DirectoryInfo di, IFolder folder) {
//            IEnumerable<FileInfo> files = root.FilterFiles(di);
//            IList<IFileInstance> fiFiles = folder.GetFileInstances(DateTime.Now);

//            //find new files that need to be loaded
//            foreach (FileInfo fi in files.Where(x => !fiFiles.Any(y => y.Name == x.Name))) {
//                string md5 = OnlineBackupUtility.Tools.IO.GenerateMD5(fi.FullName);
//                using (Stream inputStream = File.OpenRead(fi.FullName)) {
//                    folder.CreateFile(inputStream, fi.Name, fi.Length, md5, "");
//                }
//            }

//            //find old files to be deleted
//            foreach (IFileInstance fi in fiFiles.Where(x => !files.Any(y => y.Name == x.Name))) {
//                fi.File.Delete();
//            }

//            //Check if existing files need to be updated
//            foreach (FileInfo fi in files.Where(x => fiFiles.Any(y => y.Name == x.Name))) {
//                string md5 = OnlineBackupUtility.Tools.IO.GenerateMD5(fi.FullName);
//                IFileInstance fileInstance = fiFiles.Where(y => y.Name == fi.Name).Single();
//                if (fileInstance.MD5 != md5 || fileInstance.Size != fi.Length) {
//                    using (Stream inputStream = File.OpenRead(fi.FullName)) {
//                        fileInstance.File.UpdateFile(inputStream, fi.Length, md5, "");
//                    }
//                }
//            }
//        }

//        #endregion
//    }
//}
