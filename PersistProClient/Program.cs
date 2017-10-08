using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PersistProClient {
    static class Program {
        private static Mutex PersistProStartup { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool instantiated;
            Program.PersistProStartup = new Mutex(false, "Local\\PersistProStartup", out instantiated);
            if (instantiated) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PersistPro());
            }
        }
    }
}
