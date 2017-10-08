using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root.FileShare {
    public class History : IHistory {
        public HistoryDataSet.HistoryRow HistoryRow { get; private set; }
        public HistoryManager HistoryManager { get; private set; }

        public History(HistoryDataSet.HistoryRow historyRow, HistoryManager historyManager) {
            this.HistoryRow = historyRow;
            this.HistoryManager = historyManager;
        }

        #region IHistory Members

        public int Id {
            get { return this.HistoryRow.HistoryId; }
        }

        public int ScheduleId {
            get { return this.HistoryRow.ScheduleId; }
        }

        public OnlineBackupUtility.Backup.HistoryStatus Status {
            get { return this.HistoryRow.Status; }
        }

        public DateTime ScheduleDate {
            get { return this.HistoryRow.ScheduleDate; }
        }

        public DateTime PromptAgainAt {
            get { return this.HistoryRow.PromptAgainAt; }
        }

        public DateTime BeginBackupDate {
            get { return this.HistoryRow.BeginBackupDate; }
        }

        public DateTime FinishBackupDate {
            get { return this.HistoryRow.FinishBackupDate; }
        }

        #endregion
    }
}
