using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    /// <summary>
    /// Test fails in exception case that is not handled
    /// </summary>
    [TestClass]
    public class RebateControllerTests
    {
        [TestMethod]
        public void TestAddToRebateListTransactionIDDoesntExist()
        {
            int transactionID = -1;
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Transaction ID does not exist.", s); Assert.AreEqual(status, State.Rebate);});
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.AddToRebateList(DateTime.Now, transactionID);
        }

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
            double rebatePercent = .05;
            double totalRebate = itemQuantity * itemCost * rebatePercent;
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            TransactionDB.AddTransaction(t1);

            Observer ob = new Observer((string s, State status) => { Assert.AreNotEqual(rebatesBefore, s); Assert.AreEqual(status, State.Rebate); });
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.AddToRebateList(Convert.ToDateTime("06/02/2018"), transactionID);
        }

        [TestMethod]
        public void TestRegisterRebateControllerObservber()
        {
            Observer ob = new Observer((string s, State status) => { Assert.IsTrue(true); });
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.update("", State.Rebate);
        }
    }
}
