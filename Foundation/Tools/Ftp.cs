using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WabiLogic.Foundation.Tools {
    public static class Ftp {
        public static Uri BuildUri(string host, int port) {
            return new Uri(string.Format("ftp://{0}:{1}/", host, port));
        }

        public static Uri BuildUri(string host, int port, string relativePath) {
            return new Uri(BuildUri(host, port), relativePath);
        }

        public static Uri Combine(Uri baseUri, string relativePath) {
            if (baseUri.AbsoluteUri.EndsWith("/"))
                return new Uri(baseUri.AbsoluteUri + relativePath);
            else
                return new Uri(baseUri.AbsoluteUri + "/" + relativePath);
        }

        public static Stream RetrieveFile(Uri address, ICredentials credentials) {
            WebClient wc = new WebClient();
            wc.Credentials = credentials;
            return wc.OpenRead(address);
        }

        public static Stream UploadFile(Uri address, ICredentials credentials) {
            WebClient wc = new WebClient();
            wc.Credentials = credentials;
            return wc.OpenWrite(address);
        }

        public static string[] DirectoryList(Uri address, ICredentials credentials) {
            string[] toReturn = null;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);

            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = credentials;
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                    toReturn = sr.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            return toReturn;
        }

        public static void DeleteFile(Uri address, ICredentials credentials) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = credentials;
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                //Do nothing
            }
        }

        public static long FileSize(Uri address, ICredentials credentials) {
            long size = 0L;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = credentials;
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                if (!long.TryParse(response.StatusDescription.Substring(4), out size))
                    throw new WebException(response.StatusDescription);
            }

            return size;
        }

        public static void Rename(Uri address, ICredentials credentials, string newFilename) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newFilename;
            request.Credentials = credentials;
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                //Do nothing?
            }
        }

        public static void CreateDirectory(Uri address, ICredentials credentials) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = credentials;
            request.KeepAlive = true;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                //Do nothing?
            }
        }
    }
}
