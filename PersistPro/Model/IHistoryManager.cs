using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IHistoryManager {
        IEnumerable<IHistory> Histories { get; }

        IHistory CreateHistory(IPlan plan, HistoryStatus status, DateTime scheduleDate, string note);
        void DeleteHistory(IHistory history);

        IHistory LoadLatestHistory(IPlan plan);
        IEnumerable<IHistory> PlanHistories(IPlan plan);

        IHistory LoadHistory(Guid historyId);
    }
}
