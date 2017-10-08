using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.Ftp {
    public class FtpFolderInstance : BasicFolderInstance {
        private FtpManager manager;

        public FtpFolderInstance(FtpManager manager, BasicDataSet.FolderInstanceRow folderInstanceRow)
            : base(manager, folderInstanceRow) {
            this.manager = manager;
        }

        public FtpManager FtpManager {
            get { return manager; }
        }
    }
}