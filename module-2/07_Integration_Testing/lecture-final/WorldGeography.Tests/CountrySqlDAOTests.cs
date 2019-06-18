using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    [TestClass]
    public class CountrySqlDAOTests
    {
        [TestMethod]
        public void GetCountriesTest_Should_ReturnAllCountries()
        {
            // Arrange

            // Act

            // Assert - Country count
        }

        [DataTestMethod]
        [DataRow("North America", 2)]
        [DataRow("South America", 1)]
        [DataRow("Asia", 0)]
        public void GetCountriesByContinent_Should_ReturnCorrectNumberOfCountries(string continent, int expectedCount)
        {
            // Arrange

            // Act

            // Assert - Country count
        }
    }
}
