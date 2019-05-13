using MYaSyncQL.Utils;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MYaSyncQL.InfoSchema {
    public class Column {

        public const string __TableCatalog = "TABLE_CATALOG";
        public const string __TableSchema = "TABLE_SCHEMA";
        public const string __TableName = "TABLE_NAME";
        public const string __ColumnName = "COLUMN_NAME";
        public const string __OrdinalPosition = "ORDINAL_POSITION";
        public const string __ColumnDefault = "COLUMN_DEFAULT";
        public const string __IsNullable = "IS_NULLABLE";
        public const string __DataType = "DATA_TYPE";
        public const string __CharacterMaximumLength = "CHARACTER_MAXIMUM_LENGTH";
        public const string __CharacterOctetLength = "CHARACTER_OCTET_LENGTH";
        public const string __NumericPrecision = "NUMERIC_PRECISION";
        public const string __NumericScale = "NUMERIC_SCALE";
        public const string __DatetimePrecision = "DATETIME_PRECISION";
        public const string __CharacterSetName = "CHARACTER_SET_NAME";
        public const string __CollationName = "COLLATION_NAME";
        public const string __ColumnType = "COLUMN_TYPE";
        public const string __ColumnKey = "COLUMN_KEY";
        public const string __Extra = "EXTRA";
        public const string __Privileges = "PRIVILEGES";
        public const string __ColumnComment = "COLUMN_COMMENT";
        public const string __IsGenerated = "IS_GENERATED";
        public const string __GenerationExpression = "GENERATION_EXPRESSION";

        public string TableCatalog { get; set; } = "";
        public string TableSchema { get; set; } = "";
        public string TableName { get; set; } = "";
        public string ColumnName { get; set; } = "";
        public uint OrdinalPosition { get; set; } = 0;
        public string? ColumnDefault { get; set; } = null;
        public string IsNullable { get; set; } = "";
        public string DataType { get; set; } = "";
        public long? CharacterMaximumLength { get; set; } = null;
        public long? CharacterOctetLength { get; set; } = null;
        public uint? NumericPrecision { get; set; } = null;
        public uint? NumericScale { get; set; } = null;
        public uint? DatetimePrecision { get; set; } = null;
        public string? CharacterSetName { get; set; } = null;
        public string? CollationName { get; set; } = null;
        public string ColumnType { get; set; } = "";
        public string ColumnKey { get; set; } = "";
        public string? Extra { get; set; } = "";
        public string? Privileges { get; set; } = "";
        public string ColumnComment { get; set; } = "";
        public string IsGenerated { get; set; } = "";
        public string? GenerationExpression { get; set; } = null;

        public static async Task<List<Column>> GetAsync(MySqlConnection db) {

            if (db.State != ConnectionState.Open) {
                await db.OpenAsync();
            }
            var list = new List<Column>();

            if (db.State == ConnectionState.Open) {
                var q = new Query("information_schema.COLUMNS")
                            .WhereIn(__TableSchema, new[] { "information_schema", "mysql", "sys", "performance_schema" });
                using (var cmd = db.GetCommand(q)) {
                    using (var rd = await cmd.ExecuteReaderAsync()) {
                        while (await rd.ReadAsync()) {
                            var newItem = new Column();
                            newItem.TableCatalog = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableCatalog));
                            newItem.TableSchema = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableSchema));
                            newItem.TableName = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableName));
                            newItem.ColumnName = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__ColumnName));
                            newItem.OrdinalPosition = await rd.GetFieldValueAsync<uint>(rd.GetOrdinal(__OrdinalPosition));
                            newItem.ColumnDefault = await rd.IsDBNullAsync(rd.GetOrdinal(__ColumnDefault)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__ColumnDefault));
                            newItem.IsNullable = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__IsNullable));
                            newItem.DataType = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__DataType));
                            newItem.CharacterMaximumLength = await rd.IsDBNullAsync(rd.GetOrdinal(__CharacterMaximumLength)) ? null : await rd.GetFieldValueAsync<long?>(rd.GetOrdinal(__CharacterMaximumLength));
                            newItem.CharacterOctetLength = await rd.IsDBNullAsync(rd.GetOrdinal(__CharacterOctetLength)) ? null : await rd.GetFieldValueAsync<long?>(rd.GetOrdinal(__CharacterOctetLength));
                            newItem.NumericPrecision = await rd.IsDBNullAsync(rd.GetOrdinal(__NumericPrecision)) ? null : await rd.GetFieldValueAsync<uint?>(rd.GetOrdinal(__NumericPrecision));
                            newItem.NumericScale = await rd.IsDBNullAsync(rd.GetOrdinal(__NumericScale)) ? null : await rd.GetFieldValueAsync<uint?>(rd.GetOrdinal(__NumericScale));
                            newItem.DatetimePrecision = await rd.IsDBNullAsync(rd.GetOrdinal(__DatetimePrecision)) ? null : await rd.GetFieldValueAsync<uint?>(rd.GetOrdinal(__DatetimePrecision));
                            newItem.CharacterSetName = await rd.IsDBNullAsync(rd.GetOrdinal(__CharacterSetName)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__CharacterSetName));
                            newItem.CollationName = await rd.IsDBNullAsync(rd.GetOrdinal(__CollationName)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__CollationName));
                            newItem.ColumnType = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__ColumnType));
                            newItem.ColumnKey = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__ColumnKey));
                            newItem.Extra = await rd.IsDBNullAsync(rd.GetOrdinal(__Extra)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__Extra));
                            newItem.Privileges = await rd.IsDBNullAsync(rd.GetOrdinal(__Privileges)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__Privileges));
                            newItem.ColumnComment = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__ColumnComment));
                            newItem.GenerationExpression = await rd.IsDBNullAsync(rd.GetOrdinal(__GenerationExpression)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__GenerationExpression));
                            list.Add(newItem);
                        }
                    }
                }
            }

            if (db.State != ConnectionState.Closed) {
                db.Close();
            }
            return list;
        }

        public override string ToString() {
            return $"{TableSchema}.{TableName}.{ColumnName} {ColumnType}{(IsNullable == "YES" ? " nullable" : "")}";
        }
    }
}
