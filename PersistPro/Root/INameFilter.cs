using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Root {
    public enum FilterType {
        Include,
        Exclude
    }

    public interface INameFilter {
        string Filter { get; set; }
        FilterType FilterType { get; set; }
        string Note { get; set; }
    }
}
