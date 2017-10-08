using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WabiLogic.Foundation.Tools;

namespace WabiLogic.Foundation.ProductKey {
    public class KeyManager {
        private static char[] KeyChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '8', '9' };

        public static string GenerateKey(string name, string spice) {

            if (name.Length == 0)
                throw new Exception("Name cannot be empty.");

            if (spice.Length != 4)
                throw new Exception("Spice must be 4 characters long.");

            //Check 
            for (int i = 0; i < spice.Length; i++) {
                if (!KeyChars.Contains(spice[i]))
                    throw new Exception(string.Format("Spice cannot contain invalid character: '{0}'.", spice[i]));
			}

            MemoryStream ms = new MemoryStream();

            //http://www.columbia.edu/kermit/utf8.html
            //Accessed: 2009-02-19
            //"I can eat glass and it doesn't hurt me."
            byte[] pre = Encoding.UTF8.GetBytes("私はガラスを食べられます。それは私を傷つけません。"); // Japanese
            byte[] post = Encoding.UTF8.GetBytes("Μπορῶ νὰ φάω σπασμένα γυαλιὰ χωρὶς νὰ πάθω τίποτα."); // Greek (polytonic)

            ms.Write(pre, 0, pre.Length);
            for (int i = 0; i < name.Length; i++) {
                if (!char.IsWhiteSpace(name[i])) {
                    byte[] data;
                    if (char.IsLetter(name[i]))
                        data = Encoding.UTF8.GetBytes(new char[] { char.ToUpper(name[i]) });
                    else
                        data = Encoding.UTF8.GetBytes(new char[] { name[i] });

                    ms.Write(data, 0, data.Length);
                }
            }
            ms.Write(post, 0, post.Length);

            //Generate MD5 of key
            ms.Position = 0L;
            string md5 = IO.GenerateMD5(ms);

            int pointerValue = 0;

            StringBuilder key = new StringBuilder();
            for (int i = 0; i < md5.Length; i++) {
                pointerValue += ScrambleIntValue(md5[i]) + ScrambleIntValue(spice[i % spice.Length]);
                pointerValue %= KeyChars.Length;

                if (i > 0 && i % 4 == 0)
                    key.Append('-');

                key.Append(KeyChars[pointerValue]);
            }

            return string.Format("{0}-{1}", spice, key);
        }

        public static bool ConfirmKey(string name, string key) {
            return (GenerateKey(name, key.Substring(0, 4)) == key);
        }

        private static int ScrambleIntValue(char c) {
            char toFind = char.ToUpper(c);

            for (int i = 0; i < KeyChars.Length; i++) {
                if (KeyChars[i] == toFind)
                    return i + 1;
            }

            return -1;
        }
    }
}
