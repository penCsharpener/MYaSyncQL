using MYaSyncQL.Client.Forms.Controls;
using MYaSyncQL.Client.Forms.Controls.Extensions;
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
        }
    }
}
