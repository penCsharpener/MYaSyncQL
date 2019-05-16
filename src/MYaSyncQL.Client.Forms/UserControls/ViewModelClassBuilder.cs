using MYaSyncQL.ClassBuilder;
using MYaSyncQL.Client.Forms.Common;
using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYaSyncQL.Client.Forms.UserControls {
    public class ViewModelClassBuilder : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelClassBuilder() {

        }

        #region Bound Properties

        public string Namespace { get; set; } = "MYaSyncQL.GeneratedClass";
        public string ClassCode { get; set; }
        public string TargetPath { get; set; }

        private Table _SelectedTable;
        public Table SelectedTable {
            get { return _SelectedTable; }
            set { _SelectedTable = value; OnSelectedTableChanged(); }
        }

        public List<Table> SelectedTables { get; set; }

        private bool _IncludeAttributes = true;
        public bool IncludeAttributes {
            get { return _IncludeAttributes; }
            set { _IncludeAttributes = value;
                CSharpProperty.IncludeSqlKataAttributes = _IncludeAttributes;
                OnSelectedTableChanged(); }
        }

        private bool _NullableRefTypes;
        public bool NullableRefTypes {
            get { return _NullableRefTypes; }
            set { _NullableRefTypes = value;
                CSharpType.UseCSharpEightNullableReferenceTypes = _NullableRefTypes;
                OnSelectedTableChanged(); }
        }

        private bool _FullyAsyncReading;
        public bool FullyAsyncReading {
            get { return _FullyAsyncReading; }
            set { _FullyAsyncReading = value;
                OnSelectedTableChanged(); }
        }

        #endregion

        #region Events

        public event EventHandler SelectedTableChanged;
        protected virtual void OnSelectedTableChanged() {
            SelectedTableChanged?.Invoke(this, EventArgs.Empty);
        }

        public async Task SaveClasses() {
            if (Directory.Exists(TargetPath) && SelectedTables?.Count > 0) {
                foreach (var tbl in SelectedTables) {
                    var classBuilder = await GenerateClassCode(tbl);
                    var pathToSave = Path.Combine(TargetPath, classBuilder.ClassName + ".cs");
                    if (File.Exists(pathToSave)) {
                        File.Delete(pathToSave);
                    }
                    File.WriteAllText(pathToSave, classBuilder.ToString(Namespace));
                }
            }
        }

        #endregion

        #region Methods

        public async Task<CSharpClass> GenerateClassCode(Table table = null) {
            Table tableToUse = null;
            try {
                if ((string.IsNullOrEmpty(SelectedTable?.TableName) && table == null) || StaticElements.DB == null) {
                    return null;
                } else if (table != null) tableToUse = table;
                else tableToUse = SelectedTable;

                var columns = await Column.GetAsync(StaticElements.DB, tableToUse.TableSchema, tableToUse.TableName);
                var classBuilder = new CSharpClass(tableToUse, columns, FullyAsyncReading);
                ClassCode = classBuilder.ToString(Namespace);
                return classBuilder;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }

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
