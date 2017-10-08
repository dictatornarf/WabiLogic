using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public class UnknownVersionException : Exception {
        public UnknownVersionException() { }
        public UnknownVersionException(string message) : base(message) { }
        public UnknownVersionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
