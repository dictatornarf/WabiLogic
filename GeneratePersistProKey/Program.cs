using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace GeneratePersistProKey {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Test();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenerateKey());
        }

        static void Test() {
            WebRequest req = HttpWebRequest.Create(@"http://www.becstudios.com/export.php");
      
            string boundary = string.Format("PersistPro{0}", Guid.NewGuid().ToString("N"));
            req.ContentType = "multipart/form-data; boundary=" + boundary;
            req.Method = "POST";

            MemoryStream postData = new MemoryStream();
            string newLine = "\r\n";
            StreamWriter sw = new StreamWriter(postData);

            sw.Write("--" + boundary + newLine);
            sw.Write("Content-Disposition: form-data; name=\"{0}\"{1}{1}{2}{1}",
                "name",
                newLine,
                "Ben Carden"
            );

            //sw.Write("--{0}--{1}", boundary, newLine);
            //sw.Flush();

            sw.Write("--" + boundary + newLine);
            sw.Write("Content-Disposition: form-data; name=\"{0}\"{1}{1}{2}{1}",
                "key",
                newLine,
                "BABE-HEMY-YTPW-Z98F-EHT5-66BG-HFGR-Y343-Z5CH"
            );

            //sw.Write("--{0}--{1}", boundary, newLine);
            //sw.Flush();

            string filename = @"C:\Users\carden\Desktop\BackupTestSpot\storage.bds";
            byte[] data = File.ReadAllBytes(filename);
            //writer.WriteLine("Content-Disposition: form-data; name=\"FileUpload1\"; filename=\"" + path + "\"");
            //writer.WriteLine("Content-Type: application/binary");
            //writer.WriteLine("Content-Transfer-Encoding: binary");
            sw.Write("--" + boundary + newLine);
            sw.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}",
                "file",
                filename,
                newLine
            );
            sw.Write("Content-Type: application/octet-stream" + newLine);
            sw.Write("Content-Transfer-Encoding: binary" + newLine);
            sw.Write("Content-Length: " + data.Length + newLine);
            sw.Write(newLine);
            sw.Flush();

            postData.Write(data, 0, data.Length);
            sw.Write(newLine);

            sw.Write("--{0}--{1}", boundary, newLine);
            sw.Flush();

            req.ContentLength = postData.Length;
            using (Stream s = req.GetRequestStream())
                postData.WriteTo(s);
            postData.Close();

            WebResponse res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string answer = sr.ReadToEnd();
            sr.Close();
        }
    }
}
