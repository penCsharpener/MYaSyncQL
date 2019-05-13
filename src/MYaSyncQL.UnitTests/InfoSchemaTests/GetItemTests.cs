using MYaSyncQL.InfoSchema;
using MYaSyncQL.Utils;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace MYaSyncQL.UnitTests.InfoSchemaTests {
    public class GetItemTests {

        private MySqlConnection db;
        private ConnectionString conn;
        public const string CrendentialFile = "db-test-credentials.json";

        [SetUp]
        public async Task Setup() {
            if (File.Exists(CrendentialFile)) {
                var json = await File.ReadAllTextAsync(CrendentialFile);
                conn = JsonConvert.DeserializeObject<ConnectionString>(json);
            }
        }

        [Test]
        public async Task GetColumns() {
            db = new MySqlConnection(conn.DBConnectionString);
            var columns = await Column.GetAsync(db);
            Assert.IsTrue(columns.Count > 0);
        }

        [Test]
        public async Task GetTables() {
            db = new MySqlConnection(conn.DBConnectionString);
            var tables = await Table.GetAsync(db);
            Assert.IsTrue(tables.Count > 0);
        }

        [TearDown]
        public void CleanUp() {

        }

    }
}
