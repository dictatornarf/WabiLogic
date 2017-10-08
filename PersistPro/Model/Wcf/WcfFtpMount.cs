using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WabiLogic.PersistPro.WcfProxy;

namespace WabiLogic.PersistPro.Model.Wcf {
    public class WcfFtpMount : IFtpMount {
        private Guid MountId { get; set; }
        private ProxyConnectionManager Proxy { get; set; }

        public WcfFtpMount(Guid id, ProxyConnectionManager proxy) {
            this.MountId = id;
            this.Proxy = proxy;
        }

        public override bool Equals(object obj)
        {
            IFtpMount ftpMount = obj as IFtpMount;
            if (ftpMount != null && ftpMount.Id == this.Id)
                return true;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        
        #region IFtpMount Members

        public string Server {
            get {
                return this.Proxy.Perform<string>(x => x.FtpMountGetServer(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FtpMountSetServer(this.Id, value));
            }
        }

        public int Port {
            get {
                return this.Proxy.Perform<int>(x => x.FtpMountGetPort(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FtpMountSetPort(this.Id, value));
            }
        }

        public string Username {
            get {
                return this.Proxy.Perform<string>(x => x.FtpMountGetUsername(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FtpMountSetUsername(this.Id, value));
            }
        }

        public string Password {
            get {
                return this.Proxy.Perform<string>(x => x.FtpMountGetPassword(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FtpMountSetPassword(this.Id, value));
            }
        }

        public string Folder {
            get {
                return this.Proxy.Perform<string>(x => x.FtpMountGetFolder(this.Id));
            }
            set {
                this.Proxy.Perform(x => x.FtpMountSetFolder(this.Id, value));
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
