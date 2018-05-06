using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class RebateDBTests
    {
        [TestMethod]
        public void AssertNoRebatesAtProgramStart()
        {
            String rebates = RebateDB.GenerateRebateChecks();
            Assert.AreEqual("There are no checks to Generate", rebates);
        }

        [TestMethod]
        public void AssertRebateNotAddedToRebateListBecauseDateOutOfRange()
        {
            DateTime dateInRange = Convert.ToDateTime("05/02/2018");
            Product product = new Product("Diapers", 2, 2.29);
            Tuple<Product, int> transactionTuple = new Tuple<Product, int>(product, 1);
            List<Tuple<Product, int>> transactions = new List<Tuple<Product, int>>();
            transactions.Add(transactionTuple);
            Transaction transaction = new Transaction(10, transactions);
            String rebates = RebateDB.AddRebateToList(transaction, dateInRange);
            Assert.AreNotEqual(rebates, "There are no checks to Generate");
        }

        [TestMethod]
        public void AssertRebateAtAddedToRebateList()
        {
            DateTime dateInRange = Convert.ToDateTime("06/02/2018");
            Product product = new Product("Diapers", 2, 2.29);
            Tuple<Product, int> transactionTuple = new Tuple<Product, int>(product, 1);
            List<Tuple<Product, int>> transactions = new List<Tuple<Product, int>>();
            transactions.Add(transactionTuple);
            Transaction transaction = new Transaction(10, transactions);
            String rebates = RebateDB.AddRebateToList(transaction, dateInRange);
            Assert.AreNotEqual("There are no checks to Generate", rebates);
        }
    }
}
