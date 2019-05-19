using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MYaSyncQL.WhereExpressions {
    public class ExpressionParser<T> where T : class {

        public Expression<Func<T, bool>> Expression { get; }
        public Dictionary<string, string> Mapping { get; }
        public List<Param> Parameters { get; set; }
        public Query _query;

        private StringBuilder sb = new StringBuilder();

        public ExpressionParser(Expression<Func<T, bool>> expression, Dictionary<string, string> mapping, Query query) {
            Expression = expression;
            Mapping = mapping;
            _query = query;
        }

        public void ParseExpression(Expression expression) {

            switch (expression.NodeType) {
                case ExpressionType.Add:
                    break;
                case ExpressionType.AddAssign:
                    break;
                case ExpressionType.AddAssignChecked:
                    break;
                case ExpressionType.AddChecked:
                    break;
                case ExpressionType.And:
                    break;
                case ExpressionType.AndAlso:
                    if (expression is BinaryExpression binAnd) {
                        ParseExpression(binAnd.Right);
                        ParseExpression(binAnd.Left);
                    }
                    break;
                case ExpressionType.AndAssign:
                    break;
                case ExpressionType.ArrayIndex:
                    break;
                case ExpressionType.ArrayLength:
                    break;
                case ExpressionType.Assign:
                    break;
                case ExpressionType.Block:
                    break;
                case ExpressionType.Call:
                    if (expression is MethodCallExpression meth) {
                        var columnName = ((MemberExpression)meth.Arguments[0])
                                        .Member
                                        .CustomAttributes
                                        .FirstOrDefault(x => x.AttributeType == typeof(MYaSyncQLColumnAttribute)
                                                        || x.AttributeType == typeof(MYaSyncQLKeyAttribute))?
                                        .ConstructorArguments[0]
                                        .Value.ToString();
                        if (!string.IsNullOrEmpty(columnName)) {

                            switch (meth.Method.Name) {
                                case "Like":
                                    if (meth.Arguments[1] is ConstantExpression cons) {
                                        _query.WhereLike(columnName, cons.Value.ToString());
                                    }
                                    break;
                                case "In":
                                    if (meth.Arguments[1] is NewArrayExpression array) {
                                        if (array.Type.BaseType == typeof(Array)) {
                                            if (array.Type == typeof(uint[])) {
                                                _query.WhereIn<uint>(columnName, array.Expressions.Cast<ConstantExpression>().Select(x => x.Value).Cast<uint>());
                                            } else if (array.Type == typeof(int[])) {
                                                _query.WhereIn<int>(columnName, array.Expressions.Cast<ConstantExpression>().Select(x => x.Value).Cast<int>());
                                            } else if (array.Type == typeof(long[])) {
                                                _query.WhereIn<long>(columnName, array.Expressions.Cast<ConstantExpression>().Select(x => x.Value).Cast<long>());
                                            } else if (array.Type == typeof(ulong[])) {
                                                _query.WhereIn<ulong>(columnName, array.Expressions.Cast<ConstantExpression>().Select(x => x.Value).Cast<ulong>());
                                            } else if (array.Type == typeof(string[])) {
                                                _query.WhereIn<string>(columnName, array.Expressions.Cast<ConstantExpression>().Select(x => x.Value).Cast<string>());
                                            }
                                        }
                                    } else if (meth.Arguments[1] is ConditionalExpression constant) {

                                    } else if (meth.Arguments[1] is MemberExpression field) {
                                        if (field.Type.BaseType == typeof(Array)) {
                                            object container = ((ConstantExpression)field.Expression).Value;
                                            if (field.Member is FieldInfo memInfo) {
                                                if (field.Type == typeof(uint[])) {
                                                    _query.WhereIn<uint>(columnName, memInfo.GetValue(container).CastTo<uint[]>());
                                                } else if (field.Type == typeof(int[])) {
                                                    _query.WhereIn<int>(columnName, memInfo.GetValue(container).CastTo<int[]>());
                                                } else if (field.Type == typeof(long[])) {
                                                    _query.WhereIn<long>(columnName, memInfo.GetValue(container).CastTo<long[]>());
                                                } else if (field.Type == typeof(ulong[])) {
                                                    _query.WhereIn<ulong>(columnName, memInfo.GetValue(container).CastTo<ulong[]>());
                                                } else if (field.Type == typeof(string[])) {
                                                    _query.WhereIn<string>(columnName, memInfo.GetValue(container).CastTo<string[]>());
                                                }
                                            }

                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case ExpressionType.Coalesce:
                    break;
                case ExpressionType.Conditional:
                    break;
                case ExpressionType.Constant:
                    break;
                case ExpressionType.Convert:
                    break;
                case ExpressionType.ConvertChecked:
                    break;
                case ExpressionType.DebugInfo:
                    break;
                case ExpressionType.Decrement:
                    break;
                case ExpressionType.Default:
                    break;
                case ExpressionType.Divide:
                    break;
                case ExpressionType.DivideAssign:
                    break;
                case ExpressionType.Dynamic:
                    break;
                case ExpressionType.Equal:
                    break;
                case ExpressionType.ExclusiveOr:
                    break;
                case ExpressionType.ExclusiveOrAssign:
                    break;
                case ExpressionType.Extension:
                    break;
                case ExpressionType.Goto:
                    break;
                case ExpressionType.GreaterThan:
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    break;
                case ExpressionType.Increment:
                    break;
                case ExpressionType.Index:
                    break;
                case ExpressionType.Invoke:
                    break;
                case ExpressionType.IsFalse:
                    break;
                case ExpressionType.IsTrue:
                    var binExp = (BinaryExpression)expression;
                    ParseExpression(binExp);
                    break;
                case ExpressionType.Label:
                    break;
                case ExpressionType.Lambda:
                    ParseExpression(((LambdaExpression)expression).Body);
                    break;
                case ExpressionType.LeftShift:
                    break;
                case ExpressionType.LeftShiftAssign:
                    break;
                case ExpressionType.LessThan:
                    break;
                case ExpressionType.LessThanOrEqual:
                    break;
                case ExpressionType.ListInit:
                    break;
                case ExpressionType.Loop:
                    break;
                case ExpressionType.MemberAccess:
                    var memExp = (MemberExpression)expression;
                    if (memExp.Type == typeof(bool)) {
                        if (memExp.Member.CustomAttributes.Any()) {
                            _query.Where(memExp.Member.CustomAttributes.First().ConstructorArguments[0].Value.ToString(), true);
                        }
                    }
                    break;
                case ExpressionType.MemberInit:
                    break;
                case ExpressionType.Modulo:
                    break;
                case ExpressionType.ModuloAssign:
                    break;
                case ExpressionType.Multiply:
                    break;
                case ExpressionType.MultiplyAssign:
                    break;
                case ExpressionType.MultiplyAssignChecked:
                    break;
                case ExpressionType.MultiplyChecked:
                    break;
                case ExpressionType.Negate:
                    break;
                case ExpressionType.NegateChecked:
                    break;
                case ExpressionType.New:
                    break;
                case ExpressionType.NewArrayBounds:
                    break;
                case ExpressionType.NewArrayInit:
                    break;
                case ExpressionType.Not:
                    var unaryExp = (UnaryExpression)expression;
                    var mem = ((MemberExpression)unaryExp.Operand).Member;
                    if (unaryExp.Operand.Type == typeof(bool)) {
                        if (mem.CustomAttributes.Any()) {
                            _query.Where(mem.CustomAttributes.First().ConstructorArguments[0].Value.ToString(), false);
                        }
                    }
                    break;
                case ExpressionType.NotEqual:
                    break;
                case ExpressionType.OnesComplement:
                    break;
                case ExpressionType.Or:
                    break;
                case ExpressionType.OrAssign:
                    break;
                case ExpressionType.OrElse:
                    if (expression is BinaryExpression binOr) {
                        ParseExpression(binOr.Right);
                        ParseExpression(binOr.Left);
                    }
                    break;
                case ExpressionType.Parameter:
                    break;
                case ExpressionType.PostDecrementAssign:
                    break;
                case ExpressionType.PostIncrementAssign:
                    break;
                case ExpressionType.Power:
                    break;
                case ExpressionType.PowerAssign:
                    break;
                case ExpressionType.PreDecrementAssign:
                    break;
                case ExpressionType.PreIncrementAssign:
                    break;
                case ExpressionType.Quote:
                    break;
                case ExpressionType.RightShift:
                    break;
                case ExpressionType.RightShiftAssign:
                    break;
                case ExpressionType.RuntimeVariables:
                    break;
                case ExpressionType.Subtract:
                    break;
                case ExpressionType.SubtractAssign:
                    break;
                case ExpressionType.SubtractAssignChecked:
                    break;
                case ExpressionType.SubtractChecked:
                    break;
                case ExpressionType.Switch:
                    break;
                case ExpressionType.Throw:
                    break;
                case ExpressionType.Try:
                    break;
                case ExpressionType.TypeAs:
                    break;
                case ExpressionType.TypeEqual:
                    break;
                case ExpressionType.TypeIs:
                    break;
                case ExpressionType.UnaryPlus:
                    break;
                case ExpressionType.Unbox:
                    break;
                default:
                    break;
            }
        }

        public Query ToSQL() {
            ParseExpression(Expression);
            return _query;
        }
    }
}
