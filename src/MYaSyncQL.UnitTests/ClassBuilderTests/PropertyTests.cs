using MYaSyncQL.ClassBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.UnitTests.ClassBuilderTests {
    public class PropertyTests {
        [SetUp]
        public void Setup() {

        }

        [Test]
        public void NullableNumericBigUnsignedTest() {
            var csType = Col.NullableNumericBigUnsigned.ToCSharpType();
            var property = new CSharpProperty(Col.NullableNumericBigUnsigned, csType);

            CSharpProperty.IncludeSqlKataAttributes = true;
            Assert.IsTrue(property.ToString() == "[Column(\"crate_case\")]" + Environment.NewLine
                                               + "public ulong? CrateCase { get; set; }" + Environment.NewLine);

            CSharpProperty.IncludeSqlKataAttributes = false;
            Assert.IsTrue(property.ToString() == "public ulong? CrateCase { get; set; }" + Environment.NewLine);
        }

        [Test]
        public void NonNullableNumericBigTest() {
            var csType = Col.NonNullableNumericBig.ToCSharpType();
            var property = new CSharpProperty(Col.NonNullableNumericBig, csType);

            CSharpProperty.IncludeSqlKataAttributes = true;
            Assert.IsTrue(property.ToString() == "[Key(\"measurement_id\")]" + Environment.NewLine
                                               + "public long MeasurementId { get; set; }" + Environment.NewLine);

            CSharpProperty.IncludeSqlKataAttributes = false;
            Assert.IsTrue(property.ToString() == "public long MeasurementId { get; set; }" + Environment.NewLine);
        }

        [TearDown]
        public void CleanUp() {

        }
    }
}
