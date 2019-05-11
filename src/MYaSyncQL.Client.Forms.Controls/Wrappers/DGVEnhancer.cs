using MYaSyncQL.Client.Forms.Controls.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYaSyncQL.Client.Forms.Controls.Wrappers {
    public class DGVEnhancer<T> where T : class {

        public DataGridView Dgv { get; }
        public BindingSource BindingSource { get; }
        public DataGridViewColumn[] DgvColumns => Dgv.GetColumns();
        public DGVColumnLayout[] ColumnLayouts { private set; get; }

        public DGVEnhancer(DataGridView dgv) {
            Dgv = dgv;
            BindingSource = new BindingSource();
            dgv.DataSource = BindingSource;

            dgv.DoubleBuffered();
            dgv.AutoGenerateColumns = true;
            dgv.MultiSelect = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = Color.FromArgb(222, 255, 170);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.YellowGreen;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.DefaultCellStyle = dataGridViewCellStyle2;

            BindingSource.CurrentChanged += BindingSource_CurrentChanged;
            dgv.Resize += (s, e) => {
                try {
                    new DGVColumnLayoutManager(ColumnLayouts, dgv).ApplyColumnWidths();
                    if (dgv.Width % 35 == 0) {
                        GC.Collect();
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            };
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e) {
            OnCurrentChanged(BindingSource.Current as T);
        }

        public DataGridView UpdateDatasource(IEnumerable<T> data) {
            BindingSource.DataSource = data.ToList();
            Dgv.DataSource = BindingSource;
            OnDatasourceChanged();
            return Dgv;
        }

        public event EventHandler DatasourceChanged;
        protected virtual void OnDatasourceChanged() {
            DatasourceChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<T> CurrentChanged;
        protected virtual void OnCurrentChanged(T bindingSourceCurrent) {
            CurrentChanged?.Invoke(this, bindingSourceCurrent);
        }

        public DataGridView Refresh() {
            Dgv.Refresh();
            return Dgv;
        }

        public DataGridView SetColumnLayout(DGVColumnLayout[] layouts) {
            try {
                ColumnLayouts = layouts;
                // set column layout properties
                foreach (var col in DgvColumns) {
                    var colLayout = layouts.FirstOrDefault(x => col.Name == x.ColumnName);
                    col.Visible = colLayout != null;

                    if (col.Visible) {
                        col.HeaderText = colLayout.HeaderName;
                    }
                }
                new DGVColumnLayoutManager(layouts, Dgv).ApplyColumnWidths();
            } catch { }
            return Dgv;
        }
    }
}
