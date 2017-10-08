using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public enum HistoryStatus {
        Complete,
        Aborted,
        InProgress,
        InError,
        NotStarted
    }
}
