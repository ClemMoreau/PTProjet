using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq.Mapping;
using System.IO;
using TestProjectTask2.Instrumentation;
using Services;


namespace TestProjectTask2.ServicesTest
{
    [TestClass]
    [DeploymentItem(@"Instrumentation\Library.mdf", @"Instrumentation")]
    public class TestServiceLINQToSQL
    {
        [ClassInitialize]
        public static void DataInteractionInitializeTest(TestContext context)
        {
            m_ConnectionString = "";
            service = new DataInteraction(m_ConnectionString);
        }

        [TestMethod]
        public void testAddCatalog()
        {
            string title = "Fuze like balloon";
            string author = "Helmut";
           
            service.addCatalog(title, author);
            Assert.IsNotNull(service.getCatalogByTitle(title));
            Assert.IsNotNull(service.getCatalogByAuthor(author));
            Assert.IsTrue(service.getCatalogByAuthor(author).Author.Equals(author));
            Assert.IsTrue(service.getCatalogByTitle(title).Title.Equals(title));
        }
        [TestMethod]
        public void testAddUser()
        {
            string firstname = "rupish";
            string lastname = "m3";
            service.addUser(firstname, lastname);
            Assert.IsNotNull(service.getUserByLastName(lastname));
            Assert.IsTrue(service.getUserByLastName(lastname).LastName.Equals(lastname));
        }

        [TestMethod]
        public void testUpdateUser()
        {
            //service = new DataInteraction(m_ConnectionString);

            string firstname = "gunther";
            string lastname = "ekler";
            service.addUser(firstname, lastname);
            Assert.IsNotNull(service.getUserByLastName(lastname));
            service.setUser(service.getUserByLastName(lastname).idUser, "hansel", "grettel");
            Assert.IsNull(service.getUserByLastName(lastname));
            Assert.IsNotNull(service.getUserByLastName("grettel"));
        }

        [TestMethod]

        public void testUpdateCatalog()
        {
            string title = "Hounga Bounga";
            string author = "Helmut";
            service.addCatalog(title, author); 
            Assert.IsNotNull(service.getCatalogByTitle(title));
            service.setCatalog(service.getCatalogByTitle(title).idCatalog, "fritz", "hola hoop");
            Assert.IsNull(service.getCatalogByTitle(title));
            Assert.IsNotNull(service.getCatalogByAuthor("fritz"));
        }

        [TestMethod]
        public void testDeleteCatalog()
        {
            string firstname = "david";
            string lastname = "ghetto";
            service.addUser(firstname, lastname);
            int idUser = service.getUserByLastName(lastname).idUser;
            int nbUser = service.getUsers().Count();
            service.deleteUserByID(idUser);
            Assert.AreEqual(nbUser - 1, service.getUsers().Count()) ;
        }

        #region instrumentation
        // Connection string defined in LinqToSqlLibTests project settings.
        private static string m_ConnectionString;
        private static DataInteraction service;
        #endregion
    }
}
