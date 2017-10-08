using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.PersistPro.Controller {
    public interface IConfiguration {
        string this[string key] { get; set; }
        IEnumerable<string> Keys { get; }
        void Add(string key, string value);
        void Remove(string key);
    }
}
