using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfHistoryManager : IHistoryManager {
        private ProxyConnectionManager Proxy { get; set; }

        public WcfHistoryManager(ProxyConnectionManager proxy) {
            this.Proxy = proxy;
        }

        #region IHistoryManager Members

        public IEnumerable<IHistory> Histories {
            get {
                foreach (Guid historyId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.HistoryManagerGetHistoryIds())) {
                    yield return new WcfHistory(historyId, this.Proxy);
                }
            }
        }

        public IHistory CreateHistory(IPlan plan, HistoryStatus status, DateTime scheduleDate, string note) {
            return new WcfHistory(this.Proxy.Perform<Guid>(x => x.HistoryManagerCreateHistory(plan.Id, status, scheduleDate, note)), this.Proxy);
        }

        public void DeleteHistory(IHistory history) {
            this.Proxy.Perform(x => x.HistoryManagerDeleteHistory(history.Id));
        }

        public IHistory LoadLatestHistory(IPlan plan) {
            return new WcfHistory(this.Proxy.Perform<Guid>(x => x.HistoryManagerLoadLatestHistory(plan.Id)), this.Proxy);
        }

        public IEnumerable<IHistory> PlanHistories(IPlan plan) {
            foreach (Guid historyId in this.Proxy.Perform<IEnumerable<Guid>>(x => x.HistoryManagerPlanHistoryIds(plan.Id))) {
                yield return new WcfHistory(historyId, this.Proxy);
            }
        }

        public IHistory LoadHistory(Guid historyId) {
            return new WcfHistory(historyId, this.Proxy);
        }

        #endregion
    }
}
