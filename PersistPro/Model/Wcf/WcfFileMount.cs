using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfFileMount : IFileMount {
        private Guid MountId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfFileMount(Guid id, ProxyConnectionManager proxy) {
            this.MountId = id;
            this.Proxy = proxy;
        }

        public override bool Equals(object obj)
        {
            IFileMount fileMount = obj as IFileMount;
            if (fileMount != null && fileMount.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region IFileMount Members

        public string Folder {
            get {
                return this.Proxy.Perform<string>(x => x.FileMountGetFolder(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FileMountSetFolder(this.Id, value));
            }
        }

        #endregion

        #region IMount Members

        public Guid Id {
            get { return this.MountId; }
        }

        public string Name {
            get {
                return this.Proxy.Perform<string>(x => x.MountGetName(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.MountSetName(this.Id, value));
            }
        }

        public string Note {
            get {
                return this.Proxy.Perform<string>(x => x.MountGetNote(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.MountSetNote(this.Id, value));
            }
        }

        public string TypeDisplayName {
            get {
                return this.Proxy.Perform<string>(x => x.MountGetTypeDisplayName(this.Id));
            }
        }

        #endregion
    }
}
