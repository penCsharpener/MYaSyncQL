using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.Forms {
    public class ViewModelDBConnections : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ConnectionString> DbConnections { get; set; } = new List<ConnectionString>();

        public ViewModelDBConnections() {
            DbConnections = StaticElements.Settings.Local.ConnectionStrings;
        }

        #region Bound Properties

        public string NewConnectionName { get; set; }
        public string NewServerURL { get; set; } = "localhost";
        public ushort NewPort { get; set; } = 3306;
        public string NewUsername { get; set; }
        public string NewDatabaseName { get; set; }

        #endregion

        #region Events

        public event EventHandler DatasourceChanged;
        protected virtual void OnDatasourceChanged() {
            DatasourceChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        public void AddConnection() {
            var newConn = new ConnectionString(NewServerURL, NewUsername, null, NewPort, NewDatabaseName) {
                ConnectionName = NewConnectionName,
            };
            StaticElements.Settings.Local.ConnectionStrings.Add(newConn);
            StaticElements.Settings.SaveSettings();
            DbConnections.Add(newConn);
            OnDatasourceChanged();
        }

        #endregion
    }
}
