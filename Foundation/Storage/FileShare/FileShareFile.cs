using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.FileShare {
    public class FileShareFile : BasicFile {
        private FileShareManager manager;

        public FileShareFile(FileShareManager manager, BasicDataSet.FileRow fileRow)
            : base(manager, fileRow) {
            this.manager = manager;
        }

        public FileShareManager FileShareManager {
            get { return manager; }
        }
    }
}