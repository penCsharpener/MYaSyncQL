using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Extensions {
    public static class DgvExtensions {
        public static DataGridViewColumn[] GetColumns(this DataGridView dgv) {
            return dgv.Columns.Cast<DataGridViewColumn>().ToArray();
        }

        public static DataGridViewColumn[] GetVisibleColumns(this DataGridView dgv) {
            return dgv.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible).ToArray();
        }
    }
}
