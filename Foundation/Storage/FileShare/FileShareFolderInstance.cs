using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Storage;
using WabiLogic.Foundation.Storage.BasicBase;

namespace WabiLogic.Foundation.Storage.FileShare {
    public class FileShareFolderInstance : BasicFolderInstance {
        private FileShareManager manager;

        public FileShareFolderInstance(FileShareManager manager, BasicDataSet.FolderInstanceRow folderInstanceRow)
            : base(manager, folderInstanceRow) {
            this.manager = manager;
        }

        public FileShareManager FileShareManager {
            get { return manager; }
        }
    }
}