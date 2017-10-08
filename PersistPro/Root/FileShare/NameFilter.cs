using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root.FileShare {
    public class NameFilter : OnlineBackupUtility.Root.INameFilter {
        public RootDataSet.NameFilterRow NameFilterRow { get; private set; }
        public Root Root { get; private set; }

        public NameFilter(RootDataSet.NameFilterRow nameFilterRow, Root root) {
            this.NameFilterRow = nameFilterRow;
            this.Root = root;
        }

        #region INameFilter Members

        public string Filter {
            get {
                return this.NameFilterRow.Filter;
            }
            set {
                this.NameFilterRow.Filter = value;
            }
        }

        public FilterType FilterType {
            get {
                return this.NameFilterRow.FilterType;
            }
            set {
                this.NameFilterRow.FilterType = value;
            }
        }

        public string Note {
            get {
                return this.NameFilterRow.Note;
            }
            set {
                this.NameFilterRow.Note = value;
            }
        }

        #endregion
    }
}
