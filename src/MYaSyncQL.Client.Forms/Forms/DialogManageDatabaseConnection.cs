using MYaSyncQL.Client.Forms.Controls.Wrappers;
using MYaSyncQL.Utils;
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
            dgvConnections.SetColumnLayout(new [] {
                new DGVColumnLayout(nameof(ConnectionString.ConnectionName), "Name", 160, false, false),
                new DGVColumnLayout(nameof(ConnectionString.Server), "Server Address", 160, true, false),
                new DGVColumnLayout(nameof(ConnectionString.User), "Username", 160, false, false),
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

            InitBindings();
        }

        private void InitBindings() {
            txtConnectionName.DataBindings.Add(nameof(txtConnectionName.Text), vm, nameof(vm.NewConnectionName), true, DataSourceUpdateMode.OnPropertyChanged);
            txtServerURL.DataBindings.Add(nameof(txtServerURL.Text), vm, nameof(vm.NewServerURL), true, DataSourceUpdateMode.OnPropertyChanged);
            numPort.DataBindings.Add(nameof(numPort.Value), vm, nameof(vm.NewPort), true, DataSourceUpdateMode.OnPropertyChanged);
            txtUsername.DataBindings.Add(nameof(txtUsername.Text), vm, nameof(vm.NewUsername), true, DataSourceUpdateMode.OnPropertyChanged);
            txtDatabaseName.DataBindings.Add(nameof(txtDatabaseName.Text), vm, nameof(vm.NewDatabaseName), true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
