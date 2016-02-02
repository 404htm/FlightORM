using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace FlightORM.SQL.Tests
{
    [TestClass]
    public class SQLSchemaReaderTests
    {
        string _cstr;
        string _cstr_db;

        [TestInitialize]
        public void Init()
        {
            _cstr = Properties.Settings.Default.cnn_server;
            _cstr_db = Properties.Settings.Default.cnn_db;
        }

        [TestMethod]
        public void GetAllTablesWithSchema()
        {
            List<string> tables;
            using (var reader = new SQLSchemaReader(_cstr_db))
            {
                tables = reader.GetTables(null, true).ToList();
            }

            Assert.IsTrue(tables.Contains("dbo.Customer"), "dbo.Customer not found");
            Assert.IsTrue(tables.Contains("dbo.Order"), "dbo.Order not found");
            Assert.IsTrue(tables.Contains("inventory.Item"), "inventory.Item not found");
        }

        [TestMethod]
        public void GetAllTablesNoSchema()
        {
            List<string> tables;
            using (var reader = new SQLSchemaReader(_cstr_db))
            {
                tables = reader.GetTables(null, false).ToList();
            }

            Assert.IsTrue(tables.Contains("Customer"), "dbo.Customer not found");
            Assert.IsTrue(tables.Contains("Order"), "dbo.Order not found");
            Assert.IsTrue(tables.Contains("Item"), "inventory.Item not found");
        }

        [TestMethod]
        public void GetdboTablesWithSchema()
        {
            List<string> tables;
            using (var reader = new SQLSchemaReader(_cstr_db))
            {
                tables = reader.GetTables("dbo", true).ToList();
            }

            Assert.IsTrue(tables.Contains("dbo.Customer"), "dbo.Customer not found");
            Assert.IsTrue(tables.Contains("dbo.Order"), "dbo.Order not found");
            Assert.IsFalse(tables.Contains("inventory.Item"), "inventory.Item not found");
        }

        [TestMethod]
        public void GetdboTablesNoSchema()
        {
            List<string> tables;
            using (var reader = new SQLSchemaReader(_cstr_db))
            {
                tables = reader.GetTables("dbo", false).ToList();
            }

            Assert.IsTrue(tables.Contains("Customer"), "dbo.Customer not found");
            Assert.IsTrue(tables.Contains("Order"), "dbo.Order not found");
            Assert.IsFalse(tables.Contains("Item"), "inventory.Item not found");
        }
    }
}
