using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Wrappers {
    public class DGVColumnLayout {

        public DGVColumnLayout(string columnName, string headerName, int columnWidth, bool isDynamicWidth, bool readOnly) {
            ColumnName = columnName;
            HeaderName = string.IsNullOrEmpty(headerName) ? ColumnName : headerName;
            IsDynamicWidth = isDynamicWidth;
            ColumnWidth = CalculatedDynamicWidth = columnWidth;
            ReadOnly = readOnly;
        }

        public DGVColumnLayout(DataGridViewColumn dgvCustomColumn, int columnWidth, bool isDynamicWidth, bool readOnly) {
            ColumnName = dgvCustomColumn.Name;
            HeaderName = string.IsNullOrEmpty(dgvCustomColumn.HeaderText) ? dgvCustomColumn.Name : dgvCustomColumn.HeaderText;
            DGVCustomColumn = dgvCustomColumn;
            IsDynamicWidth = isDynamicWidth;
            ColumnWidth = CalculatedDynamicWidth = columnWidth;
            ReadOnly = readOnly;
        }

        public string ColumnName { get; set; }
        public string HeaderName { get; set; }
        public int ColumnWidth { get; set; }
        public bool IsDynamicWidth { get; set; }
        public DataGridViewColumn DGVCustomColumn { get; set; }
        internal int CalculatedDynamicWidth { get; set; }
        public bool ReadOnly { get; }

        public override string ToString() {
            return $"{ColumnName} {ColumnWidth}{(IsDynamicWidth ? " dynamic" : "")}";
        }
    }
}
