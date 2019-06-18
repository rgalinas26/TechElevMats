using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            List<Language> list = new List<Language>();
            string sql = "Select * from CountryLanguage where CountryCode = @countryCode";
            try
            {
                // Create the connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the query and command object
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    // Execute and get a reader back
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        // Crete a new object from the reader row
                        Language obj = RowToObject(reader);

                        // Add the new country to the list to be returned
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetLanguages: {ex.Message}");
            }
            return list;
        }

        // TODO: Implement Language.AddNewLanguage(newLanguage)
        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement Language.RemoveLanguage(deadLanguage)
        public bool RemoveLanguage(Language deadLanguage)
        {
            throw new NotImplementedException();
        }

        // Given a row (the SqlReader object), create a new language object
        private Language RowToObject(SqlDataReader row)
        {
            Language obj = new Language();
            obj.CountryCode = Convert.ToString(row["CountryCode"]);
            obj.Name = Convert.ToString(row["Language"]);
            obj.IsOfficial = Convert.ToBoolean(row["IsOfficial"]);
            obj.Percentage = Convert.ToInt32(row["Percentage"]);
            return obj;
        }
    }
}
