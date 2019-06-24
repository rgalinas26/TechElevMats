using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    [TestClass]
    public class CountrySqlDAOTests : DAOTests
    {
        [TestMethod]
        public void GetCountriesTest_Should_ReturnAllCountries()
        {
            // Arrange
            CountrySqlDAO dao = new CountrySqlDAO(this.connectionString);

            // Act
            IList<Country> list = dao.GetCountries();

            // Assert - Country count
            Assert.AreEqual(3, list.Count);
        }

        [DataTestMethod]
        [DataRow("North America", 2)]
        [DataRow("South America", 1)]
        [DataRow("Asia", 0)]
        [DataRow("", 3)]
        public void GetCountriesByContinent_Should_ReturnCorrectNumberOfCountries(string continent, int expectedCount)
        {
            // Arrange
            CountrySqlDAO dao = new CountrySqlDAO(this.connectionString);

            // Act
            IList<Country> list = dao.GetCountries(continent);

            // Assert - Country count
            Assert.AreEqual(expectedCount, list.Count);
        }
    }
}
