using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Encryption {
    public class EncryptionNotSupportedException : ApplicationException {
        public EncryptionNotSupportedException() : base() { }

        public EncryptionNotSupportedException(string message) : base(message) { }
    }
}
