using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IRoot {
        Guid Id { get; }
        string Name { get; set; }
        string Folder { get; set; }
        bool Sub { get; set; }
        bool KeepHistory { get; set; }
        string Note { get; set; }

        IEnumerable<IRootNameFilter> NameFilters { get; }
        IEnumerable<IRootAttributeFilter> AttributeFilters { get; }
    }
}
