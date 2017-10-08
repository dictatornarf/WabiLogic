using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using WabiLogic.Foundation.Encryption;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeFtpMount : IFtpMount {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeFtpMount(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IMount & IFtpMount Members

        public Guid Id { get { return this.DataSet.FtpMount.FindById(this.Guid).MountRow.Id; } }
        public string Name {
            get { return this.DataSet.FtpMount.FindById(this.Guid).MountRow.Name; }
            set { this.DataSet.FtpMount.FindById(this.Guid).MountRow.Name = value; }
        }
        public string Note {
            get { return this.DataSet.FtpMount.FindById(this.Guid).MountRow.Note; }
            set { this.DataSet.FtpMount.FindById(this.Guid).MountRow.Note = value; }
        }
        public string TypeDisplayName {
            get { return "FTP"; }
        }
        public string Folder {
            get { return this.DataSet.FtpMount.FindById(this.Guid).Folder; }
            set { this.DataSet.FtpMount.FindById(this.Guid).Folder = value; }
        }
        public string Server {
            get { return this.DataSet.FtpMount.FindById(this.Guid).Server; }
            set { this.DataSet.FtpMount.FindById(this.Guid).Server = value; }
        }

        public int Port {
            get { return this.DataSet.FtpMount.FindById(this.Guid).Port; }
            set { this.DataSet.FtpMount.FindById(this.Guid).Port = value; }
        }

        public string Username {
            get { return this.DataSet.FtpMount.FindById(this.Guid).Username; }
            set { this.DataSet.FtpMount.FindById(this.Guid).Username = value; }
        }

        public string Password {
            get { return this.DataSet.FtpMount.FindById(this.Guid).Password; }
            set { this.DataSet.FtpMount.FindById(this.Guid).Password = value; }
        }
        #endregion

        public override bool Equals(object obj) {
            IFtpMount ftpMount = obj as IFtpMount;
            if (ftpMount != null && ftpMount.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
