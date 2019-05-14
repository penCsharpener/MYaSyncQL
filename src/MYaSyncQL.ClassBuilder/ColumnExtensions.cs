using MYaSyncQL.InfoSchema;
using penCsharpener.DotnetUtils;
using System;

namespace MYaSyncQL.ClassBuilder {
    public static class ColumnExtensions {
        public static string ToStringType(this Column column) {
            if (column.DataType.EndsWith("text", StringComparison.OrdinalIgnoreCase)
                || column.DataType.EndsWith("varchar", StringComparison.OrdinalIgnoreCase)) {
                return "string";
            } else if (column.DataType.Equals("bigint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return "ulong";
                return "long";
            } else if (column.DataType.Equals("int", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return "uint";
                return "int";
            } else if (column.DataType.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) {
                if (column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >=0) {
                    return "bool";
                }
                if (column.IsUnsigned()) return "ushort";
                return "short";
            } else if (column.DataType.Equals("smallint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return "ushort";
                else return "short";
            } else if (column.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase)) {
                return "DateTime";
            } else if (column.DataType.Equals("decimal", StringComparison.OrdinalIgnoreCase)) {
                return "decimal";
            } else if (column.DataType.Equals("double", StringComparison.OrdinalIgnoreCase)) {
                return "double";
            } else if (column.DataType.Equals("float", StringComparison.OrdinalIgnoreCase)) {
                return "float";
            } else if (column.DataType.EndsWith("blob", StringComparison.OrdinalIgnoreCase)
                || column.DataType.IndexOf("varbin", StringComparison.OrdinalIgnoreCase) >= 0) {
                return "byte[]";
            } else if (column.DataType.Equals("date", StringComparison.OrdinalIgnoreCase)) {
                return "DateTime";
            } else if (column.DataType.Equals("bit", StringComparison.OrdinalIgnoreCase)
                       || column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                return "bool";
            }
            return "object";
        }

        public static Type ToType(this Column column) {
            if (column.DataType.EndsWith("text", StringComparison.OrdinalIgnoreCase)
                || column.DataType.EndsWith("varchar", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" && CSharpType.UseCSharpEightNullableReferenceTypes ? typeof(string?) : typeof(string);
            } else if (column.DataType.Equals("bigint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return column.IsNullable == "YES" ? typeof(ulong?) : typeof(ulong);
                return column.IsNullable == "YES" ? typeof(long?) : typeof(long);
            } else if (column.DataType.Equals("int", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return column.IsNullable == "YES" ? typeof(uint?) : typeof(uint);
                return column.IsNullable == "YES" ? typeof(int?) : typeof(int);
            } else if (column.DataType.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) {
                if (column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                    return column.IsNullable == "YES" ? typeof(bool?) : typeof(bool);
                }
                if (column.IsUnsigned()) return column.IsNullable == "YES" ? typeof(ushort?) : typeof(ushort);
                return column.IsNullable == "YES" ? typeof(short?) : typeof(short);
            } else if (column.DataType.Equals("smallint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return column.IsNullable == "YES" ? typeof(ushort?) : typeof(ushort);
                else return column.IsNullable == "YES" ? typeof(short?) : typeof(short);
            } else if (column.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" ? typeof(DateTime?) : typeof(DateTime);
            } else if (column.DataType.Equals("decimal", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" ? typeof(decimal?) : typeof(decimal);
            } else if (column.DataType.Equals("double", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" ? typeof(double?) : typeof(double);
            } else if (column.DataType.Equals("float", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" ? typeof(float?) : typeof(float);
            } else if (column.DataType.EndsWith("blob", StringComparison.OrdinalIgnoreCase)
                || column.DataType.IndexOf("varbin", StringComparison.OrdinalIgnoreCase) >= 0) {
                return column.IsNullable == "YES" && CSharpType.UseCSharpEightNullableReferenceTypes ? typeof(byte[]?) : typeof(byte[]);
            } else if (column.DataType.Equals("date", StringComparison.OrdinalIgnoreCase)) {
                return column.IsNullable == "YES" ? typeof(DateTime?) : typeof(DateTime);
            } else if (column.DataType.Equals("bit", StringComparison.OrdinalIgnoreCase)
                       || column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                return column.IsNullable == "YES" ? typeof(bool?) : typeof(bool);
            }
            return column.IsNullable == "YES" && CSharpType.UseCSharpEightNullableReferenceTypes ? typeof(object?) : typeof(object);
        }

        public static CSharpType ToCSharpType(this Column column) {
            var csType = new CSharpType(column.ToStringType());
            csType.Nullable = column.IsNullable.Equals("yes", StringComparison.OrdinalIgnoreCase);
            csType.Unsigned = column.ColumnType.IndexOf("unsigned", StringComparison.OrdinalIgnoreCase) >= 0;
            csType.Type = column.ToType();
            return csType;
        }

        private static bool IsUnsigned(this Column column) {
            return column.ColumnType.IndexOf("unsigned", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// method assumes the column name is in snake_case
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ToPropertyName(this string columnName) {
            return columnName.SnakeToPascalCase();
        }

        /// <summary>
        /// converts a database table name from plural snake case to singular pascal case.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string ToClassName(this string tableName) {
            var className = tableName.SnakeToPascalCase();
            if (className.EndsWith("ies")) {
                className = className.Substring(0, className.Length - 3) + "y";
            }
            if (className.EndsWith("s") && !className.EndsWith("status")) {
                className = className.Substring(0, className.Length - 1);
            }
            return className;
        }
    }
}
