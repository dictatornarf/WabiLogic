using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IHistory {
        Guid Id { get; }
        HistoryStatus Status { get; set; }
        DateTime ScheduleDate { get; set; }
        DateTime ExecuteDate { get; set; }
        DateTime BeginBackupDate { get; set; }
        DateTime FinishBackupDate { get; set; }
        string ErrorNote { get; set; }
        string Note { get; set; }
    }
}
