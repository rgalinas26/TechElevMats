using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.DAL;

namespace WorldGeography
{
    class Program
    {
        private static string connectionString;
        static void Main(string[] args)
        {
            // Select all countries
            //GetAllCountries();

            // Get a count of all countries
            //GetCountryCount();

            // Select cities that belong to a country code
            //GetCitiesForCountryCode("USA");


            //Console.ReadKey();
            //return;


            // TODO: Un-comment the Configuration builder and place the connection string in appsettings.json

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            connectionString = configuration.GetConnectionString("World");


            ICityDAO cityDAO = new CitySqlDAO(connectionString);
            ICountryDAO countryDAO = new CountrySqlDAO(connectionString);
            ILanguageDAO languageDAO = new LanguageSqlDAO(connectionString);

            WorldGeographyCLI cli = new WorldGeographyCLI(cityDAO, countryDAO, languageDAO);
            cli.RunCLI();
        }

        #region These were methods to retrieve data bafore we re-factored into DAO's
        private static void GetAllCountries()
        {
            try
            {
                // Specify the db that we will connect to using a connection string
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    // Try to make a connection to the db
                    db.Open();

                    // Create a command to select all countries
                    string sql = "select * from country;";
                    SqlCommand command = new SqlCommand(sql, db);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string code = Convert.ToString(reader["code"]);
                        string name = Convert.ToString(reader["name"]);
                        int population = Convert.ToInt32(reader["population"]);
                        Console.WriteLine($"{code}: {name} has {population} people.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DB Error: {ex.Message}");
            }
        }

        private static void GetCountryCount()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();
                    string sql = "SELECT COUNT(*) FROM country;";
                    SqlCommand cmd = new SqlCommand(sql, db);
                    int rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine($"There are {rowCount} countries.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DB Error: {ex.Message}");
            }
        }

        private static void GetCitiesForCountryCode (string countryCode)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    // This is the way we DON'T want to do it!
                    //string sql = $"Select * from city where countrycode = '{countryCode}' order by name";

                    string sql = "Select * from city where countrycode = @theCountry order by name";
                    SqlCommand cmd = new SqlCommand(sql, db);

                    // Add the country code parameter to the statement
                    cmd.Parameters.AddWithValue("@theCountry", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine($"Cities in {countryCode}:");
                    while (reader.Read())
                    {
                        string cityName = Convert.ToString(reader["name"]);
                        Console.WriteLine($"\t{cityName}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DB Error: {ex.Message}");
            }
        }

        #endregion
    }
}
