using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IRootNameFilter {
        Guid Id { get; }
        string Filter { get; set; }
        FilterType FilterType { get; set; }
        string Note { get; set; }
    }
}
