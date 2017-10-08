using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeRootNameFilter : IRootNameFilter {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeRootNameFilter(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IRootNameFilter Members

        public Guid Id { get { return this.Guid; } }
        public string Filter {
            get { return this.DataSet.RootNameFilter.FindById(this.Guid).Filter; }
            set { this.DataSet.RootNameFilter.FindById(this.Guid).Filter = value; } 
        }
        public FilterType FilterType {
            get { return (FilterType)Enum.Parse(typeof(FilterType), this.DataSet.RootNameFilter.FindById(this.Guid).FilterType); }
            set { this.DataSet.RootNameFilter.FindById(this.Guid).FilterType = value.ToString(); } 
        }
        public string Note {
            get { return this.DataSet.RootNameFilter.FindById(this.Guid).Note; }
            set { this.DataSet.RootNameFilter.FindById(this.Guid).Note = value; } 
        }

        #endregion
    }
}
