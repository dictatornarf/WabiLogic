using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfRootNameFilter : IRootNameFilter {
        private Guid RootNameFilterId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfRootNameFilter(Guid id, ProxyConnectionManager proxy) {
            this.RootNameFilterId = id;
            this.Proxy = proxy;
        }

        #region IRootNameFilter Members

        public Guid Id {
            get { return this.RootNameFilterId; }
        }

        public string Filter {
            get {
                return this.Proxy.Perform<string>(x => x.RootNameFilterGetFilter(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootNameFilterSetFilter(this.Id, value));
            }
        }

        public FilterType FilterType {
            get {
                return this.Proxy.Perform<FilterType>(x => x.RootNameFilterGetFilterType(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootNameFilterSetFilterType(this.Id, value));
            }
        }

        public string Note {
            get {
                return this.Proxy.Perform<string>(x => x.RootNameFilterGetNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootNameFilterSetNote(this.Id, value));
            }
        }

        #endregion
    }
}
