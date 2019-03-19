using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Transactions;
using System.Data.SqlClient;

namespace Capstone.Tests
{
    [TestClass]
    public class CapstoneTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True";

        private TransactionScope transaction;

        protected int park1 { get; private set; }
        protected int park2 { get; private set; }
        protected int campground1 { get; private set; }
        protected int campground2 { get; private set; }
        protected int siteID { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();

            string sql = File.ReadAllText("test-script.sql");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.park1 = Convert.ToInt32(reader["park1"]);
                    this.park2 = Convert.ToInt32(reader["park2"]);
                    this.campground1 = Convert.ToInt32(reader["campground1"]);
                    this.campground2 = Convert.ToInt32(reader["campground2"]);
                    this.siteID = Convert.ToInt32(reader["siteID"]);
                }

            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select count(*) from {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }

    }

}