using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class ProductModelTest
    {
        [TestMethod]
        public void TestProductMake()
        {
            Product p = new Product("Test", 4, 8.99);
            Product c = new Product("Test", 4, 8.99);
            Assert.AreEqual(p.GetName, c.GetName);
        }

        /// <summary>
        /// Tests that the product name getter returns the product name
        /// </summary>
        [TestMethod]
        public void TestGetName()
        {
            Product p = new Product("Test", 4, 8.99);
            Assert.AreEqual(p.GetName, "Test");
        }

        /// <summary>
        /// Tests that the product price getter returns the product price
        /// </summary>
        [TestMethod]
        public void TestGetPrice()
        {
            Product p = new Product("Test", 4, 8.99);
            Assert.AreEqual(p.GetPrice, 8.99);
        }

        /// <summary>
        /// Tests that the product id getter returns the product id
        /// </summary>
        [TestMethod]
        public void TestGetID()
        {
            Product p = new Product("Test", 4, 8.99);
            Assert.AreEqual(p.ID, 4);
        }

       



        //Assert.AreEqual(p, new Product("Test", 4, 8.99));
    }
}
