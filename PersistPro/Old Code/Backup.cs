using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OnlineBackupUtility.Config;

namespace OnlineBackupUtility {
    class Backup {
        private BackupDatabase backupDatabase;
        private ConfigManager configManager;
        //private IEncryption encryption;
        private IStorage storage;

        public Backup() {
            this.configManager = ConfigManager.Create();

            //this.encryption = configManager.GetEncryption();
            this.storage = configManager.GetStorage();
            this.backupDatabase = this.storage.LoadDatabase();
        }

        public BackupDatabase BackupDatabase {
            get { return this.backupDatabase; }
        }

        public void Restore() {
            foreach (BackupDatabase.FilesRow file in backupDatabase.Files.Rows) {
                string outputFile = storage.CreateFullName(BackupDatabase.Roots.FindName(file.Root), file.FileId);

                FileInfo fi = new FileInfo(outputFile);
                if (!Directory.Exists(fi.DirectoryName))
                    Directory.CreateDirectory(fi.DirectoryName);

                //using (Stream inputStream = storage.Retrieve(file.FileId))
                //using (Stream outputStream = File.OpenWrite(outputFile)) {
                //    this.encryption.Decrypt(inputStream, outputStream);
                //}
            }
        }

        public void Save() {
            foreach (BackupDatabase.RootsRow root in backupDatabase.Roots.Rows) {
                BackupDirectory(root, root.Path);
            }

            this.storage.SaveDatabase(this.backupDatabase);
        }

        private void BackupDirectory(BackupDatabase.RootsRow root, string path) {
            //Update and Add files
            foreach (string file in Directory.GetFiles(path)) {
                FileInfo fi = new FileInfo(file);
                string fileId = storage.CreateFileId(root, fi.FullName);

                //Get file size and hash
                long size = fi.Length;
                string hash = ""; //GenerateHash(file);

                //Check if stats have changed from database
                BackupDatabase.FilesRow fileRow = FindOrCreatePath(root.Name, fileId);

                if (!fileRow.IsFileMatch(hash, size)) {
                    //Backup file
                    //root.Name  fi.FullName.Replace(root.Path, "")

                    //using (Stream inputStream = fi.OpenRead())
                    //using (Stream outputStream = storage.Store(fileId)) {
                    //    if (root.Encrypt)
                    //        encryption.Encrypt(inputStream, outputStream);
                    //    else
                    //        OnlineBackupUtility.Tools.IO.WriteStream(inputStream, outputStream);
                    //}

                    //Update Record set
                    
                    fileRow.Size = size;
                    fileRow.Hash = hash;
                }
                else {
                    fileRow.Updated = DateTime.Now;
                }
            }

            //Search for deletes

            //Backup Sub Directories
            foreach (string subDirectory in Directory.GetDirectories(path)) {
                BackupDirectory(root, subDirectory);
            }
        }

        //private string GenerateHash(string file) {
        //    using (Stream inputStream = File.OpenRead(file)) {
        //        return encryption.GenerateHash(inputStream);
        //    }
        //}

        private BackupDatabase.FilesRow FindOrCreatePath(string root, string fileId) {
            BackupDatabase.FilesRow row = this.backupDatabase.Files.FindFileId(fileId);
            if (row == null) {
                row = this.backupDatabase.Files.AddFilesRow(root, fileId, "", 0, DateTime.Now, DateTime.Now, DateTime.MaxValue);
            }

            return row;
        }

    }
}
