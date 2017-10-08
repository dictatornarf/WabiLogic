using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage.BasicBase;

namespace UnitTests.Storage.BasicBase.Mock {
    class BasicMockFolder : BasicFolder {
        public BasicMockFolder(BasicMockManager manager, BasicDataSet.FolderRow folderRow)
            : base(manager, folderRow) {
            this.BasicMockManager = manager;
        }

        public BasicMockManager BasicMockManager { get; private set; }
    }
}
