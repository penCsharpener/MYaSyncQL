using MYaSyncQL.InfoSchema;
using penCsharpener.DotnetUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    public class ReaderLine {

        public Column Column { get; }
        public CSharpType CSharpType { get; }
        private string _propertyName;

        public ReaderLine(Column column) {
            Column = column;
            CSharpType = column.ToCSharpType();
            _propertyName = column.ColumnName.ToPropertyName();
        }

        /// <summary>
        /// Each property of a class needs to be given a value by the data reader. 
        /// This method assembles that line based on the columns attributes.
        /// </summary>
        /// <returns></returns>
        private string AssembleReaderLine(bool async = false) {
            var txtAsync = async ? "Async" : "";
            var txtAwait = async ? "await " : "";
            var readerline = "";
            var rdTemplate = $"newItem.{_propertyName} = {txtAwait}rd.{{0}}";
            if (CSharpType.Nullable) {                                                       // default({CSharpType.FullStringType})
                readerline = rdTemplate.F($"IsDBNull{txtAsync}(rd.GetOrdinal(__{_propertyName})) ? null : {txtAwait}rd.GetFieldValue{txtAsync}<{CSharpType.FullStringType}>(rd.GetOrdinal(__{_propertyName}));");
            } else {
                readerline = rdTemplate.F($"GetFieldValue{txtAsync}<{CSharpType.FullStringType}>(rd.GetOrdinal(__{_propertyName}));");
            }
            return readerline;
        }

        public string ToString(bool async = false) {
            return AssembleReaderLine(async);
        }

    }
}
