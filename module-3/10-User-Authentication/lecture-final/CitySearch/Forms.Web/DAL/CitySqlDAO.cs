using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.DAO
{
    public class CitySqlDAO : ICityDAO
    {
        private readonly string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public City GetCityById(int id)
        {
            City city = null;

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM city where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a city
                        city = RowToObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return city;
        }
        /// <summary>
        /// Returns all of the cities.
        /// </summary>
        /// <returns></returns>
        public IList<City> GetCities()
        {
            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM city order by id desc";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        City city = RowToObject(reader);
                        output.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public IList<City> GetCities(string countryCode, string district)
        {
            district = "%" + district + "%";

            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();
                 
                    string sql = $"SELECT * FROM city WHERE countryCode = @countryCode AND district LIKE @district order by district, name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);
                    cmd.Parameters.AddWithValue("@district", district);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        output.Add(RowToObject(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        /// <summary>
        /// Returns all of the country codes.
        /// </summary>
        /// <returns></returns>
        public IList<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT code, name FROM country order by name;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = new Country();
                        country.Code = Convert.ToString(reader["code"]);
                        country.Name = Convert.ToString(reader["name"]);
                        countries.Add(country);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return countries;
        }

        /// <summary>
        /// Adds a city to the database.
        /// </summary>
        /// <param name="city"></param>
        public int AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO city VALUES (@name, @countryCode, @district, @population); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    int cityId = Convert.ToInt32(cmd.ExecuteScalar());
                    return cityId;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private City RowToObject(SqlDataReader reader)
        {
            // Create a city
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);
            return city;
        }

        public void UpdateCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Update city Set name = @name, countrycode = @countryCode, district = @district, population = @population where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", city.CityId);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DeleteCity(int cityId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Delete from city where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", cityId);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
