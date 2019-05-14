using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using MYaSyncQL.InfoSchema;
using MYaSyncQL.ClassBuilder;

namespace MYaSyncQL.UnitTests.ClassBuilderTests {
    public class TypeParsingTests {

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void TypeConversionTest() {
            var result1 = Col.NullableNumericBigUnsigned.ToStringType();
            Assert.IsTrue(result1 == "ulong");
            
            var result2 = Col.NonNullableNumericBig.ToStringType();
            Assert.IsTrue(result2 == "long");
            
            var result3 = Col.NullableNumericToBoolNullableUnsigned.ToStringType();
            Assert.IsTrue(result3 == "bool");
            
            var result4 = Col.NonNullableNumericToBool.ToStringType();
            Assert.IsTrue(result4 == "bool");
        }

        [Test]
        public void FullTypeConversionTest() {
            var result1 = Col.NullableNumericBigUnsigned.ToCSharpType();
            Assert.IsTrue(result1.FullStringType == "ulong?");

            var result2 = Col.NonNullableNumericBig.ToCSharpType();
            Assert.IsTrue(result2.FullStringType == "long");

            var result3 = Col.NullableNumericToBoolNullableUnsigned.ToCSharpType();
            Assert.IsTrue(result3.FullStringType == "bool?");

            var result4 = Col.NonNullableNumericToBool.ToCSharpType();
            Assert.IsTrue(result4.FullStringType == "bool");

            var result5 = Col.NonNullableString.ToCSharpType();
            Assert.IsTrue(result5.FullStringType == "string");

            CSharpType.UseCSharpEightNullableReferenceTypes = true;
            var result6 = Col.NullableString.ToCSharpType();
            Assert.IsTrue(result6.FullStringType == "string?");
            Assert.IsTrue(result6.Type == typeof(string?));

            CSharpType.UseCSharpEightNullableReferenceTypes = false;
            var result7 = Col.NullableString.ToCSharpType();
            Assert.IsTrue(result7.FullStringType == "string");
            Assert.IsTrue(result7.Type == typeof(string));
            
            var result8 = Col.NullableBitOfOne.ToCSharpType();
            Assert.IsTrue(result8.FullStringType == "bool?");
        }

        [TearDown]
        public void CleanUp() {

        }

    }
}
