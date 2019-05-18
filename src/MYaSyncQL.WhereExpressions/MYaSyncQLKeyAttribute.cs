using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.WhereExpressions {

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MYaSyncQLKeyAttribute : MYaSyncQLColumnAttribute {
        public MYaSyncQLKeyAttribute(string columnName) : base(columnName) {
        }
    }
}
