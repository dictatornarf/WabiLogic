using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.FileShare {
    public class FileShareFileInstance : BasicFileInstance {
        private FileShareManager manager;

        public FileShareFileInstance(FileShareManager manager, BasicDataSet.FileInstanceRow fileInstanceRow)
            : base(manager, fileInstanceRow) {
            this.manager = manager;
        }

        public FileShareManager FileShareManager {
            get { return manager; }
        }
    }
}