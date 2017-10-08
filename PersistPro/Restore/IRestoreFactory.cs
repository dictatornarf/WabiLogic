using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;

namespace WabiLogic.PersistPro.Restore
{
    interface IRestoreFactory
    {
        IRestorer RestoreFileInstance(IFileInstance item, string restorePath, bool incDateInFileName);
        IRestorer RestoreFile(IFile file, string restorePath, bool incAllFileVersions, DateTime snapShot);
        IRestorer RestoreFolder(IFolderInstance folder, string restorePath, bool incSubFolders, bool incAllFileVersions, DateTime snapShot);
    }
}
