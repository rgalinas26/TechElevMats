using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    class CitySqlDAOTests
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

            // Act

            // Assert - City count goes up by 1

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddCity_Should_Fail_IfCountryDoesNotExist()
        {
            // Arrange

            // Act

            // Assert - City count goes up by 1
        }
    }
}
