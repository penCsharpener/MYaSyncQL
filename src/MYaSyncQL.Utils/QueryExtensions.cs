using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Compilers;
using System.Data;
using System.Linq;

namespace MYaSyncQL.Utils {
    public static class QueryExtensions {

        internal static MySqlCompiler _compiler = new MySqlCompiler();

        public static MySqlParameter[] ToParams(this SqlResult sql) {
            return sql.NamedBindings.Select(x => new MySqlParameter(x.Key, x.Value)).ToArray();
        }

        public static string ToSql(this SqlResult sql) {
            return sql.RawSql;
        }

        public static MySqlCommand ApplyQuery(this MySqlCommand cmd, Query query) {
            var sqlResult = _compiler.Compile(query);
            cmd.CommandText = sqlResult.RawSql;
            cmd.Parameters.AddRange(sqlResult.ToParams());
            return cmd;
        }

        public static MySqlCommand GetCommand(this MySqlConnection db, Query query) {
            var cmd = db.CreateCommand();
            cmd.Connection = db;
            cmd.CommandType = CommandType.Text;
            return cmd.ApplyQuery(query);
        }

        public static string ToSqlPlain(this Query query) {
            var sqlResult = _compiler.Compile(query);
            return sqlResult.ToString();
        }
    }
}
