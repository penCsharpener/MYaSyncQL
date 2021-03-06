﻿using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    public class CSharpProperty {

        public static bool IncludeSqlKataAttributes { get; set; } = true;
        public Column Column { get; }
        public CSharpType CSharpType { get; }
        public string AttributeText { get; }
        public string PropertyText { get; }
        public string PropertyName { get; }
        public string ColumnConstant { get; }
        public string InsertTable { get; set; } = "\t\t";

        public CSharpProperty(Column column, CSharpType csType) {
            Column = column;
            CSharpType = csType;
            PropertyName = column.ColumnName.ToPropertyName();
            if (Column.ColumnKey == "PRI" && Column.Extra == "auto_increment") {
                AttributeText = $"[Key(__{PropertyName})]";
            } else {
                AttributeText = $"[Column(__{PropertyName})]";
            }
            PropertyText = $"public {CSharpType.FullStringType} {PropertyName} {{ get; set; }}";
            ColumnConstant = $"public const string __{PropertyName} = \"{column.ColumnName}\";";
        }

        public override string ToString() {
            var sb = new StringBuilder();
            if (IncludeSqlKataAttributes) {
                sb.AppendLine(AttributeText).Append(InsertTable);
            }
            sb.AppendLine(PropertyText);
            return sb.ToString();
        }

    }
}
