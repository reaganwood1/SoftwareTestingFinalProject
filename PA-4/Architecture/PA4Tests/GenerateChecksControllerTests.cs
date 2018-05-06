using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA_4_GUI;

namespace PA4Tests
{
    [TestClass]
    public class GenerateChecksControllerTests
    {

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
