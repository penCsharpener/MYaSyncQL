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

        #endregion

        #region Events

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
