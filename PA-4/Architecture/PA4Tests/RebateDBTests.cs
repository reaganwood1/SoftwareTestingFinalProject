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
        public void AssertRebateNotAddedToRebateListBecauseRebateDateBelowRange()
        {
            DateTime dateInRange = Convert.ToDateTime("05/30/2018");
            Product product = new Product("Diapers", 2, 2.29);
            Tuple<Product, int> transactionTuple = new Tuple<Product, int>(product, 1);
            List<Tuple<Product, int>> transactions = new List<Tuple<Product, int>>();
            transactions.Add(transactionTuple);
            Transaction transaction = new Transaction(10, transactions);
            String rebates = RebateDB.AddRebateToList(transaction, dateInRange);
            Assert.AreNotEqual(rebates, "There are no checks to Generate");
        }

        /// <summary>
        /// Error: Transaction date cannot be set for a given transaction, so this test will always fail
        /// </summary>
        [TestMethod]
        public void AssertRebateAtAddedToRebateList()
        {
            DateTime dateInRange = Convert.ToDateTime("06/03/2018");
            Product product = new Product("Diapers", 2, 2.29);
            Tuple<Product, int> transactionTuple = new Tuple<Product, int>(product, 1);
            List<Tuple<Product, int>> transactions = new List<Tuple<Product, int>>();
            transactions.Add(transactionTuple);
            Transaction transaction = new Transaction(10, transactions);
            String rebates = RebateDB.AddRebateToList(transaction, dateInRange);
            Assert.AreNotEqual("Added To Rebate Database.", rebates);
        }

        [TestMethod]
        public void AssertRebateNotAddedToRebateListBecauseRebateDateAboveMailListRange()
        {
            DateTime dateAboveMailRange = Convert.ToDateTime("07/15/2018");
            Product product = new Product("Diapers", 2, 2.29);
            Tuple<Product, int> transactionTuple = new Tuple<Product, int>(product, 1);
            List<Tuple<Product, int>> transactions = new List<Tuple<Product, int>>();
            transactions.Add(transactionTuple);
            Transaction transaction = new Transaction(10, transactions);
            String rebates = RebateDB.AddRebateToList(transaction, dateAboveMailRange);
            Assert.AreNotEqual(rebates, "Cannot add Rebate, not within proper Dates.");
        }
    }
}
