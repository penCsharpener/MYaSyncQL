using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.ClassBuilder {
    public class CSharpType {

        public CSharpType(string stringType) {
            StringType = stringType;
        }

        public static bool UseCSharpEightNullableReferenceTypes { get; set; }
        public string StringType { get; set; }
        public Type Type { get; set; } = typeof(object);
        public bool Nullable { get; set; }
        public bool Unsigned { get; set; }
        public string FullStringType => $"{UnsignedPrefix()}{StringType}{NullableOperator()}";
        public string NonNullableStringType => $"{UnsignedPrefix()}{StringType}";

        private string NullableOperator() {
            if (StringType == "string" || StringType == "byte[]") {
                // these types are nullable by default unless C# 8.0 Nullable Ref types is desired
                return UseCSharpEightNullableReferenceTypes ? "?" : "";
            } else {
                return Nullable ? "?" : "";
            }
        }

        private string UnsignedPrefix() {
            if (StringType == "int" || StringType == "long" || StringType == "short") {
                return Unsigned ? "u" : "";
            } else {
                return "";
            }
        }
    }
}
