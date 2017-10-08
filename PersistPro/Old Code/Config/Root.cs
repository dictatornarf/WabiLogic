using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBackupUtility.Config {
    public class Root {
        private string name;
        private string path;
        private bool encrypt;

        public Root() { }

        public Root(string name, string path, bool encrypt) {
            this.name = name;
            this.path = path;
            this.encrypt = encrypt;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
        
        public string Path {
            get { return path; }
            set { path = value; }
        }

        public bool Encrypt {
            get { return encrypt; }
            set { encrypt = value; }
        }
    }
}
