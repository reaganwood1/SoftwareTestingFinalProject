using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class ReturnControllerTests
    {
        [TestMethod]
        public void TestAddToRebateList()
        {
            int transactionID = 1;
            String rebatesBefore = RebateDB.GenerateRebateChecks();

            // Create Transaction
            int salesID = 1;
            int itemID = 1;
            int itemQuantity = 1;
            double itemCost = 2.29;
           // double rebatePercent = .05;
           // double totalRebate = itemQuantity * itemCost * rebatePercent;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            TransactionDB.AddTransaction(t1);

            Observer ob = new Observer((string s, State status) => { Assert.AreNotEqual(rebatesBefore, s); Assert.AreEqual(status, State.Rebate); });
            ReturnController controller = new ReturnController();
            controller.RegisterR(ob);
            controller.ProcessReturn(1,1,1); 
        }

        [TestMethod]
        public void TestRegisterRebateControllerObservber()
        {
            Observer ob = new Observer((string s, State status) => { Assert.IsTrue(true); });
            ReturnController controller = new ReturnController();
            controller.RegisterR(ob);
            controller.update("", State.Return);
        }
    }
}
