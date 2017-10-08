using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IExternalDriveMount : IMount {
        string Folder { get; set; }
        string Label { get; set; }
    }
}
