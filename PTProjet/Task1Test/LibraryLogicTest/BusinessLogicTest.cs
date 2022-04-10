using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.LibraryData;
using Task1.LibraryLogic;

namespace Task1Test.LibraryLogicTest
{
    [TestClass()]
    public class BusinessLogicTests
    {
       

        [TestMethod()]
        public void ConstructorTest()
        {
            DataLinkFixture dataLayerTest = new DataLinkFixture();
            BusinessLogic business = BusinessLogicAbstractAPI.CreateLayer(dataLayerTest);
            Assert.AreEqual<int>(1, dataLayerTest.ConnectedCount);
        }
    }
}

