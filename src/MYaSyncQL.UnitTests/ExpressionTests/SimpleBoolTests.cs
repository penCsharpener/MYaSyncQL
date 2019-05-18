using MYaSyncQL.WhereExpressions;
using NUnit.Framework;
using penCsharpener.DotnetUtils;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.UnitTests.ExpressionTests {
    public class SimpleBoolTests {



        [SetUp]
        public void Setup() {

        }

        [Test]
        public void SimpleBoolTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => !x.IsActive && x.IsActive,
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `is_active` = true AND `is_active` = false");
        }

        [Test]
        public void InUintTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Id.In<uint>(1, 2, 3, 4),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "");
        }

        [Test]
        public void InStringTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Description.In("day", "word", "sunset"),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "");
        }

        [Test]
        public void LikeTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Description.Like("matter"),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE LOWER(`description`) like 'matter'");
        }

        [Test]
        public void CombinedConditionTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Description.Like("matter")
                                                                 && !x.IsActive
                                                                  && x.Id.In<uint>(1, 2, 3, 4)
                                                                  && x.Description.In("day", "word", "sunset"),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "");
        }

        [TearDown]
        public void CleanUp() {

        }
    }
}
