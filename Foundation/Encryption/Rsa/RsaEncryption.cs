using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace WabiLogic.Foundation.Encryption.Rsa {
    class RsaEncryption : IEncryption {
        private RSACryptoServiceProvider rsa;

        public RsaEncryption(string rsaXmlKeys) {
            rsa = new RSACryptoServiceProvider(2048);
            rsa.FromXmlString(rsaXmlKeys);
        }

        public static void CreateRsaXmlKeys(out string publicKey, out string bothKeys) {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            bothKeys = rsa.ToXmlString(true);
            publicKey = rsa.ToXmlString(false);
        }

        #region IEncryption Members

        public Stream EncryptStream(Stream streamToEncrypt) {
            byte[] data = new byte[streamToEncrypt.Length];
            streamToEncrypt.Read(data, 0, (int)streamToEncrypt.Length);

            byte[] encryptedData = rsa.Encrypt(data, true);
            return new MemoryStream(encryptedData, false);
        }

        public Stream DecryptStream(Stream streamToDecrypt) {
            byte[] data = new byte[streamToDecrypt.Length];
            streamToDecrypt.Read(data, 0, (int)streamToDecrypt.Length);

            byte[] decryptedData = rsa.Decrypt(data, true);
            return new MemoryStream(decryptedData, false);
        }

        #endregion
    }
}
