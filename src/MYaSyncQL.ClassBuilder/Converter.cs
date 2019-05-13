using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    public static class Converter {
        public static string ToCSharpType(this Column column) {
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
            } else if (column.DataType.EndsWith("blob", StringComparison.OrdinalIgnoreCase)) {
                return "bytes[]";
            } else if (column.DataType.Equals("date", StringComparison.OrdinalIgnoreCase)) {
                return "DateTime";
            } else if (column.DataType.Equals("bit", StringComparison.OrdinalIgnoreCase)
                       || column.ColumnType.IndexOf("(1)", StringComparison.OrdinalIgnoreCase) >= 0) {
                return "bool";
            }
            return "object";
        }

        private static bool IsUnsigned(this Column column) {
            return column.ColumnType.IndexOf("unsigned", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
