using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public abstract class BasicManager : IManager {
        public static Guid RootId = new Guid("C7273CC3-F280-45d4-B8FA-DBDB2F952F8B");

        private BasicDataSet set;

        public BasicManager() {
        }

        public abstract BasicFolder GetFolder(BasicDataSet.FolderRow folderRow);
        public abstract BasicFolderInstance GetFolderInstance(BasicDataSet.FolderInstanceRow folderInstanceRow);
        public abstract BasicFile GetFile(BasicDataSet.FileRow fileRow);
        public abstract BasicFileInstance GetFileInstance(BasicDataSet.FileInstanceRow fileInstanceRow);
        public abstract Stream LoadStream(Guid streamId);
        public abstract Stream SaveStream(Guid streamId);
        public abstract void DeleteStream(Guid streamId);
        public abstract IEnumerable<Guid> LoadStreamIds();

        public void LoadStream(Stream outputStream, Guid streamId) {
            using (Stream inputStream = LoadStream(streamId)) {
                WabiLogic.Foundation.Tools.IO.WriteStream(inputStream, outputStream);
            }
        }
        
        public void SaveStream(Stream inputStream, Guid streamId) {
            using (Stream outputStream = SaveStream(streamId)) {
                WabiLogic.Foundation.Tools.IO.WriteStream(inputStream, outputStream);
            }
        }

        public Guid FindStreamId(string md5, long size) {
            return (from fi in this.Set.FileInstance
                    where fi.MD5 == md5 && fi.Size == size
                    select fi.StreamId).DefaultIfEmpty(Guid.Empty).Distinct().SingleOrDefault();
        }

        public void Init(BasicDataSet set) {
            this.set = set;
        }

        public BasicDataSet Set {
            get { return set; }
        }

        public void SendTransferBegin(TransferBeginEventArgs args) {
            TransferBegin?.Invoke(this, args);
        }

        public void SendTransferUpdate(TransferUpdateEventArgs args) {
            TransferUpdate?.Invoke(this, args);
        }

        public void SendTransferEnd(TransferEndEventArgs args) {
            TransferEnd?.Invoke(this, args);
        }

        #region IManager Members

        public IFolder GetRootFolder() {
            BasicDataSet.FolderRow fr = (from c in this.Set.Folder where c.FolderId == BasicManager.RootId select c).Single();
            return GetFolder(fr);
        }

        public event TransferBeginHandler TransferBegin;
        public event TransferUpdateHandler TransferUpdate;
        public event TransferEndHandler TransferEnd;

        public abstract void CacheDatabase(string cacheFile);
        public abstract void Open();
        public abstract void Close();
        public abstract void Save();

        public void Recycle(PurgeRules purgeRules) {
            DateTime purgeTime = DateTime.Now;

            //Delete FileInstances
            var fileInstanceRows = from fi in this.Set.FileInstance
                                   where fi.EndDate < purgeTime
                                   select fi;

            foreach (BasicDataSet.FileInstanceRow fileInstanceRow in fileInstanceRows) {
                if (purgeRules.PurgeFileInstance(this.GetFileInstance(fileInstanceRow))) {
                    fileInstanceRow.Delete();
                }
            }
            
            //Delete All Files without File Instances
            var fileRows = from f in this.Set.File
                           where (from fi in this.Set.FileInstance where fi.RowState != System.Data.DataRowState.Deleted && fi.FileId == f.FileId select fi).Count() == 0
                           select f;

            foreach (BasicDataSet.FileRow fileRow in fileRows) {
                fileRow.Delete();
            }

            //Delete FolderInstances
            var folderInstanceRows = from fi in this.Set.FolderInstance
                                     where fi.EndDate < purgeTime
                                     select fi;

            foreach (BasicDataSet.FolderInstanceRow folderInstanceRow in folderInstanceRows) {
                if (purgeRules.PurgeFolderInstance(this.GetFolderInstance(folderInstanceRow))) {
                    folderInstanceRow.Delete();
                }
            }

            //Delete All Folders without Folder Instances
            var folderRows = from f in this.Set.Folder
                             where (from fi in this.Set.FolderInstance where fi.RowState != System.Data.DataRowState.Deleted && fi.FolderId == f.FolderId select fi).Count() == 0
                             select f;

            foreach (BasicDataSet.FolderRow folderRow in folderRows) {
                folderRow.Delete();
            }

            this.Set.AcceptChanges();

            //Delete All streamIds without a matching instance in File Instances
            List<Guid> fileStreamIds = new List<Guid>(LoadStreamIds());
            var streamIds = from fsid in fileStreamIds
                            where !(from fi in this.Set.FileInstance select fi.StreamId).Contains(fsid)
                            select fsid;

            foreach (Guid streamId in streamIds) {
                DeleteStream(streamId);
            }
        }

        #endregion

    }
}
