using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    public class CSharpClass {

        public Table Table { get; }
        public IEnumerable<Column> Columns { get; }
        public List<string> NameSpaces { get; set; } = new List<string>() {
            "using MYaSyncQL.Utils;",
            "using MySql.Data.MySqlClient;",
            "using SqlKata;",
            "using System;",
            "using System.Collections.Generic;",
            "using System.Data;",
            "using System.Threading.Tasks;",
        };

        public List<CSharpProperty> Properties { get; set; } = new List<CSharpProperty>();

        public string ClassName { get; }

        public CSharpClass(Table table, IEnumerable<Column> columns, bool fullyAsync = false) {
            Table = table;
            Columns = columns;
            foreach (var col in Columns) {
                Properties.Add(new CSharpProperty(col, col.ToCSharpType()));
            }

            _fullyAsync = fullyAsync;
            ClassName = Table.TableName.ToClassName();
        }

        private string GetConstantBlock() {
            var sb = new StringBuilder();
            foreach (var prop in Properties) {
                sb.Append("\t\t").AppendLine(prop.ColumnConstant);
            }
            return sb.ToString();
        }

        private string GetPropertyBlock() {
            var sb = new StringBuilder();
            foreach (var prop in Properties) {
                sb.Append("\t\t").Append(prop.ToString());
            }
            return sb.ToString();
        }

        private string GetReaderBlock() {
            var sb = new StringBuilder();
            foreach (var prop in Properties) {
                sb.Append("\t\t\t\t\t\t\t").AppendLine(new ReaderLine(prop).ToString(_fullyAsync));
            }
            return sb.ToString();
        }

        private string GetTableConstant() {
            return $"\t\tpublic const string __TableName = \"{Table.TableSchema}.{Table.TableName}\";";
        }

        private string GenerateGetList() {
            GetListTemplate =
$@"
        public static async Task<List<{ClassName}>> GetAsync(MySqlConnection db) {{

            if (db.State != ConnectionState.Open) await db.OpenAsync();
            var list = new List<{ClassName}>();

            if (db.State == ConnectionState.Open) {{
                var q = new Query(__TableName);

                using (var cmd = db.GetCommand(q)) {{
                    using (var rd = await cmd.ExecuteReaderAsync()) {{
                        while (await rd.ReadAsync()) {{
                            var newItem = new {ClassName}();
##ReaderBlock##
                            list.Add(newItem);
                        }}
                    }}
                }}
            }}
            if (db.State != ConnectionState.Closed) db.Close();
            return list;
        }}
";
            //var getlistText = string.Format(GetListTemplate, _className, $"{Table.TableSchema}.{Table.TableName}");
            return GetListTemplate.Replace("##ReaderBlock##", GetReaderBlock());
        }

        private string GenerateClass(string yourNamespace) {

            ClassTemplate =
$@"{string.Join(Environment.NewLine, NameSpaces)}

namespace {yourNamespace} {{

    public class {ClassName} {{

{GetTableConstant()}
{GetConstantBlock()}
{GetPropertyBlock()}
{GenerateGetList()}
        public override string ToString() {{
            return base.ToString();
        }}

    }}
}}
";
            return ClassTemplate;
            //return string.Format(ClassTemplate, string.Join(Environment.NewLine, NameSpaces),
            //                                    yourNamespace,
            //                                    _className,
            //                                    GetConstantBlock(),
            //                                    GetPropertyBlock(),
            //                                    GenerateGetList());
        }

        public string ToString(string yourNamespace) {
            return GenerateClass(yourNamespace);
        }


        /// <summary>
        /// 0 = usings
        /// 1 = namespace
        /// 2 = ClassName
        /// 3 = column constants
        /// 4 = properties
        /// 5 = static getlist
        /// </summary>
        private static string ClassTemplate = "";
//$@"{{0}}

        //namespace {{1}} {{

        //    public class {{2}} {{

        //{{3}}

        //{{4}}

        //{{5}}

        //        public override string ToString() {{
        //            return base.ToString();
        //        }}

        //    }}
        //}}
        //";

        /// <summary>
        /// 0 = ClassName
        /// 1 = database.tablename
        /// </summary>
        private static string GetListTemplate = "";
//$@"
//        public static async Task<List<{{0}}>> GetAsync(MySqlConnection db) {{

//            if (db.State != ConnectionState.Open) await db.OpenAsync();
//            var list = new List<{{0}}>();

//            if (db.State == ConnectionState.Open) {{
//                var q = new Query(""{{1}}"")

//                using (var cmd = db.GetCommand(q)) {{
//                    using (var rd = await cmd.ExecuteReaderAsync()) {{
//                        while (await rd.ReadAsync()) {{
//                            var newItem = new {{0}}();
//##ReaderBlock##
//                            list.Add(newItem);
//                        }}
//                    }}
//                }}
//            }}
//            if (db.State != ConnectionState.Closed) db.Close();
//            return list;
//        }}
//";
        private readonly bool _fullyAsync;
    }
}
