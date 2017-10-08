using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using WabiLogic.Foundation.Encryption;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeFileMount : IFileMount {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeFileMount(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IMount & IFileMount Members

        public Guid Id { get { return this.DataSet.FileMount.FindById(this.Guid).MountRow.Id; } }
        public string Name {
            get { return this.DataSet.FileMount.FindById(this.Guid).MountRow.Name; }
            set { this.DataSet.FileMount.FindById(this.Guid).MountRow.Name = value; } 
        }
        public string Note {
            get { return this.DataSet.FileMount.FindById(this.Guid).MountRow.Note; }
            set { this.DataSet.FileMount.FindById(this.Guid).MountRow.Note = value; } 
        }
        public string TypeDisplayName { 
            get { return "File Share"; } 
        }
        public string Folder {
            get { return this.DataSet.FileMount.FindById(this.Guid).Folder; }
            set { this.DataSet.FileMount.FindById(this.Guid).Folder = value; } 
        }

        #endregion

        public override bool Equals(object obj) {
            if (obj is IFileMount fileMount && fileMount.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
