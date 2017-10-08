using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OnlineBackupUtility;
using OnlineBackupUtility.Config;

namespace OnlineBackupUtility.Storage {
    public class FileStorage : IStorage {
        private string backupDirectory;
        string backupDatabaseFile;

        public FileStorage(string backupDirectory) {
            this.backupDirectory = backupDirectory;
            backupDatabaseFile = StoragePath.Combine(backupDirectory, "BackupDatabase.bdb");
        }

        #region IStorage Members

        public String CreateFileId(BackupDatabase.RootsRow root, string fileFullName) {
            string endPath = fileFullName.Replace(root.Path, "");
            if (endPath[0] == StoragePath.DirectorySeparatorChar) endPath = endPath.Substring(1);
            return root.Name + StoragePath.DirectorySeparatorChar + endPath;
        }

        public string CreateFullName(BackupDatabase.RootsRow root, string fileId) {
            //The plus 1 is to catch the directory seperator
            return StoragePath.Combine(root.Path, fileId.Substring(root.Name.Length + 1));
        }

        public Stream Store(string fileId) {
            string backupFile = StoragePath.Combine(backupDirectory, fileId);

            FileInfo fi = new FileInfo(backupFile);
            if (!Directory.Exists(fi.DirectoryName))
                Directory.CreateDirectory(fi.DirectoryName);

            return File.OpenWrite(backupFile);
        }

        public Stream Retrieve(string fileId) {
            string backupFile = StoragePath.Combine(backupDirectory, fileId);
            return File.OpenRead(backupFile);
        }

        public BackupDatabase LoadDatabase() {
            BackupDatabase toReturn = null;
            
            if (File.Exists(backupDatabaseFile)) {
                using (Stream stream = File.OpenRead(backupDatabaseFile)) {
                    toReturn = BackupDatabase.Load(stream);
                }
            }
            else {
                toReturn = new BackupDatabase();
            }

            return toReturn;
        }

        public void SaveDatabase(BackupDatabase backupDatabase) {
            FileInfo fi = new FileInfo(backupDatabaseFile);
            if (!Directory.Exists(fi.DirectoryName))
                Directory.CreateDirectory(fi.DirectoryName);

            using (Stream stream = File.OpenWrite(backupDatabaseFile)) {
                BackupDatabase.Save(backupDatabase, stream);
            }
        }

        #endregion
    }
}
