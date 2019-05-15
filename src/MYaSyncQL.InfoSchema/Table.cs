using MYaSyncQL.Utils;
using MySql.Data.MySqlClient;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MYaSyncQL.InfoSchema {
    public class Table {

        public const string __TableCatalog = "TABLE_CATALOG";
        public const string __TableSchema = "TABLE_SCHEMA";
        public const string __TableName = "TABLE_NAME";
        public const string __TableType = "TABLE_TYPE";
        public const string __Engine = "ENGINE";
        public const string __Version = "VERSION";
        public const string __RowFormat = "ROW_FORMAT";
        public const string __TableRows = "TABLE_ROWS";
        public const string __AvgRowLength = "AVG_ROW_LENGTH";
        public const string __DataLength = "DATA_LENGTH";
        public const string __MaxDataLength = "MAX_DATA_LENGTH";
        public const string __IndexLength = "INDEX_LENGTH";
        public const string __DataFree = "DATA_FREE";
        public const string __AutoIncrement = "AUTO_INCREMENT";
        public const string __CreateTime = "CREATE_TIME";
        public const string __UpdateTime = "UPDATE_TIME";
        public const string __CheckTime = "CHECK_TIME";
        public const string __TableCollation = "TABLE_COLLATION";
        public const string __Checksum = "CHECKSUM";
        public const string __CreateOptions = "CREATE_OPTIONS";
        public const string __TableComment = "TABLE_COMMENT";
        public const string __MaxIndexLength = "MAX_INDEX_LENGTH";
        public const string __Temporary = "TEMPORARY";

        public string TableCatalog { get; set; } = "";
        public string TableSchema { get; set; } = "";
        public string TableName { get; set; } = "";
        public string TableType { get; set; } = "";
        public string? Engine { get; set; } = null;
        public int? Version { get; set; } = null;
        public string? RowFormat { get; set; } = null;
        public ulong? TableRows { get; set; } = null;
        public ulong? AvgRowLength { get; set; } = null;
        public ulong? DataLength { get; set; } = null;
        public ulong? MaxDataLength { get; set; } = null;
        public ulong? IndexLength { get; set; } = null;
        public ulong? DataFree { get; set; } = null;
        public ulong? AutoIncrement { get; set; } = null;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; } = null;
        public DateTime? CheckTime { get; set; } = null;
        public string? TableCollation { get; set; } = null;
        public long? Checksum { get; set; } = null;
        public string? CreateOptions { get; set; } = null;
        public string TableComment { get; set; } = "";
        public long? MaxIndexLength { get; set; } = null;
        public string? Temporary { get; set; } = null;

        public string FullName => $"{TableSchema}.{TableName}";

        public static async Task<List<Table>> GetAsync(MySqlConnection db) {

            if (db.State != ConnectionState.Open) {
                await db.OpenAsync();
            }
            var list = new List<Table>();

            if (db.State == ConnectionState.Open) {
                var q = new Query("information_schema.TABLES")
                            .WhereNotIn(__TableSchema, new[] { "information_schema", "mysql", "sys", "performance_schema" })
                            .OrderBy(__TableSchema, __TableName);
                using (var cmd = db.GetCommand(q)) {
                    using (var rd = await cmd.ExecuteReaderAsync()) {
                        while (await rd.ReadAsync()) {
                            var newItem = new Table();
                            newItem.TableCatalog = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableCatalog));
                            newItem.TableSchema = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableSchema));
                            newItem.TableName = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableName));
                            newItem.TableType = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableType));
                            newItem.Engine = await rd.IsDBNullAsync(rd.GetOrdinal(__Engine)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__Engine));
                            newItem.Version = await rd.IsDBNullAsync(rd.GetOrdinal(__Version)) ? default(int?) : await rd.GetFieldValueAsync<int?>(rd.GetOrdinal(__Version));
                            newItem.RowFormat = await rd.IsDBNullAsync(rd.GetOrdinal(__RowFormat)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__RowFormat));
                            newItem.TableRows = await rd.IsDBNullAsync(rd.GetOrdinal(__TableRows)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__TableRows));
                            newItem.AvgRowLength = await rd.IsDBNullAsync(rd.GetOrdinal(__AvgRowLength)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__AvgRowLength));
                            newItem.DataLength = await rd.IsDBNullAsync(rd.GetOrdinal(__DataLength)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__DataLength));
                            newItem.MaxDataLength = await rd.IsDBNullAsync(rd.GetOrdinal(__MaxDataLength)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__MaxDataLength));
                            newItem.IndexLength = await rd.IsDBNullAsync(rd.GetOrdinal(__IndexLength)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__IndexLength));
                            newItem.DataFree = await rd.IsDBNullAsync(rd.GetOrdinal(__DataFree)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__DataFree));
                            newItem.AutoIncrement = await rd.IsDBNullAsync(rd.GetOrdinal(__AutoIncrement)) ? default(ulong?) : await rd.GetFieldValueAsync<ulong>(rd.GetOrdinal(__AutoIncrement));
                            newItem.CreateTime = await rd.GetFieldValueAsync<DateTime>(rd.GetOrdinal(__CreateTime));
                            newItem.UpdateTime = await rd.IsDBNullAsync(rd.GetOrdinal(__UpdateTime)) ? default(DateTime?) : await rd.GetFieldValueAsync<DateTime>(rd.GetOrdinal(__UpdateTime));
                            newItem.CheckTime = await rd.IsDBNullAsync(rd.GetOrdinal(__CheckTime)) ? default(DateTime?) : await rd.GetFieldValueAsync<DateTime>(rd.GetOrdinal(__CheckTime));
                            newItem.TableCollation = await rd.IsDBNullAsync(rd.GetOrdinal(__TableCollation)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableCollation));
                            newItem.Checksum = await rd.IsDBNullAsync(rd.GetOrdinal(__Checksum)) ? default(long?) : await rd.GetFieldValueAsync<long>(rd.GetOrdinal(__Checksum));
                            newItem.CreateOptions = await rd.IsDBNullAsync(rd.GetOrdinal(__CreateOptions)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__CreateOptions));
                            newItem.TableComment = await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__TableComment));
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
            return $"{TableSchema}.{TableName} rows:{TableRows}";
        }
    }
}
