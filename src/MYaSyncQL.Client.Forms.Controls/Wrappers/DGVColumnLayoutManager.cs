using MYaSyncQL.Client.Forms.Controls.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Wrappers {
    public class DGVColumnLayoutManager {

        public DGVColumnLayout[] ColumnLayouts { get; private set; }
        public DGVColumnLayout[] StaticWidthColumns { get; set; }
        public DGVColumnLayout[] DynamicWidthColumns { get; set; }
        public int _totalDynamicWidth;
        private readonly DataGridView _dgv;

        public int TotalStaticWidth { get; }
        public int TotalWidthRemainingForDynamic { get; }
        public int DgvTotalWidth { get; }

        public DGVColumnLayoutManager(DGVColumnLayout[] columns, DataGridView dgv, bool leaveSpaceForScrollBar = true) {
            ColumnLayouts = columns;
            _dgv = dgv;
            StaticWidthColumns = columns.Where(x => !x.IsDynamicWidth).ToArray();
            DynamicWidthColumns = columns.Where(x => x.IsDynamicWidth).ToArray();
            _totalDynamicWidth = DynamicWidthColumns?.Sum(x => x.ColumnWidth) ?? 0;
            DgvTotalWidth = _dgv.Width - 2;
            if (leaveSpaceForScrollBar) {
                DgvTotalWidth -= 23;
            }
            TotalStaticWidth = StaticWidthColumns?.Sum(x => x.ColumnWidth) ?? 0;
            TotalWidthRemainingForDynamic = DgvTotalWidth - TotalStaticWidth;
            GetDynamicWidthRatios();
        }

        protected DGVColumnLayoutManager GetDynamicWidthRatios() {
            foreach (var colLayout in DynamicWidthColumns) {
                // how many percent of the dynamic column width of the total sum of all dynamic column widths
                var ratio = ((float)colLayout.ColumnWidth / (float)_totalDynamicWidth);
                // apply that ratio to the actual remaining width of the data grid view at its current size
                colLayout.CalculatedDynamicWidth = (int)(ratio * TotalWidthRemainingForDynamic);
            }

            return this;
        }

        public void ApplyColumnWidths() {
            var i = 1;
            foreach (var layoutCol in ColumnLayouts) {
                var dgvCol = Array.Find(_dgv.GetVisibleColumns(), x => x.Name == layoutCol.ColumnName);
                if (dgvCol != null) {
                    dgvCol.DisplayIndex = i++;
                    dgvCol.Width = layoutCol.CalculatedDynamicWidth;
                }
            }
        }
    }
}
