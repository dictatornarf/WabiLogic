using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using OnlineBackupUtility.Encryption;
using OnlineBackupUtility.Storage;

namespace OnlineBackupUtility.Config {
    public class ConfigManager {
        private string storageType;
        private string storageKey;
        private string encryptionType;
        private string encryptionKey;
        private List<Root> roots;

        private static ConfigManager singleton = new ConfigManager();

        public static ConfigManager Create() {
            return singleton;
        }

        private ConfigManager() {
            roots = new List<Root>();

            string configFile = ConfigurationManager.AppSettings["configFile"];
            XElement xConfig = XElement.Load(configFile);

            var data = (from c in xConfig.DescendantsAndSelf("backup")
                        select new { storageType = c.Attribute("storageType").Value, storageKey = c.Attribute("storageKey").Value, encryptionType = c.Attribute("encryptionType").Value, encryptionKey = c.Attribute("encryptionKey").Value }).SingleOrDefault();
            storageType = data.storageType;
            storageKey = data.storageKey;
            encryptionType = data.encryptionType;
            encryptionKey = data.encryptionKey;

            var xRoots = from c in xConfig.Descendants("root")
                        select new { name = c.Attribute("name").Value, path = c.Attribute("path").Value, encrypt = Convert.ToBoolean(c.Attribute("encrypt").Value) };

            foreach (var xRoot in xRoots) {
                roots.Add(new Root(xRoot.name, xRoot.path, xRoot.encrypt));
            }
        }

        public string StorageType {
            get { return storageType; }
            set { storageType = value; }
        }

        public string StorageKey {
            get { return storageKey; }
            set { storageKey = value; }
        }

        public string EncryptionKey {
            get { return encryptionKey; }
            set { encryptionKey = value; }
        }

        public string EncryptionType {
            get { return encryptionType; }
            set { encryptionType = value; }
        }

        public List<Root> Roots {
            get { return roots; }
        }

        public IEncryption GetEncryption() {
            IEncryption toReturn = null;

            /*
            if (this.EncryptionType == "Rijndael")
                toReturn = new RijndaelEncryption(this.EncryptionKey);
            else if (this.EncryptionType == "Rsa")
                toReturn = new RsaEncryption(this.EncryptionKey);
            else if (this.EncryptionType == "None")
                toReturn = new NoneEncryption();
            else
                throw new EncryptionNotSupportedException(string.Format("Encryption not supported: '{0}'.", this.EncryptionType));
            */

            return toReturn;
        }

        public IStorage GetStorage() {
            IStorage toReturn = null;

            if (this.StorageType == "File")
                toReturn = new FileStorage(this.StorageKey);
            else
                throw new StorageNotSupportedException(string.Format("Storage not supported: '{0}'.", this.StorageType));

            return toReturn;
        }
    }
}
