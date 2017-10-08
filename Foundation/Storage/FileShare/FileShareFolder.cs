using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.FileShare {
    public class FileShareFolder : BasicFolder {
        private FileShareManager manager;

        public FileShareFolder(FileShareManager manager, BasicDataSet.FolderRow folderRow)
            : base(manager, folderRow) {
            this.manager = manager;
        }

        public FileShareManager FileShareManager {
            get { return manager; }
        }
    }
}