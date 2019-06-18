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
            // Create a list to hold all the country objects
            List<Country> list = new List<Country>();

            try
            {
                // Create the connection
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
                        // Crete a new object from the reader row
                        Country obj = RowToObject(reader);

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

        // TODO: Implement GetCountries(continent)
        public IList<Country> GetCountries(string continent)
        {
            throw new NotImplementedException();
        }

        // Given a row (the SqlReader object), create a new country object
        private Country RowToObject(SqlDataReader row)
        {
            Country obj = new Country();
            obj.Code = Convert.ToString(row["Code"]);
            obj.Name = Convert.ToString(row["Name"]);
            obj.Continent = Convert.ToString(row["Continent"]);
            obj.Region = Convert.ToString(row["Region"]);
            obj.SurfaceArea = Convert.ToDouble(row["SurfaceArea"]);
            obj.IndependenceYear = ConvertToInt32Nullable(row["indepyear"]);
            obj.Population = Convert.ToInt32(row["Population"]);
            obj.LifeExpectancy = ConvertToDoubleNullable(row["LifeExpectancy"]);
            obj.GNP = ConvertToDecimalNullable(row["gnp"]);
            obj.LocalName = Convert.ToString(row["LocalName"]);
            obj.GovernmentForm = Convert.ToString(row["GovernmentForm"]);
            obj.HeadOfState = Convert.ToString(row["HeadOfState"]);
            obj.CapitalId = ConvertToInt32Nullable(row["Capital"]);
            obj.Code2 = Convert.ToString(row["Code2"]);
            return obj;
        }

        #region Helper methods for conversion of NULLable values

        private int? ConvertToInt32Nullable(object rowValue)
        {
            if (rowValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(rowValue);
            }
        }

        private decimal? ConvertToDecimalNullable(object rowValue)
        {
            if (rowValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(rowValue);
            }
        }

        private double? ConvertToDoubleNullable(object rowValue)
        {
            if (rowValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToDouble(rowValue);
            }
        }

        #endregion
    }
}
