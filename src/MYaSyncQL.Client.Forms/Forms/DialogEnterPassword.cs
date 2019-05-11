using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Forms {
    public partial class DialogEnterPassword : Form {

        public string EnteredPassword { get; set; }

        public DialogEnterPassword() {
            InitializeComponent();
            Load += LoadEvent;
        }

        private void LoadEvent(object sender, EventArgs e) {
            lnkRevealPwd.Click += (s, e) => {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            };
            this.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    EnteredPassword = txtPassword.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }
    }
}
