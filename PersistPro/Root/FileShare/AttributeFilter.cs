using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root.FileShare {
    public class AttributeFilter : OnlineBackupUtility.Root.IAttributeFilter {
        public RootDataSet.AttributeFilterRow AttributeFilterRow { get; private set; }
        public Root Root { get; private set; }

        public AttributeFilter(RootDataSet.AttributeFilterRow attributeFilterRow, Root root) {
            this.AttributeFilterRow = attributeFilterRow;
            this.Root = root;
        }

        #region IAttributeFilter Members

        public System.IO.FileAttributes Filter {
            get {
                return this.AttributeFilterRow.Filter;
            }
            set {
                this.AttributeFilterRow.Filter = value;
            }
        }

        public FilterType FilterType {
            get {
                return this.AttributeFilterRow.FilterType;
            }
            set {
                this.AttributeFilterRow.FilterType = value;
            }
        }

        public string Note {
            get {
                return this.AttributeFilterRow.Note;
            }
            set {
                this.AttributeFilterRow.Note = value;
            }
        }

        #endregion
    }
}
