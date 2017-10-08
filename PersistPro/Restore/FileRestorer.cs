using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro.Restore
{
    class FileRestorer : IRestorer
    {
        public IFile FileToRestore { get; set; }
        public bool IncludeAllFileVersions { get; set; }
        public string RestorePath { get; set; }
        public DateTime SnapShot { get; set; }

        private void RestoreFile(IFile file, string restorepath, Action<IFileInstance, string, bool> restoreFileInstance)
        {
            if (IncludeAllFileVersions)
            {
                IEnumerable<IFileInstance> fileInstances = file.GetFileInstances().Where(x => x.StartDate <= SnapShot);

                bool incDateInFileName = fileInstances.Count() > 1;
                foreach (IFileInstance fileInstance in fileInstances)
                {
                    restoreFileInstance(fileInstance, restorepath, incDateInFileName);
                }
            }
            else
            {
                restoreFileInstance(file.GetFileInstance(SnapShot),restorepath,false);
            }


        }

        public event EventHandler<ItemRestoreCompleteEventArgs> ItemRestoreComplete;

        protected virtual void OnItemRestoreComplete(ItemRestoreCompleteEventArgs e)
        {
            if (ItemRestoreComplete != null)
            {
                ItemRestoreComplete(this, e);
            }
        }

        public void RestoreItem()
        {
            Action<IFileInstance, string, bool> restoreFile = (file, restorePath, incDateInFileName) =>
            {
                IRestorer fileRestorer = RestoreFactory.RestoreFileInstance(file,
                                                    restorePath,
                                                    incDateInFileName);
                //fileRestorer.ItemRestoreComplete += itmRestoreCompleteHandler;
                fileRestorer.ItemRestoreComplete += new EventHandler<ItemRestoreCompleteEventArgs>(fileRestorer_ItemRestoreComplete);
                fileRestorer.RestoreItem();
                fileRestorer.ItemRestoreComplete -= new EventHandler<ItemRestoreCompleteEventArgs>(fileRestorer_ItemRestoreComplete);
                fileRestorer = null;
            };

            RestoreFile(FileToRestore, RestorePath, restoreFile);
        }

        void fileRestorer_ItemRestoreComplete(object sender, ItemRestoreCompleteEventArgs e)
        {
            OnItemRestoreComplete(new ItemRestoreCompleteEventArgs(e.RestoredFile, null));
        }

        public RestoreInfo GenerateRestoreInfo()
        {
            RestoreInfo restoreInfo = new RestoreInfo();

            RestoreFile(FileToRestore, RestorePath,
                        (x, y, z) => { restoreInfo.TotalFileCount++; restoreInfo.TotalFileSize += x.Size; });
            return restoreInfo;
        }
    }
}
