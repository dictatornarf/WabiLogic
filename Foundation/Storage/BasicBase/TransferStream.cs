using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WabiLogic.Foundation.Storage.BasicBase {
    public class TransferStream : Stream {
        private Stream stream;
        private BasicManager manager;
        private string identifier;
        private long streamLength;
        private long currentPosition;

        public TransferStream(BasicManager manager, Stream stream, string identifier, long streamLength) {
            this.manager = manager;
            this.stream = stream;
            this.identifier = identifier;
            this.streamLength = streamLength;
            this.currentPosition = 0;

            this.manager.SendTransferBegin(new TransferBeginEventArgs(identifier));
        }

        public override void Close() {
            stream.Close();
            manager.SendTransferEnd(new TransferEndEventArgs(identifier));
        }

        public override bool CanRead {
            get { return stream.CanRead; }
        }

        public override bool CanSeek {
            get { return stream.CanSeek; }
        }

        public override bool CanWrite {
            get { return stream.CanWrite; }
        }

        public override void Flush() {
            stream.Flush();
        }

        public override long Length {
            get { return stream.Length; }
        }

        public override long Position {
            get {
                return stream.Position;
            }
            set {
                stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count) {
            int amount = stream.Read(buffer, offset, count);
            this.currentPosition += amount;
            this.manager.SendTransferUpdate(new TransferUpdateEventArgs(identifier, currentPosition, streamLength));
            return amount;
        }

        public override long Seek(long offset, SeekOrigin origin) {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value) {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count) {
            this.currentPosition += count;
            stream.Write(buffer, offset, count);
            this.manager.SendTransferUpdate(new TransferUpdateEventArgs(identifier, currentPosition, streamLength));
        }
    }
}
