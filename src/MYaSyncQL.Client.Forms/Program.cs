using MYaSyncQL.Client.Forms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms {
    static class Program {
        public static MainForm mainform;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StaticElements.Settings.LoadSettings();
            mainform = new MainForm();
            Application.Run(new MainForm());
        }
    }
}
