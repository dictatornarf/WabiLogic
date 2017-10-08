using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.Ftp {
    public class FtpFileInstance : BasicFileInstance {
        private FtpManager manager;

        public FtpFileInstance(FtpManager manager, BasicDataSet.FileInstanceRow fileInstanceRow)
            : base(manager, fileInstanceRow) {
            this.manager = manager;
        }

        public FtpManager FtpManager {
            get { return manager; }
        }
    }
}