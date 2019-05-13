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
using MYaSyncQL.Client.Forms.UserControls;

namespace MYaSyncQL.Client.Forms.Controls {
    public partial class UCClassBuilder : UserControl {

        private DGVEnhancer<Table> dgvTables;
        private ViewModelClassBuilder vm;

        public UCClassBuilder() {
            InitializeComponent();
            Load += LoadEvent;
        }

        private async void LoadEvent(object sender, EventArgs e) {
            await InitControls();
        }

        private async Task InitControls() {
            if (StaticElements.DB == null) return;
            vm = new ViewModelClassBuilder();

            dgvTables = new DGVEnhancer<Table>(dataTables);
            dgvTables.UpdateDatasource(await vm.GetTables());
            dgvTables.SetColumnLayout(new[] {
                new DGVColumnLayout(nameof(Table.FullName), "Name", 100, true, true)
            });
            InitHandlers();
        }

        private void InitHandlers() {

            InitBindings();
        }

        private void InitBindings() {

        }
    }
}
