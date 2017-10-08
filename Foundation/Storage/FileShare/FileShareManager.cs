using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;
using WabiLogic.Foundation.Encryption;
using WabiLogic.Foundation.Encryption.None;
using System.Security.Cryptography;

namespace WabiLogic.Foundation.Storage.FileShare {
    public class FileShareManager : BasicManager {
        private string fileDirectory;
        private IEncryption encryption;

        private string cacheDatabaseFile;

        private string dataDirectory;
        private string dbCurrentFilename = "storage.bds";
        private string dbBackupFilename = "storage.old";
        private string dbToDeleteFilename = "storage.del";

        public FileShareManager(string fileDirectory) : this(fileDirectory, new NoneEncryption()) { }

        public FileShareManager(string fileDirectory, IEncryption encryption) : base() {
            this.cacheDatabaseFile = null;
            this.fileDirectory = fileDirectory;
            this.encryption = encryption;

            this.dataDirectory = Path.Combine(fileDirectory, "data");
            this.dbCurrentFilename = Path.Combine(fileDirectory, "storage.bds");
            this.dbBackupFilename = Path.Combine(fileDirectory, "storage.old");
            this.dbToDeleteFilename = Path.Combine(fileDirectory, "storage.del");
        }

        public string FileDirectory {
            get { return fileDirectory; }
        }

        public IEncryption Encryption {
            get { return encryption; }
        }

        public override void CacheDatabase(string cacheFile) {
            this.cacheDatabaseFile = cacheFile;
        }

        public override void Open() {
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);

            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            BasicDataSet set = null;

            Action<string> load = delegate(string filename) {
                if (File.Exists(filename)) {
                    try {
                        FileInfo fi = new FileInfo(filename);
                        using (Stream inputStream = new TransferStream(this, encryption.DecryptStream(File.OpenRead(filename)), "File database", fi.Length)) {
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
            if (File.Exists(dbToDeleteFilename))
                File.Delete(dbToDeleteFilename);

            if (File.Exists(dbBackupFilename))
                File.Move(dbBackupFilename, dbToDeleteFilename);

            if (File.Exists(dbCurrentFilename))
                File.Move(dbCurrentFilename, dbBackupFilename);

            MemoryStream ms = new MemoryStream();
            BasicDataSet.Save(ms, this.Set);
            using (Stream outputStream = new TransferStream(this, encryption.EncryptStream(File.OpenWrite(dbCurrentFilename)), "File database", ms.Length)) {
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
            //Do nothing....
        }

        public override BasicFolder GetFolder(BasicDataSet.FolderRow folderRow) {
            return new FileShareFolder(this, folderRow);
        }

        public override BasicFolderInstance GetFolderInstance(BasicDataSet.FolderInstanceRow folderInstanceRow) {
            return new FileShareFolderInstance(this, folderInstanceRow);
        }

        public override BasicFile GetFile(BasicDataSet.FileRow fileRow) {
            return new FileShareFile(this, fileRow);
        }

        public override BasicFileInstance GetFileInstance(BasicDataSet.FileInstanceRow fileInstanceRow) {
            return new FileShareFileInstance(this, fileInstanceRow);
        }

        public override Stream LoadStream(Guid streamId) {
            return encryption.DecryptStream(new FileStream(GetFilename(streamId), FileMode.Open));
        }

        public override Stream SaveStream(Guid streamId) {
            return encryption.EncryptStream(new FileStream(GetFilename(streamId), FileMode.Create));
        }

        public override void DeleteStream(Guid streamId) {
            File.Delete(GetFilename(streamId));
        }

        public override IEnumerable<Guid> LoadStreamIds() {
            string[] files = Directory.GetFiles(this.dataDirectory);

            foreach (string file in files) {
                FileInfo fi = new FileInfo(file);
                yield return new Guid(fi.Name);
            }
        }

        private string GetFilename(Guid streamId) {
            return Path.Combine(this.dataDirectory, streamId.ToString("N"));
        }
    }
}