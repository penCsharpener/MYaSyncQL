using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.UserControls {
    public class ViewModelClassBuilder : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelClassBuilder() {

        }

        #region Bound Properties

        public string ClassCode { get; set; }
        private Table _SelectedTable;
        public Table SelectedTable {
            get { return _SelectedTable; }
            set { _SelectedTable = value; OnSelectedTableChanged(); }
        }

        #endregion

        #region Events

        public event EventHandler SelectedTableChanged;
        protected virtual void OnSelectedTableChanged() {


            SelectedTableChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        private List<Table> Tables;
        public async Task<List<Table>> GetTables() {
            Tables = await Table.GetAsync(StaticElements.DB);
            return Tables;
        }

        private List<Column> Columns;
        public async Task<List<Column>> GetColumns() {
            Columns = await Column.GetAsync(StaticElements.DB);
            return Columns;
        }



        #endregion
    }
}
