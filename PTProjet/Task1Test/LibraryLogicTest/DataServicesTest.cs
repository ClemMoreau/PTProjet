using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;
using Task1.LibraryLogic;
namespace Task1Test.LibraryLogicTest
{
    [TestClass()]
    public class DataServicesTest
    {
        [TestMethod()]
        public void BorrowABookTest()
        {
            BusinessLogic businessLogic = BusinessLogicAbstractAPI.CreateLayer(null);
            State booktest = new State("The Lord of the Rings", "J.R.R Tolkien", 3);
            User usertest = new User("Jo", "Lopez");
            
            businessLogic.data.Catalog.Add(booktest.catalog);

            businessLogic.data.borrowABook(booktest, usertest);

            Assert.AreEqual<int>(2, booktest.catalog.nbAvailable);
            
        }

        [TestMethod()]
        public void ReturnABookTest()
        {
            BusinessLogic businessLogic = BusinessLogicAbstractAPI.CreateLayer(null);
            State booktest = new State("The Crown", "Thomus", 3);
            User usertest = new User("Jo", "Lopez");

            businessLogic.data.Catalog.Add(booktest.catalog);

            businessLogic.data.returnABook(booktest, usertest);
            

            Assert.AreEqual<int>(4, booktest.catalog.nbAvailable);

        }

    }
}
