using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class TransactionTests
    {
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
        /// No way to set the transaction id, this test will fail
        /// </summary>
        [TestMethod]
        public void TestGetTransactionID()
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
