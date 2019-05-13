using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.Client.Forms.Controls.Wrappers;
using MYaSyncQL.InfoSchema;

namespace MYaSyncQL.Client.Forms.Controls {
    public partial class UCClassBuilder : UserControl {

        private DGVEnhancer<Table> dgvTables;

        public UCClassBuilder() {
            InitializeComponent();
            Load += LoadEvent;
        }

        private void LoadEvent(object sender, EventArgs e) {
            dgvTables = new DGVEnhancer<Table>(dataTables);
        }

        private async Task InitControls() {

        }

        private async Task InitHandlers() {
            Program.mainform.ConnectionChanged += (s, e) => {

            };
        }

        private void InitBindings() {

        }
    }
}
