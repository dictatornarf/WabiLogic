using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.Ftp {
    public class FtpFolder : BasicFolder {
        private FtpManager manager;

        public FtpFolder(FtpManager manager, BasicDataSet.FolderRow folderRow)
            : base(manager, folderRow) {
            this.manager = manager;
        }

        public FtpManager FtpManager {
            get { return manager; }
        }
    }
}