using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Controller.Wcf {
    public class WcfConfiguration : IConfiguration {
        private ProxyConnectionManager Proxy { get; set; }

        public WcfConfiguration(ProxyConnectionManager proxy) {
            this.Proxy = proxy;
        }

        #region IConfiguration Members

        public string this[string key] {
            get {
                return this.Proxy.Perform<string>(x => x.ConfigurationGetValue(key));
            }
            set {
                this.Proxy.Perform(x => x.ConfigurationSetValue(key, value));
            }
        }

        public IEnumerable<string> Keys {
            get {
                return this.Proxy.Perform<IEnumerable<string>>(x => x.ConfigurationGetKeys());
            }
        }

        public void Add(string key, string value) {
            this.Proxy.Perform(x => x.ConfigurationAddKey(key, value));
        }

        public void Remove(string key) {
            this.Proxy.Perform(x => x.ConfigurationRemoveKey(key));
        }

        #endregion
    }
}
