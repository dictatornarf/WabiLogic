using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Model;
using WabiLogic.PersistPro.Controller;


namespace WabiLogic.PersistPro.Restore
{
    public class RestoreInfo
    {
        public long TotalFileCount { get; set; }
        public long TotalFolderCount { get; set; }
        public long TotalFileSize { get; set; }

        public long RestoredFileCount { get; set; }
        public long RestoredFolderCount { get; set; }
        public long RestoredFileSize { get; set; }

        public static RestoreInfo operator +(RestoreInfo r1, RestoreInfo r2)
        {
            return new RestoreInfo()
            {
                TotalFileCount = r1.TotalFileCount + r2.TotalFileCount,
                TotalFolderCount = r1.TotalFolderCount + r2.TotalFolderCount,
                TotalFileSize = r1.TotalFileSize + r2.TotalFileSize,
                RestoredFileCount = r1.RestoredFileCount + r2.RestoredFileCount,
                RestoredFolderCount = r1.RestoredFolderCount + r2.RestoredFolderCount,
                RestoredFileSize = r1.RestoredFileSize + r2.RestoredFileSize
            };
        }
    }

    public class RestoreManager
    {
        public IFactory Factory { get; set; }
        public IRestorer Restorer { get; set; }

        private RestoreInfo restoreInfo = null;

        #region Events
        public event EventHandler<RestoreBeginEventArgs> RestoreBegin;
        public event EventHandler<EventArgs> RestoreEnd;
        public event EventHandler<FileRestoreCompleteEventArgs> FileRestoreComplete;
        public event EventHandler<FolderRestoreCompleteEventArgs> FolderRestoreComplete;

        protected virtual void OnRestoreBegin(RestoreBeginEventArgs e)
        {
            if (RestoreBegin != null)
            {
                RestoreBegin(this, e);
            }
        }

        protected virtual void OnRestoreEnd(EventArgs e)
        {
            if (RestoreEnd != null)
            {
                RestoreEnd(this, e);
            }
        }

        protected virtual void OnFileRestoreComplete(FileRestoreCompleteEventArgs e)
        {
            if (FileRestoreComplete != null)
            {
                FileRestoreComplete(this, e);
            }
        }

        protected virtual void OnFolderRestoreComplete(FolderRestoreCompleteEventArgs e)
        {
            if (FolderRestoreComplete != null)
            {
                FolderRestoreComplete(this, e);
            }
        }

        #endregion

        public RestoreManager(IFactory factory, IRestorer restorer)
        {
            this.Factory = factory;
            this.Restorer = restorer;
        }

        public void Restore()
        {
            //setup our eventhandlers
            EventHandler<ItemRestoreCompleteEventArgs> itmRestoreCompleteHandler = (sender, e) =>
            {
               this.restoreInfo.RestoredFileCount++;
               this.restoreInfo.RestoredFileSize += e.RestoredFile.Size;
               OnFileRestoreComplete(new FileRestoreCompleteEventArgs(e.RestoredFile, "", restoreInfo));
            };

            //get our restore counts
            this.restoreInfo = Restorer.GenerateRestoreInfo();
            //run the restore
            OnRestoreBegin(new RestoreBeginEventArgs("", restoreInfo));

            Restorer.ItemRestoreComplete += itmRestoreCompleteHandler;
            Restorer.RestoreItem();
            Restorer.ItemRestoreComplete -= itmRestoreCompleteHandler;
            OnRestoreEnd(new EventArgs());
        }
}
}
