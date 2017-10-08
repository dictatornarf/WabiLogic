using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;
using WabiLogic.PersistPro.Model.Wcf;
using WabiLogic.PersistPro.Model;
using WabiLogic.Foundation.Encryption.Rijndael;

namespace WabiLogic.PersistPro.Controller.Wcf {
    public class WcfFactory : IFactory {
        private ProxyConnectionManager Proxy { get; set; }

        public WcfFactory() {
            this.Proxy = new ProxyConnectionManager();
        }

        #region IFactory Members

        public IPlanManager LoadPlanManager() {
            return new WcfPlanManager(this.Proxy);
        }

        public void SavePlanManager() {
            this.Proxy.Perform(x => x.SavePlanManager());
        }

        public IHistoryManager LoadHistoryManager() {
            return new WcfHistoryManager(this.Proxy);
        }

        public void SaveHistoryManager() {
            this.Proxy.Perform(x => x.SaveHistoryManager());
        }

        public IConfiguration LoadConfiguration() {
            return new WcfConfiguration(this.Proxy);
        }

        public void SaveConfiguration() {
            this.Proxy.Perform(x => x.SaveConfiguration());
        }

        public WabiLogic.Foundation.Encryption.IEncryption LoadEncryption() {
            string password = LoadConfiguration()["password"];
            if (password == null) throw new Exception("Password needed. Please run setup.");
            return new RijndaelEncryption(password);
        }

        public void SaveEncryptionPassword(string password) {
            this.Proxy.Perform(x => x.ConfigurationSaveEncryptionPassword(password));
        }

        public void Register(string name, string key) {
            this.Proxy.Perform(x => x.ConfigurationRegister(name, key));
        }

        public bool IsRegistered {
            get {
                return this.Proxy.Perform<bool>(x => x.ConfigurationIsRegistered());
            }
        }

        public bool RunSetup {
            get {
                return this.Proxy.Perform<bool>(x => x.ConfigurationGetRunSetup());
            }
            set {
                this.Proxy.Perform(x => x.ConfigurationSetRunSetup(value));
            }
        }

        #endregion
    }
}
