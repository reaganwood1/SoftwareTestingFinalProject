using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class ProductDBTests
    {
        [TestMethod]
        public void GetProductByID()
        {
            List<Product> products = ProductDB.GetProductList();
            int numberOfProducts = products.Count;
            Random randomGenerator = new Random();
            int productIntToSelect = randomGenerator.Next(1, numberOfProducts);
            Product productToSelect = products[productIntToSelect-1];
            Product returnedProduct =ProductDB.GetProduct(productIntToSelect);
            Assert.AreEqual(returnedProduct, productToSelect);
        }

        /// <summary>
        /// Untestable how code is currently written
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AttemptGetProductByIDNoProductByIDFound()
        {
            List<Product> products = ProductDB.GetProductList();
            int numberOfProducts = products.Count;
            Product returnedProduct = ProductDB.GetProduct(numberOfProducts+1);
        }

        [TestMethod]
        public void GetProductListCheckNotNull()
        {
            List<Product> products = ProductDB.GetProductList();
            Assert.IsNotNull(products);
        }
    }
}
