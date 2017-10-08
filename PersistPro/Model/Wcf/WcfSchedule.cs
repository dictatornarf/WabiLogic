using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfSchedule : ISchedule {
        private Guid ScheduleId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfSchedule(Guid id, ProxyConnectionManager proxy) {
            this.ScheduleId = id;
            this.Proxy = proxy;
        }

        #region ISchedule Members

        public Guid Id {
            get { return this.ScheduleId; }
        }

        public string Name {
            get {
                return this.Proxy.Perform<string>(x => x.ScheduleGetName(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ScheduleSetName(this.Id, value));
            }
        }

        public TimeSpan Time {
            get {
                return this.Proxy.Perform<TimeSpan>(x => x.ScheduleGetTime(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ScheduleSetTime(this.Id, value));
            }
        }

        public ScheduleType ScheduleType {
            get {
                return this.Proxy.Perform<ScheduleType>(x => x.ScheduleGetScheduleType(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ScheduleSetScheduleType(this.Id, value));
            }
        }

        public DayOfWeek DayOfWeek {
            get {
                return this.Proxy.Perform<DayOfWeek>(x => x.ScheduleGetDayOfWeek(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ScheduleSetDayOfWeek(this.Id, value));
            }
        }

        public WabiLogic.Foundation.Tools.WeekOfMonth WeekOfMonth {
            get {
                return this.Proxy.Perform<WabiLogic.Foundation.Tools.WeekOfMonth>(x => x.ScheduleGetWeekOfMonth(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ScheduleSetWeekOfMonth(this.Id, value));
            }
        }

        #endregion

        public override bool Equals(object obj)
        {
            ISchedule schedule = obj as ISchedule;
            if (schedule != null && schedule.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
