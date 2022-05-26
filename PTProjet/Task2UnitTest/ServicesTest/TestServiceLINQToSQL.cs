using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq.Mapping;
using System.IO;
using Task2UnitTest.Instrumentation;
using Services;



namespace Task2UnitTest.ServicesTest
{
    [TestClass]
    [DeploymentItem(@"Instrumentation\Library.mdf", @"Instrumentation")]
    public class TestServiceLINQToSQL
    {
        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"Instrumentation\Library.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
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
            //Assert.IsNull(service.getCatalogByTitle(title));
            //Assert.IsNull(service.getCatalogByAuthor(author));
            service.addCatalog(title,author);
            Assert.IsNotNull(service.getCatalogByTitle(title));
            Assert.IsNotNull(service.getCatalogByAuthor(author));
            Assert.IsTrue(service.getCatalogByAuthor(author).Author.Equals(author) );
            Assert.IsTrue(service.getCatalogByTitle(title).Title.Equals(title));
        }
        [TestMethod]
        public void testAddUser()
        {
            service = new DataInteraction(m_ConnectionString);
        }

        [TestMethod]
        public void testUpdateUser()
        {
            string firstname = "gunther";
            string lastname = "ekler";
            service.addUser(firstname,lastname);
            Assert.IsNotNull(service.getUserByLastName(lastname));
            service.setUser(service.getUserByLastName(lastname).idUser, "hansel", "grettel");
        }

        #region instrumentation
        // Connection string defined in LinqToSqlLibTests project settings.
        private static string m_ConnectionString;
        private static DataInteraction service;
        #endregion
    }
}
