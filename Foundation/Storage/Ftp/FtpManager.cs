using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;
using WabiLogic.Foundation.Encryption;
using WabiLogic.Foundation.Encryption.None;
using Tools = WabiLogic.Foundation.Tools;
using System.Security.Cryptography;
using System.Net;

namespace WabiLogic.Foundation.Storage.Ftp {
    public class FtpManager : BasicManager {
        private ICredentials Credentials { get; set; }
        private Uri BackupUri { get; set; }
        private Uri DataUri { get; set; }

        private IEncryption Encryption { get; set; }

        private string cacheDatabaseFile;

        private string dbCurrentFilename = "storage.bds";
        private string dbBackupFilename = "storage.old";
        private string dbToDeleteFilename = "storage.del";

        public FtpManager(string host, int port, string username, string password, string ftpDirectory, IEncryption encryption)
            : base() {
            this.cacheDatabaseFile = null;

            this.Credentials = new NetworkCredential(username, password);
            this.BackupUri = Tools.Ftp.BuildUri(host, port, ftpDirectory);
            this.DataUri = Tools.Ftp.Combine(this.BackupUri, "data");

            this.Encryption = encryption;
        }

        public override void CacheDatabase(string cacheFile) {
            this.cacheDatabaseFile = cacheFile;
        }

        public override void Open() {
            try {
                Tools.Ftp.CreateDirectory(this.BackupUri, this.Credentials);
            }
            catch { }

            try {
                Tools.Ftp.CreateDirectory(this.DataUri, this.Credentials);
            }
            catch { }

            BasicDataSet set = null;

            Action<string> load = delegate(string filename) {
                Uri file = Tools.Ftp.Combine(this.BackupUri, filename);

                try {
                    long size = 100000;
                    try
                    {
                        size = Tools.Ftp.FileSize(file, this.Credentials);
                    }
                    catch { /* Ignore */ }
                    using (Stream inputStream = new TransferStream(this, this.Encryption.DecryptStream(Tools.Ftp.RetrieveFile(file, this.Credentials)), "File database", size)) {
                        set = BasicDataSet.Load(inputStream);
                    }
                }
                catch (CryptographicException) {
                    throw;
                }
                catch (UnknownVersionException) {
                    throw;
                }
                catch (Exception) {
                    set = null;
                }
            };

            //Check for cache version
            if (!string.IsNullOrEmpty(cacheDatabaseFile) && File.Exists(cacheDatabaseFile)) {
                FileInfo fi = new FileInfo(cacheDatabaseFile);
                using (Stream inputStream = new TransferStream(this, File.OpenRead(fi.FullName), "File database", fi.Length)) {
                    set = BasicDataSet.Load(inputStream);
                }
            }
            else { //load from backup
                load(dbCurrentFilename);
                if (set == null)
                    load(dbBackupFilename);
                if (set == null)
                    load(dbToDeleteFilename);
                if (set == null)
                    set = BasicDataSet.Create();
            }

            Init(set);
        }

        public override void Save() {
            try {
                Tools.Ftp.DeleteFile(Tools.Ftp.Combine(this.BackupUri, dbToDeleteFilename), this.Credentials);
            }
            catch (WebException) { }
            
            try {
                Tools.Ftp.Rename(Tools.Ftp.Combine(this.BackupUri, dbBackupFilename), this.Credentials, dbToDeleteFilename);
            }
            catch (WebException) { }
            
            try {
                Tools.Ftp.Rename(Tools.Ftp.Combine(this.BackupUri, dbCurrentFilename), this.Credentials, dbBackupFilename);
            }
            catch (WebException) { }

            MemoryStream ms = new MemoryStream();
            BasicDataSet.Save(ms, this.Set);
            using (Stream outputStream = new TransferStream(this, this.Encryption.EncryptStream(Tools.Ftp.UploadFile(Tools.Ftp.Combine(this.BackupUri, dbCurrentFilename), this.Credentials)), "File database", ms.Length)) {
                ms.Position = 0L;
                ms.WriteTo(outputStream);
            }

            //Check for cache version
            if (!string.IsNullOrEmpty(cacheDatabaseFile)) {
                using (Stream outputStream = File.OpenWrite(cacheDatabaseFile)) {
                    ms.Position = 0L;
                    ms.WriteTo(outputStream);
                }
            }
        }

        public override void Close() {
        }

        public override BasicFolder GetFolder(BasicDataSet.FolderRow folderRow) {
            return new FtpFolder(this, folderRow);
        }

        public override BasicFolderInstance GetFolderInstance(BasicDataSet.FolderInstanceRow folderInstanceRow) {
            return new FtpFolderInstance(this, folderInstanceRow);
        }

        public override BasicFile GetFile(BasicDataSet.FileRow fileRow) {
            return new FtpFile(this, fileRow);
        }

        public override BasicFileInstance GetFileInstance(BasicDataSet.FileInstanceRow fileInstanceRow) {
            return new FtpFileInstance(this, fileInstanceRow);
        }

        public override Stream LoadStream(Guid streamId) {
            Uri file = Tools.Ftp.Combine(this.DataUri, GetFilename(streamId));
            return this.Encryption.DecryptStream(Tools.Ftp.RetrieveFile(file, this.Credentials));
        }

        public override Stream SaveStream(Guid streamId) {
            Uri file = Tools.Ftp.Combine(this.DataUri, GetFilename(streamId));
            return this.Encryption.EncryptStream(Tools.Ftp.UploadFile(file, this.Credentials));
        }

        public override void DeleteStream(Guid streamId) {
            Uri file = Tools.Ftp.Combine(this.DataUri, GetFilename(streamId));
            Tools.Ftp.DeleteFile(file, this.Credentials);
        }

        public override IEnumerable<Guid> LoadStreamIds() {
            string[] files = Tools.Ftp.DirectoryList(this.DataUri, this.Credentials);

            foreach (string file in files) {
                Guid g = Guid.Empty;
                try {
                    g = new Guid(file);
                }
                catch { }

                if (Guid.Empty != g)
                    yield return g;
            }
        }

        private string GetFilename(Guid streamId) {
            return streamId.ToString("N");
        }
    }
}