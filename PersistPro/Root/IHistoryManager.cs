using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBackupUtility.Backup;

namespace OnlineBackupUtility.Root {
    public interface IHistoryManager {
        IEnumerable<IHistory> LoadHistory(ISchedule schedule);
        IHistory LoadLatestHistory(ISchedule schedule);

        void PromptAgainAt(ISchedule schedule, DateTime promptAgainAt);
        void Abort(ISchedule schedule);
        void Complete(ISchedule schedule);
        void BeginBackup(ISchedule schedule);
    }
}
