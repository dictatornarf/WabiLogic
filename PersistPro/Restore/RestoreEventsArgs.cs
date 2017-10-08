using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro.Restore
{
    public class RestoreBeginEventArgs : EventArgs
    {
        private string RestorePath { get; set; }
        public RestoreInfo RestoreInfo { get; private set; }

        public RestoreBeginEventArgs(string restorePath) : this(restorePath, null) { }
        public RestoreBeginEventArgs(string restorePath, RestoreInfo restoreInfo)
        {
            this.RestorePath = restorePath;
            this.RestoreInfo = restoreInfo;
        }
    }

    public class ItemRestoreCompleteEventArgs : EventArgs
    {
        public RestoreInfo RestoreInfo { get; private set; }
        public IFileInstance RestoredFile { get; private set; }

        public ItemRestoreCompleteEventArgs(IFileInstance restoredFile,RestoreInfo restoreInfo)
        {
            this.RestoredFile = restoredFile;
            this.RestoreInfo = restoreInfo;
        }
    }
    public class FileRestoreCompleteEventArgs : EventArgs
    {
        public IFileInstance RestoredFile { get; private set; }
        public string RestorePath { get; private set; }
        public string FileName { get; private set; }
        public RestoreInfo RestoreInfo { get; private set; }

        public FileRestoreCompleteEventArgs(IFileInstance fileRestored, string restorePath, RestoreInfo restoreInfo)
        {
            this.RestoredFile = fileRestored;
            this.FileName = fileRestored.Name;
            this.RestoreInfo = restoreInfo;
        }

        public FileRestoreCompleteEventArgs(string fileName, string restorePath)
        {
            this.RestorePath = restorePath;
            this.FileName = fileName;
        }
    }


    public class FolderRestoreCompleteEventArgs : EventArgs

    {
        public string RestorePath { get; private set; }
        public string FolderName { get; private set; }

        public FolderRestoreCompleteEventArgs(string folderName, string restorePath)
        {
            this.RestorePath = restorePath;
            this.FolderName = folderName;
        }
    }

}
