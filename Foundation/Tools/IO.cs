using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WabiLogic.Foundation.Tools {
    public delegate void StreamWriteStatus(long currentPosition, long size);

    public static class IO {
        public static void WriteStream(Stream input, Stream output, StreamWriteStatus status, long size) {
            byte[] buffer = new byte[4096];
            int lengthRead;
            long currentPosition = 0L;

            while ((lengthRead = input.Read(buffer, 0, buffer.Length)) > 0) {
                output.Write(buffer, 0, lengthRead);
                if (status != null) {
                    currentPosition += lengthRead;
                    status(currentPosition, size);
                }
            }
        }

        public static void WriteStream(Stream input, Stream output) {
            byte[] buffer = new byte[4096];
            int lengthRead;

            while ((lengthRead = input.Read(buffer, 0, buffer.Length)) > 0) {
                output.Write(buffer, 0, lengthRead);
            }
        }

        public static string GenerateMD5(Stream inputStream) {
            MD5 md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(inputStream)).Replace("-", ""); 
        }

        public static string GenerateMD5(string filename) {
            using (Stream inputStream = File.OpenRead(filename)) {
                return GenerateMD5(inputStream);
            }
        }

        public static void AtomicFileWrite(string filename, Stream output) {
            string tempFilename = Path.GetTempFileName();
            using (Stream tempOutput = File.OpenWrite(tempFilename)) {
                IO.WriteStream(output, tempOutput);
            }

            string atomicFilename = filename + "_Atomic";
            if (File.Exists(atomicFilename))
                File.Delete(atomicFilename);

            if (File.Exists(filename))
                File.Move(filename, atomicFilename);

            File.Move(tempFilename, filename);
            
            if (File.Exists(atomicFilename))
                File.Delete(atomicFilename);
        }

        //public static void VersionFileWrite(string filename, int versionsToKeep) {

        //}
    }
}
