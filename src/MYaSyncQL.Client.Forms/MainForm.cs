using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.Client.Forms.Controls;
using MYaSyncQL.Client.Forms.Controls.Extensions;
using MYaSyncQL.Client.Forms.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.Size = new Size(1920, 1080);
            panelMain.AddControl(new UCClassBuilder());
            if (StaticElements.DB == null) {
                ManageDatabaseConnetionsToolStripMenuItem_Click(null, null);
            }
        }

        private void ManageDatabaseConnetionsToolStripMenuItem_Click(object sender, EventArgs e) {
            var dlg = new DialogManageDatabaseConnection();
            dlg.ShowDialog();
            if (StaticElements.DB != null) OnConnectionChanged();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            StaticElements.Settings.SaveSettings();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e) {
            StaticElements.Settings.LoadSettings();
        }

        public event EventHandler ConnectionChanged;
        protected virtual void OnConnectionChanged() {
            panelMain.AddControl(new UCClassBuilder());
            ConnectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
