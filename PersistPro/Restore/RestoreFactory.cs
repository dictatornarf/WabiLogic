using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro.Restore
{
    public class RestoreFactory : IRestoreFactory
    {

        public static IRestorer RestoreFileInstance(IFileInstance item, string restorePath, bool incDateInFileName)
        {
            FileInstanceRestorer fileRestorer = new FileInstanceRestorer()
            {
                FileInstanceToRestore = item,
                IncludeDateInFileName = incDateInFileName,
                RestorePath = restorePath
            };

            return fileRestorer;
        }

        public static IRestorer RestoreFile(IFile file, string restorePath, bool incAllFileVersions, DateTime snapShot)
        {
            FileRestorer restorer = new FileRestorer()
            {
                FileToRestore = file,
                IncludeAllFileVersions = incAllFileVersions,
                SnapShot = snapShot,
                RestorePath = restorePath
            };
            return restorer;
        }

        public static IRestorer RestoreFolder(IFolderInstance folder, string restorePath, bool incSubFolders, bool incAllFileVersions, DateTime snapShot)
        {
            FolderInstanceRestorer restorer = new FolderInstanceRestorer()
            {
               FolderInstanceToRestore = folder,
               RestorePath = restorePath,
               IncludeSubFolders = incSubFolders,
               IncludeAllFileVersions = incAllFileVersions,
               SnapShot = snapShot

            };
            return restorer;
        }

        #region IRestoreFactory Members

        IRestorer IRestoreFactory.RestoreFileInstance(IFileInstance item, string restorePath, bool incDateInFileName)
        {
            return RestoreFileInstance(item, restorePath, incDateInFileName);
        }

        IRestorer IRestoreFactory.RestoreFile(IFile file, string restorePath, bool incAllFileVersions, DateTime snapShot)
        {
            return RestoreFile(file, restorePath, incAllFileVersions, snapShot);
        }

        IRestorer IRestoreFactory.RestoreFolder(IFolderInstance folder, string restorePath, bool incSubFolders, bool incAllFileVersions, DateTime snapShot)
        {
            return RestoreFolder(folder, restorePath, incSubFolders, incAllFileVersions, snapShot);
        }

        #endregion
    }
}
