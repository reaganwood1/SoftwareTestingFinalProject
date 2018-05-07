using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class TransasctionDBTests
    {
        /// <summary>
        /// Tests that transactions can be added to the TransactionsDB
        /// </summary>
        [TestMethod]
        public void TestAddTransasction()
        {
            Tuple<Product, int> item1 = new Tuple<Product, int>((new Product("Milk", 1, 1.89)), 3);
            Tuple<Product, int> item2 = new Tuple<Product, int>((new Product("Eggs", 2, 1.29)), 3);

            List<Tuple<Product, int>> list = new List<Tuple<Product, int>>();

            list.Add(item1);
            list.Add(item2);

            Transaction tran = new Transaction(1, list);

            TransactionDB.AddTransaction(tran);

            Assert.AreEqual(TransactionDB.GetTransactionInt(), 1);


        }

        /// <summary>
        /// Tests that a transaction entered into the database can be retrieved
        /// </summary>
        [TestMethod]
        public void TestGetTransaction()
        {
            Tuple<Product, int> item1 = new Tuple<Product, int>((new Product("Milk", 1, 1.89)), 3);
            Tuple<Product, int> item2 = new Tuple<Product, int>((new Product("Eggs", 2, 1.29)), 3);

            List<Tuple<Product, int>> list = new List<Tuple<Product, int>>();

            list.Add(item1);
            list.Add(item2);

            Transaction tran = new Transaction(1, list);

            TransactionDB.AddTransaction(tran);

            //Assert.AreEqual(TransactionDB.GetTransactionInt(), 1);

            Transaction tr = TransactionDB.GetTransaction(1);

            Assert.AreEqual(tr, tran);

        }

        /// <summary>
        /// Tests that transactions can be retrieved from the DB by their int identifier. Error adding transactions to the DB
        /// </summary>
        [TestMethod]
        public void TestGetTransasctionInt()
        {
            Tuple<Product, int> item1 = new Tuple<Product, int>((new Product("Milk", 1, 1.89)), 3);
            Tuple<Product, int> item2 = new Tuple<Product, int>((new Product("Eggs", 2, 1.29)), 3);


            List<Tuple<Product, int>> list = new List<Tuple<Product, int>>();

            list.Add(item1);
            list.Add(item2);

            Transaction tran = new Transaction(1, list);

            TransactionDB.AddTransaction(tran);


            Tuple<Product, int> item3 = new Tuple<Product, int>((new Product("Milk", 1, 1.89)), 3);
            Tuple<Product, int> item4 = new Tuple<Product, int>((new Product("Eggs", 2, 1.29)), 3);

            list = new List<Tuple<Product, int>>();

            list.Add(item3);
            list.Add(item4);


            Transaction tran2 = new Transaction(2, list);

            TransactionDB.AddTransaction(tran2);

            Assert.AreEqual(TransactionDB.GetTransactionInt(), 2);
        }


    }
}
