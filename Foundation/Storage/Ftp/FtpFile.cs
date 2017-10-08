using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.Ftp {
    public class FtpFile : BasicFile {
        private FtpManager manager;

        public FtpFile(FtpManager manager, BasicDataSet.FileRow fileRow)
            : base(manager, fileRow) {
            this.manager = manager;
        }

        public FtpManager FtpManager {
            get { return manager; }
        }
    }
}