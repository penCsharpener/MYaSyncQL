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
            dgvTables.CurrentChanged += (s, e) => vm.SelectedTable = e;
            vm.SelectedTableChanged += async (s, e) => await vm.GenerateClassCode();
            InitBindings();
        }

        private void InitBindings() {
            txtClassCode.DataBindings.Add(nameof(txtClassCode.Text), vm, nameof(vm.ClassCode), true, DataSourceUpdateMode.OnPropertyChanged);
            txtNamespace.DataBindings.Add(nameof(txtNamespace.Text), vm, nameof(vm.Namespace), true, DataSourceUpdateMode.OnPropertyChanged);
            chkFullyAsyncReading.DataBindings.Add(nameof(chkFullyAsyncReading.Checked), vm, nameof(vm.FullyAsyncReading), true, DataSourceUpdateMode.OnPropertyChanged);
            chkIncludeAttributes.DataBindings.Add(nameof(chkIncludeAttributes.Checked), vm, nameof(vm.IncludeAttributes), true, DataSourceUpdateMode.OnPropertyChanged);
            chkUseNullableRefTypes.DataBindings.Add(nameof(chkUseNullableRefTypes.Checked), vm, nameof(vm.NullableRefTypes), true, DataSourceUpdateMode.OnPropertyChanged);

            vm.SelectedTable = dgvTables.CurrentlySelected;
        }
    }
}
