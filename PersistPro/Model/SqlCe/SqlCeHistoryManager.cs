using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model.SqlCe {
    public class SqlCeHistoryManager : IHistoryManager {
        private HistoryDataSet DataSet { get; set; }

        public SqlCeHistoryManager(HistoryDataSet dataSet) {
            this.DataSet = dataSet;
        }

        #region IHistoryManager Members

        public IEnumerable<IHistory> Histories {
            get {
                foreach (HistoryDataSet.HistoryRow row in this.DataSet.History)
                    yield return new SqlCeHistory(row.Id, this.DataSet);
            }
        }

        public IHistory CreateHistory(IPlan plan, HistoryStatus status, DateTime scheduleDate, string note) {
            return new SqlCeHistory(this.DataSet.History.AddHistoryRow(
                Guid.NewGuid(),
                plan.Id,
                status.ToString(),
                scheduleDate,
                scheduleDate,
                DateTime.MaxValue.AddMilliseconds(-1), //Fix for SqlCe
                DateTime.MaxValue.AddMilliseconds(-1), //Fix for SqlCe
                string.Empty,
                note
            ).Id, this.DataSet);
        }

        public void DeleteHistory(IHistory history) {
            this.DataSet.History.FindById(history.Id).Delete();
        }

        public IHistory LoadLatestHistory(IPlan plan) {
            IHistory toReturn = null;
            var planHistories = this.DataSet.History.Where(x => x.PlanId == plan.Id);
            var planHistory = planHistories.Where(x => x.ExecuteDate.Ticks == planHistories.Max(y => y.ExecuteDate.Ticks));

            if (planHistory.Count() == 1)
                toReturn = new SqlCeHistory(planHistory.Single().Id, this.DataSet);

            return toReturn;
        }

        public IEnumerable<IHistory> PlanHistories(IPlan plan) {
            foreach (HistoryDataSet.HistoryRow row in this.DataSet.History.Where(x => x.PlanId == plan.Id))
                yield return new SqlCeHistory(row.Id, this.DataSet);
        }

        public IHistory LoadHistory(Guid historyId) {
            var histories = this.DataSet.History.Where(x => x.Id == historyId);
            if (histories.Count() == 1)
                return new SqlCeHistory(historyId, this.DataSet);
            else
                return null;
        }

        #endregion
    }
}
