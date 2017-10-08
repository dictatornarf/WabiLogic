using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeHistory : IHistory {
        private Guid Guid { get; set; }
        private HistoryDataSet DataSet { get; set; }

        public SqlCeHistory(Guid id, HistoryDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IHistory Members

        public Guid Id { get { return this.Guid; } }
        
        public HistoryStatus Status {
            get { return (HistoryStatus)Enum.Parse(typeof(HistoryStatus), this.DataSet.History.FindById(this.Guid).Status); }
            set { this.DataSet.History.FindById(this.Guid).Status = value.ToString(); }
        }
        
        public DateTime ScheduleDate {
            get { return this.DataSet.History.FindById(this.Guid).ScheduleDate; }
            set { this.DataSet.History.FindById(this.Guid).ScheduleDate = value; }
        }
        
        public DateTime ExecuteDate {
            get { return this.DataSet.History.FindById(this.Guid).ExecuteDate; }
            set { this.DataSet.History.FindById(this.Guid).ExecuteDate = value; }
        }
        
        public DateTime BeginBackupDate {
            get { return this.DataSet.History.FindById(this.Guid).BeginBackupDate; }
            set { this.DataSet.History.FindById(this.Guid).BeginBackupDate = value; }
        }
        
        public DateTime FinishBackupDate {
            get { return this.DataSet.History.FindById(this.Guid).FinishBackupDate; }
            set { this.DataSet.History.FindById(this.Guid).FinishBackupDate = value; }
        }

        public string ErrorNote {
            get { return this.DataSet.History.FindById(this.Guid).ErrorNote; }
            set { this.DataSet.History.FindById(this.Guid).ErrorNote = value; }
        }

        public string Note {
            get { return this.DataSet.History.FindById(this.Guid).Note; }
            set { this.DataSet.History.FindById(this.Guid).Note = value; } 
        }
        
        #endregion
    }
}
