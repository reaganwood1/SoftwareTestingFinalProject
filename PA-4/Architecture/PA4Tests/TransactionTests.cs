using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class TransactionTests
    {
        /// <summary>
        /// Error calculating the transaction rebate amount
        /// Suppossed to return the transaction rebate amount if items can be rebated
        /// </summary>
        [TestMethod]
        public void TestTransactionIncludeRebate()
        {
            int salesID = 1;
            int itemID = 1;
            int itemQuantity = 1;
            double itemCost = 2.29;
            double rebatePercent = .05;
            double totalRebate = itemQuantity * itemCost * rebatePercent;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            String rebate = t1.IncludeRebate(rebatePercent);
            Assert.AreEqual(rebate, "Sales Number:" + salesID + "\nRebate Total: $" + itemCost + "\n");
        }

        /// <summary>
        /// Tests that a transaction receipt is generated with text
        /// </summary>
        [TestMethod]
        public void TestFormatTransactionReceipt()
        {
            int salesID = 1;
            int itemID = 1;
            int itemQuantity = 1;
            double itemCost = 2.29;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            Assert.AreNotEqual(t1.FormatReceipt(), "");
        }

        /// <summary>
        /// No way to set the transaction date, this test will fail
        /// Gets that transaction date
        /// </summary>
        [TestMethod]
        public void TestGetTransactionDate()
        {
            int salesID = 1;
            int itemID = 1;
            int itemQuantity = 1;
            double itemCost = 2.29;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            Assert.AreEqual(t1.GetTD, null);
        }

        /// <summary>
        /// Gets a list of items present in the transaction
        /// </summary>
        [TestMethod]
        public void GetItems()
        {
            int salesID = 1;
            int itemID = 1;
            int itemQuantity = 1;
            double itemCost = 2.29;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);

            List<Tuple<Product, int>> itemsInTransaction = t1.GetItems;
            Assert.AreEqual(itemsInTransaction, items);
        }
    }


}
