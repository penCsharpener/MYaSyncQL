using MYaSyncQL.InfoSchema;
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
                return typeof(string);
            } else if (column.DataType.Equals("bigint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return typeof(ulong);
                return typeof(long);
            } else if (column.DataType.Equals("int", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return typeof(uint);
                return typeof(int);
            } else if (column.DataType.Equals("tinyint", StringComparison.OrdinalIgnoreCase)) {
                if (column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                    return typeof(bool);
                }
                if (column.IsUnsigned()) return typeof(ushort);
                return typeof(short);
            } else if (column.DataType.Equals("smallint", StringComparison.OrdinalIgnoreCase)) {
                if (column.IsUnsigned()) return typeof(ushort);
                else return typeof(short);
            } else if (column.DataType.Equals("datetime", StringComparison.OrdinalIgnoreCase)) {
                return typeof(DateTime);
            } else if (column.DataType.Equals("decimal", StringComparison.OrdinalIgnoreCase)) {
                return typeof(decimal);
            } else if (column.DataType.Equals("double", StringComparison.OrdinalIgnoreCase)) {
                return typeof(double);
            } else if (column.DataType.Equals("float", StringComparison.OrdinalIgnoreCase)) {
                return typeof(float);
            } else if (column.DataType.EndsWith("blob", StringComparison.OrdinalIgnoreCase)
                || column.DataType.IndexOf("varbin", StringComparison.OrdinalIgnoreCase) >= 0) {
                return typeof(byte[]);
            } else if (column.DataType.Equals("date", StringComparison.OrdinalIgnoreCase)) {
                return typeof(DateTime);
            } else if (column.DataType.Equals("bit", StringComparison.OrdinalIgnoreCase)
                       || column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                return typeof(bool);
            }
            return typeof(object);
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
    }
}
