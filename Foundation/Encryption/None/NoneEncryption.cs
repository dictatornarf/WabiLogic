using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WabiLogic.Foundation.Encryption.None {
    public class NoneEncryption : IEncryption {
        public NoneEncryption() {
        }

        #region IEncryption Members

        public Stream EncryptStream(Stream inputStream) {
            return inputStream;
        }

        public Stream DecryptStream(Stream outputStream) {
            return outputStream;
        }

        #endregion
    }
}
