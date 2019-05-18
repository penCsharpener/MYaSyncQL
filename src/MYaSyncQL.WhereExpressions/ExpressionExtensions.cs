using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYaSyncQL.WhereExpressions {
    public static class ExpressionExtensions {

        public static T GetCompiledValue<T>(this MemberExpression member) {
            return Expression.Lambda<Func<T>>( Expression.Convert(member, typeof(T))).Compile().Invoke();
        }
    }
}
