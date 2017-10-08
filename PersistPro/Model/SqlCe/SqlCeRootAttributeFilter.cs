using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeRootAttributeFilter : IRootAttributeFilter {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeRootAttributeFilter(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IRootAttributeFilter Members

        public Guid Id { get { return this.Guid; } }
        public FileAttributes Filter {
            get { return (FileAttributes)Enum.Parse(typeof(FileAttributes), this.DataSet.RootAttributeFilter.FindById(this.Guid).Filter); }
            set { this.DataSet.RootAttributeFilter.FindById(this.Guid).Filter = value.ToString(); } 
        }
        public FilterType FilterType {
            get { return (FilterType)Enum.Parse(typeof(FilterType), this.DataSet.RootAttributeFilter.FindById(this.Guid).FilterType); }
            set { this.DataSet.RootAttributeFilter.FindById(this.Guid).FilterType = value.ToString(); } 
        }
        public string Note {
            get { return this.DataSet.RootAttributeFilter.FindById(this.Guid).Note; }
            set { this.DataSet.RootAttributeFilter.FindById(this.Guid).Note = value; }
        }

        #endregion
    }
}
