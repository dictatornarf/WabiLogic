using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root.FileShare {
    public class HistoryManager : IHistoryManager {
        public HistoryDataSet HistoryDataSet { get; private set; }

        public HistoryManager(HistoryDataSet historyDataSet) {
            this.HistoryDataSet = historyDataSet;
        }

        #region IHistoryManager Members

        public IEnumerable<IHistory> LoadHistory(ISchedule schedule) {
            var history = (from x in this.HistoryDataSet.History
                    where x.ScheduleId == schedule.Id
                    orderby x.ScheduleDate
                    select x);

            foreach (HistoryDataSet.HistoryRow historyRow in history)
                yield return new History(historyRow, this);
        }

        public IHistory LoadLatestHistory(ISchedule schedule) {
            var history = (from x in this.HistoryDataSet.History
                           where x.ScheduleId == schedule.Id
                           select x);
            if (history.Count() > 0)
                return new History(history.Max<HistoryDataSet.HistoryRow>(), this);
            else
                return null;
        }

        public void PromptAgainAt(ISchedule schedule, DateTime promptAgainAt) {
            throw new NotImplementedException();
        }

        public void Abort(ISchedule schedule) {
            throw new NotImplementedException();
            //CalculateNextEvent();
        }

        public void Complete(ISchedule schedule) {
            throw new NotImplementedException();
            //CalculateNextEvent();
        }

        public void BeginBackup(ISchedule schedule) {
            throw new NotImplementedException();
        }

        #endregion

        private void CalculateNextEvent(ISchedule schedule) {
            //OnlineBackupUtility.Root.Schedule.
        }
    }
}
