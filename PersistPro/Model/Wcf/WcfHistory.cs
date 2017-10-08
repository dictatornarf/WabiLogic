using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfHistory : IHistory {
        private Guid HistoryId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfHistory(Guid id, ProxyConnectionManager proxy) {
            this.HistoryId = id;
            this.Proxy = proxy;
        }

        #region IHistory Members

        public Guid Id {
            get { return this.HistoryId; }
        }

        public HistoryStatus Status {
            get {
                return this.Proxy.Perform<HistoryStatus>(x => x.HistoryGetStatus(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetStatus(this.Id, value));
            }
        }

        public DateTime ScheduleDate {
            get {
                return this.Proxy.Perform<DateTime>(x => x.HistoryGetScheduleDate(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetScheduleDate(this.Id, value));
            }
        }

        public DateTime ExecuteDate {
            get {
                return this.Proxy.Perform<DateTime>(x => x.HistoryGetExecuteDate(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetExecuteDate(this.Id, value));
            }
        }

        public DateTime BeginBackupDate {
            get {
                return this.Proxy.Perform<DateTime>(x => x.HistoryGetBeginBackupDate(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetBeginBackupDate(this.Id, value));
            }
        }

        public DateTime FinishBackupDate {
            get {
                return this.Proxy.Perform<DateTime>(x => x.HistoryGetFinishBackupDate(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetFinishBackupDate(this.Id, value));
            }
        }

        public string ErrorNote {
            get {
                return this.Proxy.Perform<string>(x => x.HistoryGetErrorNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetErrorNote(this.Id, value));
            }
        }

        public string Note {
            get {
                return this.Proxy.Perform<string>(x => x.HistoryGetNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.HistorySetNote(this.Id, value));
            }
        }

        #endregion
    }
}
