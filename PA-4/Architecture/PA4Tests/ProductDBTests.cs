using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class ProductDBTests
    {
        /// <summary>
        /// Asserts that a product retrieved form the ProductDB is the item in the right index position in the product
        /// db items list
        /// </summary>
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
        /// Tests that if a product id entered is less than 0 (ie not found), that it throws a specified exception. 
        /// The program however tries to index an array and throws an uncaught exception and fails
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AttemptGetProductByIDNoProductByIDFound()
        {
            List<Product> products = ProductDB.GetProductList();
            int numberOfProducts = products.Count;
            Product returnedProduct = ProductDB.GetProduct(numberOfProducts+1);
        }

        /// <summary>
        /// Check that the products list is greater than 0
        /// </summary>
        [TestMethod]
        public void GetProductListCheckGreaterThan0Products()
        {
            List<Product> products = ProductDB.GetProductList();
            Assert.IsTrue(products.Count > 0);
        }
    }
}
