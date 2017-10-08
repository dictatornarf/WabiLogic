using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage.BasicBase;

namespace UnitTests.Storage.BasicBase.Mock {
    class BasicMockFolderInstance : BasicFolderInstance {
        public BasicMockFolderInstance(BasicMockManager manager, BasicDataSet.FolderInstanceRow folderInstanceRow)
            : base(manager, folderInstanceRow) {
            this.BasicMockManager = manager;
        }

        public BasicMockManager BasicMockManager { get; private set; }
    }
}
