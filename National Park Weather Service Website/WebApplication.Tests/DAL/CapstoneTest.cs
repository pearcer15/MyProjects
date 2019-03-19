using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class CapstoneTest
    {
        protected string ConnectionString { get; } = "Data Source =.\\SQLEXPRESS;Initial Catalog = NPGeek; Integrated Security = True";

        private TransactionScope transaction;

        protected int NewUserId { get; private set; }
        protected string ParkCode { get; private set; }
        protected int ForecastValue { get; private set; }
        protected int SurveyResultId { get; private set; }

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
                    this.NewUserId = Convert.ToInt32(reader["newUsersId"]);
                    this.ParkCode = Convert.ToString(reader["parkCode"]);
                    this.ForecastValue = Convert.ToInt32(reader["forecastValue"]);
                    this.SurveyResultId = Convert.ToInt32(reader["newSurveyResultId"]);
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
