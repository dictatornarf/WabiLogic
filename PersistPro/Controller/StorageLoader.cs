using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Encryption;

namespace WabiLogic.PersistPro.Controller {
    public static class StorageLoader {
        public static IManager Load(IMount mount, IEncryption encryption) {
            IManager toReturn = null;

            IFileMount fileMount = mount as IFileMount;
            if (fileMount != null) {
                toReturn = new WabiLogic.Foundation.Storage.FileShare.FileShareManager(fileMount.Folder, encryption);
            }

            IExternalDriveMount externalDriveMount = mount as IExternalDriveMount;
            if (externalDriveMount != null) {
                foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives()) {
                    try {
                        if (drive.IsReady && drive.VolumeLabel == externalDriveMount.Label) {
                            string folder = System.IO.Path.Combine(drive.RootDirectory.FullName, externalDriveMount.Folder);
                            toReturn = new WabiLogic.Foundation.Storage.FileShare.FileShareManager(folder, encryption);
                            break;
                        }
                    }
                    catch {
                        //Ignore
                    }
                }

                if (toReturn == null)
                    throw new ApplicationException("The external drive could not be opened.");
            }

            IFtpMount ftpMount = mount as IFtpMount;
            if (ftpMount != null) {
                toReturn = new WabiLogic.Foundation.Storage.Ftp.FtpManager(ftpMount.Server, ftpMount.Port, ftpMount.Username, ftpMount.Password, ftpMount.Folder, encryption);
            }

            return toReturn;
        }
    }
}
