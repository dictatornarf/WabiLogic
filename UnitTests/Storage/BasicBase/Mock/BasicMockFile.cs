using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage.BasicBase;

namespace UnitTests.Storage.BasicBase.Mock {
    class BasicMockFile : BasicFile {
        public BasicMockFile(BasicMockManager manager, BasicDataSet.FileRow fileRow)
            : base(manager, fileRow) {
            this.BasicMockManager = manager;
        }

        public BasicMockManager BasicMockManager { get; private set; }
    }
}
