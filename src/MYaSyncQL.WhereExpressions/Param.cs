using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.WhereExpressions {
    public class Param {
        public string Name { get; set; } = "";
        public int Index { get; set; } = 1;
        public object Value { get; set; } = "";
    }
}
