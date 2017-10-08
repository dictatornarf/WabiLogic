using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.PersistPro.Model {
    public interface IRootAttributeFilter {
        Guid Id { get; }
        FileAttributes Filter { get; set; }
        FilterType FilterType { get; set; }
        string Note { get; set; }
    }
}
