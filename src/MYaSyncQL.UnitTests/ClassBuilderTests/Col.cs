using MYaSyncQL.InfoSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYaSyncQL.UnitTests.ClassBuilderTests {
    public static class Col {

        public static Column NullableNumericBigUnsigned = new Column() {
            ColumnName = "crate_case",
            IsNullable = "YES",
            DataType = "bigint",
            ColumnType = "bigint(20) unsigned",
        };
        public static Column NonNullableNumericBig = new Column() {
            ColumnName = "measurement",
            IsNullable = "NO",
            DataType = "bigint",
            ColumnType = "bigint(11)",
        };
        public static Column NullableNumericToBoolNullableUnsigned = new Column() {
            ColumnName = "stable_pinetree_paper",
            IsNullable = "YES",
            DataType = "tinyint",
            ColumnType = "tinyint(1) unsigned",
        };
        public static Column NonNullableNumericToBool = new Column() {
            ColumnName = "battery_horse_shoe",
            IsNullable = "NO",
            DataType = "tinyint",
            ColumnType = "tinyint(1)",
        };
        public static Column NonNullableString = new Column() {
            ColumnName = "king_inhaler",
            IsNullable = "NO",
            DataType = "longtext",
            ColumnType = "longtext",
        };
        public static Column NullableString = new Column() {
            ColumnName = "snake_case_puppies",
            IsNullable = "YES",
            DataType = "varchar",
            ColumnType = "varchar(255)",
        };
        public static Column NullableBitOfOne = new Column() {
            ColumnName = "cardboard_ear_tape",
            IsNullable = "YES",
            DataType = "bit",
            ColumnType = "bit(1)",
        };
    }
}
