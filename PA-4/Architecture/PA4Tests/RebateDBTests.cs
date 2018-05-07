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
        /// <summary>
        /// This test fails intermittantly because the rebatesDB doesn't reset because of its static definition and no way to reset it. Other tests may interfear
        /// </summary>
        [TestMethod]
        public void AssertNoRebatesAtProgramStart()
        {
            String rebates = RebateDB.GenerateRebateChecks();
            Assert.AreEqual("There are no checks to Generate", rebates);
        }

        /// <summary>
        /// Tests that if a rebate is below the range for an acceptable rebate that it is not added to the rebatesDB
        /// </summary>
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
        /// Tests that Rebate is added to the rabate list when date is in the correct range
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

        /// <summary>
        /// Tests that if a rebate is attempted with a rebate date that is after the acceptable range that a rebate is not generated
        /// </summary>
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
