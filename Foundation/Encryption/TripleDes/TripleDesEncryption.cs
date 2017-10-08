using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WabiLogic.Foundation.Encryption.TripleDes {
    public class TripleDesEncryption : IEncryption {
        private ICryptoTransform encryptor;
        private ICryptoTransform decryptor;

        public TripleDesEncryption(string password) {
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Padding = PaddingMode.PKCS7;

            //Create recreatable salt based on password but looks like junk
            byte[] salt = new byte[16];
            for (int i = 0; i < salt.Length; i++) {
                byte[] dump = Encoding.Unicode.GetBytes(password.Substring(i % password.Length));
                for (int j = 0; j < dump.Length; j++) {
                    salt[i] ^= dump[j];
                }
            }
            // Create a encryptor from the existing SecretKey bytes.
            // We use 32 bytes for the secret key
            // (the default Rijndael key length is 256 bit = 32 bytes) and
            // then 16 bytes for the IV (initialization vector),
            // (the default Rijndael IV length is 128 bit = 16 bytes)
            Rfc2898DeriveBytes secretKey = new Rfc2898DeriveBytes(password, salt);
            byte[] key = secretKey.GetBytes(32);
            byte[] iv = secretKey.GetBytes(16);

            encryptor = tripleDES.CreateEncryptor(key, iv);
            decryptor = tripleDES.CreateDecryptor(key, iv);
        }

        #region IEncryption Members

        public Stream EncryptStream(Stream streamToEncrypt) {
            return new CryptoStream(streamToEncrypt, encryptor, CryptoStreamMode.Write);
        }

        public Stream DecryptStream(Stream streamToDecrypt) {
            return new CryptoStream(streamToDecrypt, decryptor, CryptoStreamMode.Read);
        }

        #endregion
    }
}
