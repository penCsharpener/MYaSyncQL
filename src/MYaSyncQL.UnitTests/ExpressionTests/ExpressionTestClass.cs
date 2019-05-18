using MYaSyncQL.WhereExpressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYaSyncQL.UnitTests.ExpressionTests {
    internal class ExpressionTestClass {

        [MYaSyncQLColumn("is_active")]
        public bool IsActive { get; set; }

        [MYaSyncQLColumn("description")]
        public string Description { get; set; } = "Some default description.";

        [MYaSyncQLKey("id")]
        public uint Id { get; set; }

        public static Dictionary<string, string> Mapping() {
            return new Dictionary<string, string>() {
                { nameof(IsActive), "is_active" },
                { nameof(Description), "description" },
                { nameof(Id), "id" },
            };
        }

        public static List<ExpressionTestClass> GetList() {
            return new List<ExpressionTestClass>() {
                new ExpressionTestClass() { IsActive = true, Description = "A new day and everything is still the same.", Id = 1 },
                new ExpressionTestClass() { IsActive = false, Description = "Lorem ipsum dolor.", Id = 2 },
                new ExpressionTestClass() { IsActive = false, Description = "Once upon a time there was...", Id = 4 },
                new ExpressionTestClass() { IsActive = true, Description = "I need to assimilate nutritious bio-matter.", Id = 5 },
                new ExpressionTestClass() { IsActive = true, Description = "Let's agree to disagree!", Id = 6 },
                new ExpressionTestClass() { IsActive = false, Description = "We don't know what we don't know until we know it.", Id = 7 },
                new ExpressionTestClass() { IsActive = true, Description = "", Id = 8 },
                new ExpressionTestClass() { IsActive = false, Description = "Some wond'rous thing has happened. Above is an empty string.", Id = 9 },
            };
        }
    }
}
