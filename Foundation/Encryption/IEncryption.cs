using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.Foundation.Encryption {
    public interface IEncryption {
        Stream EncryptStream(Stream streamToEncrypt);
        Stream DecryptStream(Stream streamToDecrypt);
    }
}
