using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeRoot : IRoot {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeRoot(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IRoot Members

        public Guid Id { get { return this.Guid; } }
        public string Name {
            get { return this.DataSet.Root.FindById(this.Guid).Name; }
            set { this.DataSet.Root.FindById(this.Guid).Name = value; } 
        }
        public string Folder {
            get { return this.DataSet.Root.FindById(this.Guid).Folder; }
            set { this.DataSet.Root.FindById(this.Guid).Folder = value; } 
        }
        public bool Sub {
            get { return this.DataSet.Root.FindById(this.Guid).Sub; }
            set { this.DataSet.Root.FindById(this.Guid).Sub = value; } 
        }
        public bool KeepHistory {
            get { return this.DataSet.Root.FindById(this.Guid).KeepHistory; }
            set { this.DataSet.Root.FindById(this.Guid).KeepHistory = value; }
        }
        public string Note {
            get { return this.DataSet.Root.FindById(this.Guid).Note; }
            set { this.DataSet.Root.FindById(this.Guid).Note = value; } 
        }

        public IEnumerable<IRootNameFilter> NameFilters { 
            get {
                foreach (PersistProDataSet.RootNameFilterRow subRow in this.DataSet.Root.FindById(this.Guid).GetRootNameFilterRows())
                    yield return new SqlCeRootNameFilter(subRow.Id, this.DataSet);
            }
        }
        public IEnumerable<IRootAttributeFilter> AttributeFilters {
            get {
                foreach (PersistProDataSet.RootAttributeFilterRow subRow in this.DataSet.Root.FindById(this.Guid).GetRootAttributeFilterRows())
                    yield return new SqlCeRootAttributeFilter(subRow.Id, this.DataSet);
            }
        }

        #endregion

        public override bool Equals(object obj) {
            IRoot root = obj as IRoot;
            if (root.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
