using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechElevator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Exercises.Tests.Classes
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod]
        public void Product_NameProperty()
        {
            Type type = typeof(Product);
            Product product = (Product)Activator.CreateInstance(type);

            PropertyInfo prop = type.GetProperty("Name");
            PropertyValidator.ValidateReadWrite(prop, "Name", typeof(string));
        }

        [TestMethod]
        public void Product_PriceProperty()
        {
            Type type = typeof(Product);
            Product product = (Product)Activator.CreateInstance(type);

            PropertyInfo prop = type.GetProperty("Price");
            PropertyValidator.ValidateReadWrite(prop, "Price", typeof(decimal));
        }

        [TestMethod]
        public void Product_WeightProperty()
        {
            Type type = typeof(Product);
            Product product = (Product)Activator.CreateInstance(type);

            PropertyInfo prop = type.GetProperty("WeightInOunces");
            PropertyValidator.ValidateReadWrite(prop, "WeightInOunces", typeof(double));
        }


    }
}