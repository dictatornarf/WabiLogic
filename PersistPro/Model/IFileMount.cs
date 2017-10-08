using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IFileMount : IMount {
        string Folder { get; set; }
    }
}
