using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }        

        public IList<Country> GetCountries()
        {
            List<Country> list = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the query and command object
                    string sql = "Select * from country";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute and get a reader back
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        Country obj = new Country();
                        obj.Code = Convert.ToString(reader["Code"]);
                        obj.Name = Convert.ToString(reader["Name"]);
                        obj.Continent = Convert.ToString(reader["Continent"]);
                        obj.Region = Convert.ToString(reader["Region"]);
                        obj.SurfaceArea = Convert.ToDouble(reader["SurfaceArea"]);

                        if (reader["indepyear"] is DBNull)
                        {
                            obj.IndependenceYear = null;
                        }
                        else
                        {
                            obj.IndependenceYear = Convert.ToInt32(reader["indepyear"]);
                        }


                        obj.Population = Convert.ToInt32(reader["Population"]);
                        obj.GovernmentForm = Convert.ToString(reader["governmentform"]);
                        // TODO - populate the rest of the columns here....

                        // Add the new country to the list to be returned
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetCountries: {ex.Message}" );
            }

            return list;
        }

        public IList<Country> GetCountries(string continent)
        {
            throw new NotImplementedException();
        }
    }
}
