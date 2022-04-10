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
    public class Catalogtest
    {
        [TestMethod]
        public void catalogTest()
        {
            Catalog catalog = new Catalog("Angular Book", "Angular Author", 3);
            string testTitle = "Angular Book";
            string testAuthor = "Angular Author";
            int testAvailable = 3;

            Assert.AreEqual<string>(testTitle,catalog.title);
            Assert.AreEqual<string>(testAuthor,catalog.author);
            Assert.AreEqual<int>(testAvailable, catalog.nbAvailable);
        }
        [TestMethod]
        public void addTest()
        {
            Catalog catalog = new Catalog("Angular Book", "Angular Author", 3);
            catalog.addBook();
            Assert.AreEqual<int>(4,catalog.nbAvailable);

        }

        [TestMethod]
        public void removeTest()
        {
            Catalog catalog = new Catalog("Angular Book", "Angular Author", 3);
            
            catalog.removeBook();
            Assert.AreEqual<int>(2, catalog.nbAvailable);

        }
    }
}
