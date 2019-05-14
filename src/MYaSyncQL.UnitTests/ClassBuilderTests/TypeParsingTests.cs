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
            var result1 = NullableNumericBigUnsigned.ToStringType();
            Assert.IsTrue(result1 == "ulong");
            
            var result2 = NonNullableNumericBig.ToStringType();
            Assert.IsTrue(result2 == "long");
            
            var result3 = NullableNumericToBoolNullableUnsigned.ToStringType();
            Assert.IsTrue(result3 == "bool");
            
            var result4 = NonNullableNumericToBool.ToStringType();
            Assert.IsTrue(result4 == "bool");
        }

        [Test]
        public void FullTypeConversionTest() {
            var result1 = NullableNumericBigUnsigned.ToCSharpType();
            Assert.IsTrue(result1.FullStringType == "ulong?");

            var result2 = NonNullableNumericBig.ToCSharpType();
            Assert.IsTrue(result2.FullStringType == "long");

            var result3 = NullableNumericToBoolNullableUnsigned.ToCSharpType();
            Assert.IsTrue(result3.FullStringType == "bool?");

            var result4 = NonNullableNumericToBool.ToCSharpType();
            Assert.IsTrue(result4.FullStringType == "bool");

            var result5 = NonNullableString.ToCSharpType();
            Assert.IsTrue(result5.FullStringType == "string");

            CSharpType.UseCSharpEightNullableReferenceTypes = true;
            var result6 = NullableString.ToCSharpType();
            Assert.IsTrue(result6.FullStringType == "string?");
            Assert.IsTrue(result6.Type == typeof(string?));

            CSharpType.UseCSharpEightNullableReferenceTypes = false;
            var result7 = NullableString.ToCSharpType();
            Assert.IsTrue(result7.FullStringType == "string");
            Assert.IsTrue(result7.Type == typeof(string));
            
            var result8 = NullableBitOfOne.ToCSharpType();
            Assert.IsTrue(result8.FullStringType == "bool?");
        }

        [TearDown]
        public void CleanUp() {

        }

        private Column NullableNumericBigUnsigned = new Column() {
            IsNullable = "YES",
            DataType = "bigint",
            ColumnType = "bigint(20) unsigned",
        };
        private Column NonNullableNumericBig = new Column() {
            IsNullable = "NO",
            DataType = "bigint",
            ColumnType = "bigint(11)",
        };
        private Column NullableNumericToBoolNullableUnsigned = new Column() {
            IsNullable = "YES",
            DataType = "tinyint",
            ColumnType = "tinyint(1) unsigned",
        };
        private Column NonNullableNumericToBool = new Column() {
            IsNullable = "NO",
            DataType = "tinyint",
            ColumnType = "tinyint(1)",
        };
        private Column NonNullableString = new Column() {
            IsNullable = "NO",
            DataType = "longtext",
            ColumnType = "longtext",
        };
        private Column NullableString = new Column() {
            IsNullable = "YES",
            DataType = "varchar",
            ColumnType = "varchar(255)",
        };
        private Column NullableBitOfOne = new Column() {
            IsNullable = "YES",
            DataType = "bit",
            ColumnType = "bit(1)",
        };
    }
}
