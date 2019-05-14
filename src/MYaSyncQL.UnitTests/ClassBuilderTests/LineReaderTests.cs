using MYaSyncQL.ClassBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.UnitTests.ClassBuilderTests {
    public class LineReaderTests {

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void NullableStringColumnReaderLine() {
            var result = new ReaderLine(Col.NullableString);
            Assert.IsTrue(result.ToString()
                == "newItem.SnakeCasePuppies = rd.IsDBNull(rd.GetOrdinal(__SnakeCasePuppies)) ? null : rd.GetFieldValue<string>(rd.GetOrdinal(__SnakeCasePuppies));");
            Assert.IsTrue(result.ToString(true)
                == "newItem.SnakeCasePuppies = await rd.IsDBNullAsync(rd.GetOrdinal(__SnakeCasePuppies)) ? null : await rd.GetFieldValueAsync<string>(rd.GetOrdinal(__SnakeCasePuppies));");
        }

        [Test]
        public void NonNullableNumericToBoolReaderLine() {
            var result = new ReaderLine(Col.NonNullableNumericToBool);
            Assert.IsTrue(result.ToString()
                == "newItem.BatteryHorseShoe = rd.GetFieldValue<bool>(rd.GetOrdinal(__BatteryHorseShoe));");
            Assert.IsTrue(result.ToString(true)
                == "newItem.BatteryHorseShoe = await rd.GetFieldValueAsync<bool>(rd.GetOrdinal(__BatteryHorseShoe));");
        }

        [Test]
        public void NullableNumericBigUnsignedReaderLine() {
            var result = new ReaderLine(Col.NullableNumericBigUnsigned);
            Assert.IsTrue(result.ToString()
                == "newItem.CrateCase = rd.IsDBNull(rd.GetOrdinal(__CrateCase)) ? null : rd.GetFieldValue<ulong?>(rd.GetOrdinal(__CrateCase));");
            Assert.IsTrue(result.ToString(true)
                == "newItem.CrateCase = await rd.IsDBNullAsync(rd.GetOrdinal(__CrateCase)) ? null : await rd.GetFieldValueAsync<ulong?>(rd.GetOrdinal(__CrateCase));");
        }

        [TearDown]
        public void CleanUp() {

        }
    }
}
