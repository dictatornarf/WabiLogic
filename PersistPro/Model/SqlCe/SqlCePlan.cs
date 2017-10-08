using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCePlan : IPlan {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCePlan(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region IPlan Members

        public Guid Id { get { return this.Guid; } }
        public IRoot Root {
            get { return new SqlCeRoot(this.DataSet.Plan.FindById(this.Guid).RootRow.Id, this.DataSet); }
            set { this.DataSet.Plan.FindById(this.Guid).RootId = value.Id; }
        }   
        public IMount Mount {
            get { return SqlCePlanManager.LoadMount(this.DataSet.Plan.FindById(this.Guid).MountRow.Id, this.DataSet); }
            set { this.DataSet.Plan.FindById(this.Guid).MountId = value.Id; } 
        }
        public ISchedule Schedule {
            get { return new SqlCeSchedule(this.DataSet.Plan.FindById(this.Guid).ScheduleRow.Id, this.DataSet); }
            set { this.DataSet.Plan.FindById(this.Guid).ScheduleId = value.Id; } 
        }

        #endregion

        public override bool Equals(object obj) {
            IPlan plan = obj as IPlan;
            if (plan.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
