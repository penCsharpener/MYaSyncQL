using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.WhereExpressions {

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MYaSyncQLColumnAttribute : Attribute {
        public MYaSyncQLColumnAttribute(string columnName) {
            ColumnName = columnName;
        }

        public string ColumnName { get; set; }
    }
}
