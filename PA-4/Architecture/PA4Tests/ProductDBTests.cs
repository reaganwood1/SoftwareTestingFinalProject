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
            int productIntToSelect = randomGenerator.Next(0, numberOfProducts - 1);
            Product productToSelect = products[productIntToSelect];
            Product returnedProduct = ProductDB.GetProduct(productIntToSelect);
            Assert.Equals(returnedProduct, productToSelect);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AttemptGetProductByIDNoProductByIDFound()
        {
            List<Product> products = ProductDB.GetProductList();
            int numberOfProducts = products.Count;
            Product returnedProduct = ProductDB.GetProduct(numberOfProducts);
        }

        [TestMethod]
        public void GetProductListCheckNotNull()
        {
            List<Product> products = ProductDB.GetProductList();
            Assert.IsNotNull(products);
        }
    }
}
