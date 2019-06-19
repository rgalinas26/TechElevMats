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

                cmd.ExecuteNonQuery();
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
