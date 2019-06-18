using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    [TestClass]
    public class CitySqlDAOTests : DAOTests
    {

        [DataTestMethod]
        [DataRow("USA", 2)]
        [DataRow("UTO", 1)]
        [DataRow("FRA", 0)]
        public void GetCitiesByCountryCode_Should_ReturnRightNumberOfCities(string countryCode, int expectedCityCount)
        {
            // Arrange

            // Act

            // Assert - City count
        }

        [TestMethod]
        public void AddCity_Should_IncreaseCountBy1()
        {
            // Arrange
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            IList<City> list = dao.GetCitiesByCountryCode("USA");
            int cityCountBefore = list.Count;

            // Act
            City city = new City();
            city.CountryCode = "USA";
            city.Name = "East Cleveland";
            city.District = "Ohio";
            city.Population = 75000;
            dao.AddCity(city);

            // Assert - City count goes up by 1
            list = dao.GetCitiesByCountryCode("USA");
            int cityCountAfter = list.Count;

            Assert.AreEqual(cityCountBefore + 1, cityCountAfter);

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddCity_Should_Fail_IfCountryDoesNotExist()
        {
            // Arrange
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            IList<City> list = dao.GetCitiesByCountryCode("USA");
            int cityCountBefore = list.Count;

            // Act
            City city = new City();
            city.CountryCode = "YYZ";
            city.Name = "East Cleveland";
            city.District = "Ohio";
            city.Population = 75000;
            dao.AddCity(city);

            // Assert - City count goes up by 1
            list = dao.GetCitiesByCountryCode("USA");
            int cityCountAfter = list.Count;

        }
    }
}
