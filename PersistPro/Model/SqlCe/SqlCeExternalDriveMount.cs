using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeExternalDriveMount : IExternalDriveMount {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeExternalDriveMount(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IMount & IFileMount Members

        public Guid Id { get { return this.DataSet.ExternalDriveMount.FindById(this.Guid).MountRow.Id; } }
        public string Name {
            get { return this.DataSet.ExternalDriveMount.FindById(this.Guid).MountRow.Name; }
            set { this.DataSet.ExternalDriveMount.FindById(this.Guid).MountRow.Name = value; } 
        }
        public string Note {
            get { return this.DataSet.ExternalDriveMount.FindById(this.Guid).MountRow.Note; }
            set { this.DataSet.ExternalDriveMount.FindById(this.Guid).MountRow.Note = value; } 
        }
        public string TypeDisplayName { 
            get { return "External Drive"; } 
        }
        public string Folder {
            get { return this.DataSet.ExternalDriveMount.FindById(this.Guid).Folder; }
            set { this.DataSet.ExternalDriveMount.FindById(this.Guid).Folder = value; } 
        }
        public string Label {
            get { return this.DataSet.ExternalDriveMount.FindById(this.Guid).Label; }
            set { this.DataSet.ExternalDriveMount.FindById(this.Guid).Label = value; }
        }

        #endregion

        public override bool Equals(object obj) {
            IExternalDriveMount externalDriveMount = obj as IExternalDriveMount;
            if (externalDriveMount != null && externalDriveMount.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
