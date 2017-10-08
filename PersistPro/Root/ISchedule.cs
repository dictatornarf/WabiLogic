using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root {
    public enum ScheduleType {
        Daily,
        Weekly,
        Monthly,
        None
    }

    public enum WeekOfMonth {
        First,
        Second,
        Third,
        Fourth,
        Last
    }

    public interface ISchedule {
        int Id { get; }
        TimeSpan Time { get; set; }
        ScheduleType ScheduleType { get; set; }
        DayOfWeek DayOfWeek { get; set; }
        WeekOfMonth WeekOfMonth { get; set; }
        bool PromptBeforeBackup { get; set; }
        TimeSpan PeriodToWaitBeforeAlertIfNotCompleted { get; set; }

        bool IsTimeToBackup(IHistoryManager historyManager);
    }
}
