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
        /// <summary>
        /// Tests that the correct error message displays when a transaction rebate is attempted with a bad transaction id.
        /// </summary>
        [TestMethod]
        public void TestAddToRebateListTransactionIDDoesntExist()
        {
            int transactionID = -1;
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Transaction ID does not exist.", s); Assert.AreEqual(status, State.Rebate);});
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.AddToRebateList(DateTime.Now, transactionID);
        }

        /// <summary>
        /// Creates a transaction rebate 
        /// </summary>
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
            Product p1 = new Product("Diapers", itemID, itemCost);
            Tuple<Product, int> tuple1 = new Tuple<Product, int>(p1, itemQuantity);
            List<Tuple<Product, int>> items = new List<Tuple<Product, int>>();
            Transaction t1 = new Transaction(salesID, items);
            TransactionDB.AddTransaction(t1);

            // Add transaction to rebate list
            Observer ob = new Observer((string s, State status) => { Assert.AreNotEqual(rebatesBefore, s); Assert.AreEqual(status, State.Rebate); });
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.AddToRebateList(Convert.ToDateTime("06/02/2018"), transactionID);
        }

        /// <summary>
        /// Just tests that the observer for the rebate controller is called and operates
        /// </summary>
        [TestMethod]
        public void TestRegisterRebateControllerObservber()
        {
            Observer ob = new Observer((string s, State status) => { Assert.IsTrue(true); });
            RebateController controller = new RebateController();
            controller.RegisterRC(ob);
            controller.update("", State.Rebate);
        }

        /// <summary>
        /// Start of Transaction Controller Tests (Note I couldn't add any more C# test files so I had to combine tests into this file from other modules
        /// Tests creating a valid transaction in the transaction controller
        /// </summary>
        /// 
        [TestMethod]
        public void TestCreateTransaction()
        {
            //Create observer
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Transaction generated successfully!", s); Assert.AreEqual(status, State.Transaction); });

            //add transaction through the transaction controller
            TransactionController controller = new TransactionController();
            controller.RegisterR(ob);
            Tuple<int, int> productIDTransactionTyple = new Tuple<int, int>(1, 1);
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>
            {
                productIDTransactionTyple
            };
            controller.CreateTransaction(tuples);
        }

        /// <summary>
        /// Tests that the observer for the transaction can be called and works when called
        /// </summary>
        [TestMethod]
        public void TestRegisterObserverTransactionController()
        {
            //Create observer
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("", s); Assert.AreEqual(status, State.Transaction); });

            //add transaction through the transaction controller
            TransactionController controller = new TransactionController();
            controller.RegisterR(ob);
            controller.update("", State.Transaction);
        }

        /// <summary>
        /// Tests that an appropriate error message is displayed when a transaction is created using an invalid id not found
        /// </summary>
        [TestMethod]
        public void TestCreateTransactionInvalidItemID()
        {
            //Create observer
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Invalid item ID ", s); Assert.AreEqual(status, State.Transaction); });

            //add transaction through the transaction controller
            TransactionController controller = new TransactionController();
            controller.RegisterR(ob);
            Tuple<int, int> productIDTransactionTyple = new Tuple<int, int>(1, 0);
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>
            {
                productIDTransactionTyple
            };
            controller.CreateTransaction(tuples);
        }

        /// <summary>
        /// Try to create a transaction with a quantity of items that is invalid, display appropriate error message
        /// </summary>
        [TestMethod]
        public void TestCreateTransactionInvalidItemQuantity()
        {
            //Create observer
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Invalid item quantity ", s); Assert.AreEqual(status, State.Transaction); });

            //add transaction through the transaction controller
            TransactionController controller = new TransactionController();
            controller.RegisterR(ob);
            Tuple<int, int> productIDTransactionTyple = new Tuple<int, int>(0, 0);
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>
            {
                productIDTransactionTyple
            };
            controller.CreateTransaction(tuples);
        }


        /* NOTE: THIS Begins the return controller testing. There seems to be a problem with adding test modules to my version of visual studio. Basically the error is that tests will run in this module but not in any new module I create */
        /// <summary>
        /// This test fails because TransactionDB is static and can't be reset in between tests, need to work with software teams to try and find a solution
        /// </summary>
        [TestMethod]
        public void TestProcessReturnInReturnController()
        {
            //Create observer
            Observer ob1 = new Observer((string s, State status) => {  });

            //add transaction through the transaction controller
            TransactionController controller = new TransactionController();
            controller.RegisterR(ob1);
            Tuple<int, int> productIDTransactionTyple = new Tuple<int, int>(1, 1);
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>
            {
                productIDTransactionTyple
            };
            controller.CreateTransaction(tuples);

            //Create observer
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual("Success! Items returned.", s); Assert.AreEqual(status, State.Return); });

            //add transaction through the transaction controller
            ReturnController returnController = new ReturnController();
            returnController.RegisterR(ob);
            returnController.ProcessReturn(1, 1, 1);
        }
    }
}
