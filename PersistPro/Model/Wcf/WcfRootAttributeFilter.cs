using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfRootAttributeFilter : IRootAttributeFilter {
        private Guid RootAttributeFilterId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfRootAttributeFilter(Guid id, ProxyConnectionManager proxy) {
            this.RootAttributeFilterId = id;
            this.Proxy = proxy;
        }

        #region IRootAttributeFilter Members

        public Guid Id {
            get { return this.RootAttributeFilterId; }
        }

        public System.IO.FileAttributes Filter {
            get {
                return this.Proxy.Perform<System.IO.FileAttributes>(x => x.RootAttributeFilterGetFilter(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootAttributeFilterSetFilter(this.Id, value));
            }
        }

        public FilterType FilterType {
            get {
                return this.Proxy.Perform<FilterType>(x => x.RootAttributeFilterGetFilterType(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootAttributeFilterSetFilterType(this.Id, value));
            }
        }

        public string Note {
            get {
                return this.Proxy.Perform<string>(x => x.RootAttributeFilterGetNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootAttributeFilterSetNote(this.Id, value));
            }
        }

        #endregion
    }
}
