using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Model {
    public interface IFtpMount : IMount {
        string Server { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Folder { get; set; }
    }
}
