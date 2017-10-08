using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IPlan {
        Guid Id { get; }
        IRoot Root { get; set; }
        IMount Mount { get; set; }
        ISchedule Schedule { get; set; }
    }
}
