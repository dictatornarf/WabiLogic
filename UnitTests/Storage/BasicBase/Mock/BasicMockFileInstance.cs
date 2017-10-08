using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Storage.BasicBase;

namespace UnitTests.Storage.BasicBase.Mock {
    class BasicMockFileInstance : BasicFileInstance {
        public BasicMockFileInstance(BasicMockManager manager, BasicDataSet.FileInstanceRow fileInstanceRow)
            : base(manager, fileInstanceRow) {
            this.BasicMockManager = manager;
        }

        public BasicMockManager BasicMockManager { get; private set; }
    }
}
