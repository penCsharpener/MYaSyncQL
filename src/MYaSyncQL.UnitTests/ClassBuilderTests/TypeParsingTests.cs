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
            var column = new Column() {
                DataType = "bigint",
                ColumnType = "bigint(20) unsigned",
            };
            var result1 = column.ToStringType();
            Assert.IsTrue(result1 == "ulong");
            var column2 = new Column() {
                DataType = "bigint",
                ColumnType = "bigint(11)",
            };
            var result2 = column2.ToStringType();
            Assert.IsTrue(result2 == "long");
            var column3 = new Column() {
                DataType = "tinyint",
                ColumnType = "tinyint(1) unsigned",
            };
            var result3 = column3.ToStringType();
            Assert.IsTrue(result3 == "bool");
            var column4 = new Column() {
                DataType = "tinyint",
                ColumnType = "tinyint(1)",
            };
            var result4 = column4.ToStringType();
            Assert.IsTrue(result4 == "bool");
        }

        [TearDown]
        public void CleanUp() {

        }

    }
}
