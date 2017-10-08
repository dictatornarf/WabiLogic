using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfRoot : IRoot {
        private Guid RootId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfRoot(Guid id, ProxyConnectionManager proxy) {
            this.RootId = id;
            this.Proxy = proxy;
        }

        public override bool Equals(object obj)
        {
            IRoot root = obj as IRoot;
            if (root != null && root.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region IRoot Members

        public Guid Id {
            get { return this.RootId; }
        }

        public string Name {
            get {
                return this.Proxy.Perform<string>(x => x.RootGetName(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootSetName(this.Id, value));
            }
        }

        public string Folder {
            get {
                return this.Proxy.Perform<string>(x => x.RootGetFolder(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootSetFolder(this.Id, value));
            }
        }

        public bool Sub {
            get {
                return this.Proxy.Perform<bool>(x => x.RootGetSub(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootSetSub(this.Id, value));
            }
        }

        public bool KeepHistory {
            get {
                return this.Proxy.Perform<bool>(x => x.RootGetKeepHistory(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootSetKeepHistory(this.Id, value));
            }
        }

        public string Note {
            get {
                return this.Proxy.Perform<string>(x => x.RootGetNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.RootSetNote(this.Id, value));
            }
        }

        public IEnumerable<IRootNameFilter> NameFilters {
            get {
                foreach (Guid id in this.Proxy.Perform<IEnumerable<Guid>>(x => x.RootGetNameFilterIds(this.Id))) {
                    yield return new WcfRootNameFilter(id, this.Proxy);
                }
            }
        }

        public IEnumerable<IRootAttributeFilter> AttributeFilters {
            get {
                foreach (Guid id in this.Proxy.Perform<IEnumerable<Guid>>(x => x.RootGetAttributeFilterIds(this.Id))) {
                    yield return new WcfRootAttributeFilter(id, this.Proxy);
                }
            }
        }

        #endregion
    }
}
