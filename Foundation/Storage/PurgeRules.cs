using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Storage {
    public abstract class PurgeRules {
        public abstract bool PurgeFolderInstance(IFolderInstance folderInstance);
        public abstract bool PurgeFileInstance(IFileInstance fileInstance);

        public class TimeSpanPurgeRules : PurgeRules {
            private TimeSpan span;

            public TimeSpanPurgeRules(TimeSpan span) {
                this.span = span;
            }

            public TimeSpan Span {
                get { return span; }
            }

            public override bool PurgeFolderInstance(IFolderInstance folderInstance) {
                return (DateTime.Now - folderInstance.EndDate) > span;
            }

            public override bool PurgeFileInstance(IFileInstance fileInstance) {
                return (DateTime.Now - fileInstance.EndDate) > span;
            }
        }
    }
}
