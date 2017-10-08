using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OnlineBackupUtility.Root {
    public interface IAttributeFilter {
        FileAttributes Filter { get; set; }
        FilterType FilterType { get; set; }
        string Note { get; set; }
    }
}
