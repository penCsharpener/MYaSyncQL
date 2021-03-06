﻿using MYaSyncQL.WhereExpressions;
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
        public void InUintArrayTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Id.In<uint>(1, 2, 3, 4),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `id` IN ('1', '2', '3', '4')");
        }

        [Test]
        public void InUintArrayVariableTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var uintArray = new uint[] { 1, 2, 3, 4 };
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Id.In<uint>(uintArray),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `id` IN ('1', '2', '3', '4')");
        }

        [Test]
        public void InStringArrayTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Description.In("day", "word", "sunset"),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `description` IN ('day', 'word', 'sunset')");
        }

        [Test]
        public void InStringArrayVariableTest() {
            var compiler = new MySqlCompiler();
            var query = new Query("some_example_table");
            var stringArray = new[] { "day", "word", "sunset" };
            var exp = new ExpressionParser<ExpressionTestClass>(x => x.Description.In(stringArray),
                                                ExpressionTestClass.Mapping(),
                                                query);
            var whereClause = compiler.Compile(exp.ToSQL()).ToString();
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `description` IN ('day', 'word', 'sunset')");
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
            Assert.IsTrue(whereClause == "SELECT * FROM `some_example_table` WHERE `description` IN ('day', 'word', 'sunset') AND `id` IN ('1', '2', '3', '4') AND `is_active` = false AND LOWER(`description`) like 'matter'");
        }

        [TearDown]
        public void CleanUp() {

        }
    }
}
