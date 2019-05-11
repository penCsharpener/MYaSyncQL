using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.Common {
    class ConnectionManager {

        public ConnectionManager() {

        }

        public event EventHandler DatabaseServerChanged;
        protected virtual void OnDatabaseServerChanged() {
            DatabaseServerChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
