using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfExternalDriveMount : IExternalDriveMount {
        private Guid MountId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfExternalDriveMount(Guid id, ProxyConnectionManager proxy) {
            this.MountId = id;
            this.Proxy = proxy;
        }

        public override bool Equals(object obj)
        {
            IExternalDriveMount externalDriveMount = obj as IExternalDriveMount;
            if (externalDriveMount != null && externalDriveMount.Id == this.Id)
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
                return this.Proxy.Perform<string>(x => x.ExternalDriveMountGetFolder(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ExternalDriveMountSetFolder(this.Id, value));
            }
        }

        public string Label {
            get {
                return this.Proxy.Perform<string>(x => x.ExternalDriveMountGetLabel(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.ExternalDriveMountSetLabel(this.Id, value));
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
