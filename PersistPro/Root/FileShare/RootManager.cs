using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBackupUtility.Storage;
using OnlineBackupUtility.Mount;
using System.IO;

namespace OnlineBackupUtility.Root.FileShare {
    public class RootManager : OnlineBackupUtility.Root.IRootManager {
        public RootDataSet RootDataSet { get; private set; }
        private string backupFilename = "backup.xml";

        public RootManager(IManager manager, IMount mount) {
            this.StorageManager = manager;
            this.Mount = mount;
            Load();
        }

        #region IRootLoader Members

        public IManager StorageManager { get; private set; }
        public IMount Mount { get; private set; }

        public ISchedule Schedule {
            get {
                return new Schedule(this.RootDataSet.Schedule.First(), this);
            }
        }

        public IEnumerable<IRoot> Roots {
            get {
                foreach (RootDataSet.RootRow rootRow in this.RootDataSet.Root) {
                    yield return new Root(rootRow, this);
                }            
            } 
        }

        public void RemoveRoot(IRoot root) {
            this.RootDataSet.Root.RemoveRootRow(((Root)root).RootRow);
        }

        public IRoot CreateRoot(string name, string path, bool sub, string note) {
            RootDataSet.RootRow rootRow = this.RootDataSet.Root.AddRootRow(name, path, sub, note);
            return new Root(rootRow, this);
        }

        public void Backup() {
            foreach (IRoot root in this.Roots) {
                root.Backup();
            }
        }

        public void Save() {
            MemoryStream ms = new MemoryStream();
            RootDataSet.Save(ms, this.RootDataSet);

            IList<IFileInstance> fileInstances = this.StorageManager.GetRootFolder().GetFileInstances(DateTime.Now);
            IFileInstance fileInstance = fileInstances.Where(x => x.Name == backupFilename).DefaultIfEmpty(null).SingleOrDefault();

            ms.Position = 0L; //Reset after writing complete
            long size = ms.Length;
            string md5 = OnlineBackupUtility.Tools.IO.GenerateMD5(ms);
            ms.Position = 0L; //Reset because md5 ran it to the end
            string note = "";

            byte[] xmlBuffer = ms.GetBuffer();
            if (fileInstance != null) {
                fileInstance.File.UpdateFile(ms, size, md5, note);
            }
            else {
                this.StorageManager.GetRootFolder().CreateFile(ms, backupFilename, size, md5, note);
            }

            //Let us keep a local copy for quick loading....
            string localFile = this.Mount.GetLocalCachePath(string.Format("{0}_roots.xml", this.Mount.Id));
            string tempFile = this.Mount.GetLocalCachePath(string.Format("{0}_roots.xmltmp", this.Mount.Id));

            if (File.Exists(tempFile))
                File.Delete(tempFile);

            File.WriteAllBytes(tempFile, xmlBuffer);

            //This would be nice if the OS supported atomic file transactions....
            //But if the system fails between the delete and the move the system will
            //still recover by reading from the backup
            if (File.Exists(localFile))
                File.Delete(localFile);

            File.Move(tempFile, localFile);
        }

        private void Load() {
            Func<Stream> loadStream = delegate() {
                Stream toReturn = null;
                string localFile = this.Mount.GetLocalCachePath(string.Format("{0}_roots.xml", this.Mount.Id));
                if (File.Exists(localFile)) {
                    toReturn = File.OpenRead(localFile);
                }
                else {
                    IList<IFileInstance> fileInstances = this.StorageManager.GetRootFolder().GetFileInstances(DateTime.Now);
                    IFileInstance fileInstance = fileInstances.Where(x => x.Name == backupFilename).DefaultIfEmpty(null).SingleOrDefault();
                    if (fileInstance != null) {
                        toReturn = fileInstance.CreateStream();
                    }
                }

                return toReturn;
            };

            IList<Root> roots = new List<Root>();
            Stream toLoad = loadStream();
            if (toLoad != null) {
                this.RootDataSet = RootDataSet.Load(toLoad);
            }
            else {
                this.RootDataSet = new RootDataSet();
            }
        }

        #endregion
    }
}
