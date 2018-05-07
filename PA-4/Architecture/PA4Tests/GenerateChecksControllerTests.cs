using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class GenerateChecksControllerTests
    {

        /// <summary>
        /// Test to see that the generate checks output matches what is returned from the RebateDB
        /// </summary>
        [TestMethod]
        public void TestGenerateChecks()
        {
            String rebateString = RebateDB.GenerateRebateChecks();

            Observer ob = new Observer((string s, State status) => { Assert.AreEqual(s, rebateString); Assert.AreEqual(State.Generate, status); } );
            GenerateChecksController controller = new GenerateChecksController();
            controller.RegisterGCC(ob);
            controller.GenerateChecks();
        }

        /// <summary>
        /// Test that the observer can be called which is the purpose of calling RegisterGCC
        /// </summary>
        [TestMethod]
        public void TestRegisterGCCByCallingObserver()
        {
            Observer ob = new Observer((string s, State status) => { Assert.IsTrue(true); });
            GenerateChecksController controller = new GenerateChecksController();
            controller.RegisterGCC(ob);
            controller.update("", State.Generate);
        }

        /// <summary>
        /// Simple test to make sure the observer for the ChecksController is called correctly
        /// </summary>
        [TestMethod]
        public void TestObserverDelegateCalledWithCorrectStringAndStatus()
        {
            String observerStringToUse = "HelloWorld";
            Observer ob = new Observer((string s, State status) => { Assert.AreEqual(s, observerStringToUse); Assert.AreEqual(State.Generate, status); });
            GenerateChecksController controller = new GenerateChecksController();
            controller.RegisterGCC(ob);
            controller.update(observerStringToUse, State.Generate);
        }
    }
}
