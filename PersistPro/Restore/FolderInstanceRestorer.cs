using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Tools.Extensions;
using System.IO;

namespace WabiLogic.PersistPro.Restore
{
    class FolderInstanceRestorer : IRestorer
    {
        public IFolderInstance FolderInstanceToRestore { get; set; }
        public bool IncludeAllFileVersions { get; set; }
        public bool IncludeSubFolders { get; set; }
        public string RestorePath { get; set; }
        public DateTime SnapShot { get; set; }

        private void RestoreFolder(IFolder folder, string restorePath, Func<string, IFolder, string> folderRestoreMethod, Action<IFile, string, bool> fileRestoreMethod)
        {
            restorePath = folderRestoreMethod(restorePath, folder);

            IEnumerable<IFile> filesToRestore = null;

            filesToRestore = folder.GetFiles(SnapShot);

            foreach (IFile file in filesToRestore)
            {
                fileRestoreMethod(file, restorePath, IncludeAllFileVersions);
            }

            if (IncludeSubFolders)
            {
                foreach (IFolder subfolder in folder.GetSubFolders(SnapShot))
                {
                    RestoreFolder(subfolder, restorePath, folderRestoreMethod, fileRestoreMethod);
                }
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
            Action<IFile, string, bool> restoreFile = (file, restorePath, restoreAll) =>
            {
                IRestorer fileRestorer = RestoreFactory.RestoreFile(file,
                                                                    restorePath,
                                                                    restoreAll,
                                                                    SnapShot);
                fileRestorer.ItemRestoreComplete += new EventHandler<ItemRestoreCompleteEventArgs>(fileRestorer_ItemRestoreComplete); //itmRestoreCompleteHandler;
                fileRestorer.RestoreItem();
                fileRestorer.ItemRestoreComplete -= new EventHandler<ItemRestoreCompleteEventArgs>(fileRestorer_ItemRestoreComplete); //itmRestoreCompleteHandler;
                fileRestorer = null;
            };

            Func<string, IFolder, string> CreateFolder = (restorePath, folderToRestore) =>
            {
                restorePath = Path.Combine(restorePath, folderToRestore.GetFolderInstance(SnapShot).GetCleanFileName());

                if (!Directory.Exists(restorePath))
                {
                    Directory.CreateDirectory(restorePath);
                }
                return restorePath;
            };

            RestoreFolder(FolderInstanceToRestore.Folder,
                RestorePath,
                CreateFolder,
                restoreFile);
        }

        void fileRestorer_ItemRestoreComplete(object sender, ItemRestoreCompleteEventArgs e)
        {
            OnItemRestoreComplete(new ItemRestoreCompleteEventArgs(e.RestoredFile, null));
        }

        public RestoreInfo GenerateRestoreInfo()
        {
            RestoreInfo restoreInfo = new RestoreInfo();

            RestoreFolder(FolderInstanceToRestore.Folder,
               RestorePath,
              (path, folder) => { restoreInfo.TotalFolderCount++; return string.Empty; },
              (file, path, inc) => {
                  IRestorer restorer = RestoreFactory.RestoreFile(file, path, inc, SnapShot);
                  restoreInfo += restorer.GenerateRestoreInfo();
              });

            return restoreInfo;
        }
    }
}
