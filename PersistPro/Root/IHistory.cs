using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBackupUtility.Backup;

namespace OnlineBackupUtility.Root {
    public interface IHistory {
        int Id { get; }
        int ScheduleId { get; }
        HistoryStatus Status { get; }
        DateTime ScheduleDate { get; }
        DateTime PromptAgainAt { get; }
        DateTime BeginBackupDate { get; }
        DateTime FinishBackupDate { get; }
    }
}
