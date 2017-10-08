using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.Foundation.Encryption;

namespace WabiLogic.PersistPro.Model {
    public interface IMount {
        Guid Id { get; }
        string Name { get; set; }
        string Note { get; set; }
        string TypeDisplayName { get; }
    }
}
