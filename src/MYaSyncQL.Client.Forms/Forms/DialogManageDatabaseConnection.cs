using MYaSyncQL.Client.Forms.Controls.Wrappers;
using MYaSyncQL.Utils;
using System;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Forms {
    public partial class DialogManageDatabaseConnection : Form {

        private ViewModelDBConnections vm;
        private DGVEnhancer<ConnectionString> dgvConnections;

        public DialogManageDatabaseConnection() {
            InitializeComponent();
            Load += LoadEvent;
        }

        private void LoadEvent(object sender, EventArgs e) {
            InitControls();
        }

        private void InitControls() {
            vm = new ViewModelDBConnections();
            dgvConnections = new DGVEnhancer<ConnectionString>(dataConnections);
            dgvConnections.UpdateDatasource(vm.DbConnections);
            var buttonColumn = new DataGridViewButtonColumn() {
                Text = "Connect",
                Name = "ConnectColumn",
                HeaderText = "Connect",
                Visible = true,
                UseColumnTextForButtonValue = true,
            };
            dgvConnections.SetColumnLayout(new [] {
                new DGVColumnLayout(nameof(ConnectionString.ConnectionName), "Name", 70, true, false),
                new DGVColumnLayout(nameof(ConnectionString.Server), "Server Address", 50, true, false),
                new DGVColumnLayout(nameof(ConnectionString.User), "Username", 50, true, false),
                new DGVColumnLayout(nameof(ConnectionString.Port), null, 60, false, false),
                new DGVColumnLayout(nameof(ConnectionString.Database), null, 50, true, false),
                new DGVColumnLayout(buttonColumn, 70, false, false),
            });
            InitHandlers();
        }

        private void InitHandlers() {
            btnAddConnection.Click += (s, e) => {
                vm.AddConnection();
            };
            vm.DatasourceChanged += (s, e) => {
                dgvConnections.UpdateDatasource(vm.DbConnections);
            };
            dataConnections.CellMouseClick += (s, e) => {
                if (dataConnections.Columns[e.ColumnIndex].Name == "ConnectColumn") {
                    if (dataConnections.Rows[e.RowIndex].DataBoundItem is ConnectionString cs) {
                        vm.ConnectToDb(cs);
                    }
                }
            };

            InitBindings();
        }

        private void InitBindings() {
            txtConnectionName.DataBindings.Add(nameof(txtConnectionName.Text), vm, nameof(vm.NewConnectionName), true, DataSourceUpdateMode.OnPropertyChanged);
            txtServerURL.DataBindings.Add(nameof(txtServerURL.Text), vm, nameof(vm.NewServerURL), true, DataSourceUpdateMode.OnPropertyChanged);
            numPort.DataBindings.Add(nameof(numPort.Value), vm, nameof(vm.NewPort), true, DataSourceUpdateMode.OnPropertyChanged);
            txtUsername.DataBindings.Add(nameof(txtUsername.Text), vm, nameof(vm.NewUsername), true, DataSourceUpdateMode.OnPropertyChanged);
            txtDatabaseName.DataBindings.Add(nameof(txtDatabaseName.Text), vm, nameof(vm.NewDatabaseName), true, DataSourceUpdateMode.OnPropertyChanged);
            lblDatabaseConnectionName.DataBindings.Add(nameof(lblDatabaseConnectionName.Text), vm, nameof(vm.HeaderConnection), true, DataSourceUpdateMode.OnPropertyChanged);

        }
    }
}
