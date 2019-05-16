using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.Client.Forms.Controls.Wrappers;
using MYaSyncQL.Client.Forms.UserControls;
using MYaSyncQL.InfoSchema;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            btnOpenTargetFolder.Click += (s, e) => {
                using (var fbd = new FolderBrowserDialog()) {
                    fbd.RootFolder = Environment.SpecialFolder.UserProfile;
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                        vm.TargetPath = fbd.SelectedPath;
                    }
                }
            };
            dgvTables.SelectionChanged += (s, e) => vm.SelectedTables = e.ToList();
            btnSaveClasses.Click += async (s, e) => await vm.SaveClasses();
            InitBindings();
        }

        private void InitBindings() {
            txtClassCode.DataBindings.Add(nameof(txtClassCode.Text), vm, nameof(vm.ClassCode), true, DataSourceUpdateMode.OnPropertyChanged);
            txtNamespace.DataBindings.Add(nameof(txtNamespace.Text), vm, nameof(vm.Namespace), true, DataSourceUpdateMode.OnPropertyChanged);
            chkFullyAsyncReading.DataBindings.Add(nameof(chkFullyAsyncReading.Checked), vm, nameof(vm.FullyAsyncReading), true, DataSourceUpdateMode.OnPropertyChanged);
            chkIncludeAttributes.DataBindings.Add(nameof(chkIncludeAttributes.Checked), vm, nameof(vm.IncludeAttributes), true, DataSourceUpdateMode.OnPropertyChanged);
            chkUseNullableRefTypes.DataBindings.Add(nameof(chkUseNullableRefTypes.Checked), vm, nameof(vm.NullableRefTypes), true, DataSourceUpdateMode.OnPropertyChanged);
            txtTargetPath.DataBindings.Add(nameof(txtTargetPath.Text), vm, nameof(vm.TargetPath), true, DataSourceUpdateMode.OnPropertyChanged);

            vm.SelectedTable = dgvTables.CurrentlySelected;
        }
    }
}
