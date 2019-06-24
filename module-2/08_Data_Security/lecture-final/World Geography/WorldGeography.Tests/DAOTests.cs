using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Transactions;

namespace WorldGeography.Tests
{
    [TestClass]
    abstract public class DAOTests
    {
        protected string connectionString = "Server=.\\SqlExpress; Database=World; Trusted_Connection=true;";
        private TransactionScope transaction;
        protected int newCityId;


        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();
            string script = File.ReadAllText("TestSetup.sql");

            using (SqlConnection conn = new SqlConnection(connectionString) )
            {
                // Open the Connection
                conn.Open();
                SqlCommand cmd = new SqlCommand(script, conn);

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    this.newCityId = Convert.ToInt32(rdr["newCityId"]);
                }


            }
        }

        protected int GetCount(string tablename)
        {
            string sql = $"Select count(*) from {tablename}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Roll back the transaction
            this.transaction.Dispose();
        }
    }
}
