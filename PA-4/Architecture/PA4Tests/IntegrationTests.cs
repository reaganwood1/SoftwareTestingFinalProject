using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestAllTestDB()
        {
            Product p = new Product("Test", 1, 1.99);

            Tuple<Product, int> tuple = new Tuple<Product, int>(p, 1);

            List<Tuple<Product, int>> l = new List<Tuple<Product, int>>();

            l.Add(tuple);

            Transaction trans = new Transaction(1, l);

            TransactionDB.AddTransaction(trans);

            Assert.Equals(TransactionDB.GetTransaction(1).GetItems[0].Item1.GetName, "Test");

        }
    }
}
