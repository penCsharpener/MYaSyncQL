using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    internal class ReaderLine {

        private StringBuilder sb = new StringBuilder();
        public Column Column { get; }

        public ReaderLine(Column column) {
            Column = column;
        }



    }
}
