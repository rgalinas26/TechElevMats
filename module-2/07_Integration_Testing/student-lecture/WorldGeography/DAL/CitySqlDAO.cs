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

        // TODO: Implement City.AddCity(city)
        public void AddCity(City city)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement City.GetCitiesByCountryCode(countryCode)
        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            throw new NotImplementedException();
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
