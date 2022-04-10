using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.LibraryData;

namespace Task1Test.LibraryDataTest
{
    [TestClass]
    public class StateTest
    {
        [TestMethod]
        public void BorrowTest()
        {
            State state = new State("","", 0);
            state.BorrowOne();

            Assert.AreEqual<int>(-1, state.catalog.nbAvailable);

        }

        [TestMethod]
        public void ReturnTest()
        {
            State state = new State("", "", 0);
            state.ReturnOne();

            Assert.AreEqual<int>(1, state.catalog.nbAvailable);

        }
    }
}
