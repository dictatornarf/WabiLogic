using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiLogic.Foundation.Storage {
    public delegate void TransferBeginHandler(object source, TransferBeginEventArgs args);
    public delegate void TransferUpdateHandler(object source, TransferUpdateEventArgs args);
    public delegate void TransferEndHandler(object source, TransferEndEventArgs args);

    public class TransferBeginEventArgs {
        private string identifier;

        public TransferBeginEventArgs(string identifier) {
            this.identifier = identifier;
        }

        public string Identifier {
            get { return identifier; }
        }
    }

    public class TransferUpdateEventArgs {
        private string identifier;
        private long currentPosition;
        private long length;

        public TransferUpdateEventArgs(string identifier, long currentPosition, long length) {
            this.identifier = identifier;
            this.currentPosition = currentPosition;
            this.length = length;
        }

        public string Identifier {
            get { return identifier; }
        }

        public long CurrentPosition {
            get { return currentPosition; }
        }

        public long Length {
            get { return length; }
        }
    }

    public class TransferEndEventArgs {
        private string identifier;

        public TransferEndEventArgs(string identifier) {
            this.identifier = identifier;
        }

        public string Identifier {
            get { return identifier; }
        }
    }
}
