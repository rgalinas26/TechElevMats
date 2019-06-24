using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // TODO: Optimize the way this method gets the new Id

                    //SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, @district, @population);", conn);
                    //cmd.Parameters.AddWithValue("@name", city.Name);
                    //cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    //cmd.Parameters.AddWithValue("@district", city.District);
                    //cmd.Parameters.AddWithValue("@population", city.Population);

                    //cmd.ExecuteNonQuery();

                    //// Now print the new city id.
                    //cmd = new SqlCommand("SELECT MAX(id) FROM city;", conn);
                    //int id = Convert.ToInt32(cmd.ExecuteScalar());


                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO city VALUES (@name, @countrycode, @district, @population); SELECT @@Identity;", conn);
//                    "INSERT INTO city VALUES (@name, @countrycode, @district, @population); SELECT MAX(id) FROM city;", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    return id;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving city.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public City GetCityById(int cityId)
        {
            City city = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE id = @id;", conn);
                    // param name    // param value
                    cmd.Parameters.AddWithValue("@id", cityId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        city = RowToObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the DB error here...
            }
            return city;
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode = @countryCode;", conn);
                    // param name    // param value
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = RowToObject(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return cities;
        }

        // Given a row (the SqlReader object), create a new city object
        private City RowToObject(SqlDataReader row)
        {
            City obj = new City();
            obj.CityId = Convert.ToInt32(row["Id"]);
            obj.Name = Convert.ToString(row["Name"]);
            obj.District = Convert.ToString(row["District"]);
            obj.CountryCode = Convert.ToString(row["CountryCode"]);
            obj.Population = Convert.ToInt32(row["Population"]);
            return obj;
        }

    }
}
