using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Tools;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeSchedule : ISchedule {
        private Guid Guid { get; set; }
        private PersistProDataSet DataSet { get; set; }

        public SqlCeSchedule(Guid id, PersistProDataSet dataSet) {
            this.Guid = id;
            this.DataSet = dataSet;
        }

        #region ISchedule Members

        public Guid Id { get { return this.Guid; } }
        public string Name {
            get { return this.DataSet.Schedule.FindById(this.Guid).Name; }
            set { this.DataSet.Schedule.FindById(this.Guid).Name = value; } 
        }
        public TimeSpan Time {
            get { return new TimeSpan(this.DataSet.Schedule.FindById(this.Guid).Time); }
            set { this.DataSet.Schedule.FindById(this.Guid).Time = value.Ticks; } 
        }
        public ScheduleType ScheduleType {
            get { return (ScheduleType)Enum.Parse(typeof(ScheduleType), this.DataSet.Schedule.FindById(this.Guid).ScheduleType); }
            set { this.DataSet.Schedule.FindById(this.Guid).ScheduleType = value.ToString(); }
        }
        public DayOfWeek DayOfWeek {
            get { return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), this.DataSet.Schedule.FindById(this.Guid).DayOfWeek); }
            set { this.DataSet.Schedule.FindById(this.Guid).DayOfWeek = value.ToString(); }
        }
        public WeekOfMonth WeekOfMonth {
            get { return (WeekOfMonth)Enum.Parse(typeof(WeekOfMonth), this.DataSet.Schedule.FindById(this.Guid).WeekOfMonth); }
            set { this.DataSet.Schedule.FindById(this.Guid).WeekOfMonth = value.ToString(); }
        }

        #endregion

        public override bool Equals(object obj) {
            ISchedule schedule = obj as ISchedule;
            if (schedule.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
    }
}
