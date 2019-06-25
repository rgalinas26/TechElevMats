﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests
{
    [TestClass]
    public class LanguageSqlDAOTests
    {
        [DataTestMethod]
        [DataRow("USA", 2)]
        [DataRow("UTO", 1)]
        [DataRow("XYZ", 0)]
        public void GetLanguagesTest(string countryCode, int expectedCount)
        {
            // Arrange

            // Act

            // Assert - Language Count
        }

        [TestMethod]
        public void AddLanguage()
        {
            // Arrange

            // Act - Add another language to USA

            // Assert - Language Count increases by 1
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddLanguage_FailsBecauseLanguageExists()
        {
            // Arrange - create a new language that already exists in the USA

            // Act - try to add it
        }

        [TestMethod]
        public void RemoveLanguage()
        {
            // Arrange - create a language to remove

            // Act - remove it

            // Assert - language count decreases by 1

        }

    }
}