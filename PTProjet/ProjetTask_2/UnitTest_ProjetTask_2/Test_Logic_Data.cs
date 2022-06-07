using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetTask_2.LogicLayer;
using System;
using System.IO;

namespace UnitTest_ProjetTask_2
{
    [TestClass]
    public class Test_Logic_Data
    {
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.

        public BusinessLogicAPI API;

        [TestInitialize]
        public void TestInitialize()
        {
            API = new BusinessLogicAPI(new DataAPI());
        }

        [TestCleanup]
        public void Cleanup()
        {
            string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Programming_Technologies;Data Source=PC-AURANE";
            string script = File.ReadAllText("../../TestCleanup.sql");
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(script);
        }

        public void GenerateData_noDuplicate()
        {
            API.service.AddUser("John", "Doe");
            API.service.AddUser("Jane", "Doe");
            API.service.AddUser("Jack", "Doe");
            API.service.AddUser("Jill", "Doe");
            API.service.AddUser("Joe", "Doe");


            API.service.AddBook("Victor Hugo", "Les Misérables", 1);
            API.service.AddBook("Victor Hugo", "Le Petit Prince", 1);
            API.service.AddBook("Stendhal", "Le Comte de Monte Cristo", 1);
            API.service.AddBook("Shakespeare", "Hamlet", 1);
            API.service.AddBook("Shakespeare", "Romeo et Juliette", 1);
        }

        public void GenerateData_severalBook()
        {
            API.service.AddUser("John", "Doe");
            API.service.AddUser("Jane", "Doe");
            API.service.AddUser("Jack", "Doe");
            API.service.AddUser("Jill", "Doe");
            API.service.AddUser("Joe", "Doe");

            API.service.AddBook("Shakespeare", "Hamlet", 1);
            API.service.AddBook("Shakespeare", "Romeo et Juliette", 3);
            API.service.AddBook("Victor Hugo", "Les Misérables", 5);
            API.service.AddBook("Victor Hugo", "Le Petit Prince", 1);
            API.service.AddBook("Stendhal", "Le Comte de Monte Cristo", 2);
        }

        [TestMethod]
        public void Should_add_the_correct_number_of_data()
        {
            GenerateData_severalBook();
            Assert.AreEqual(5, API.service.getNbUser());
            Assert.AreEqual(12, API.service.getNbBook());
        }

        [TestMethod]
        public void Should_change_the_availability()
        {
            GenerateData_noDuplicate();
            API.service.BorrowBook("Shakespeare", "Hamlet", "Jane", "Doe");
            Assert.IsFalse(API.service.getAvailability("Shakespeare", "Hamlet"));
        }

        [TestMethod]
        public void Should_not_change_the_availability()
        {
            GenerateData_noDuplicate();
            API.service.BorrowBook("Shakespeare", "Hamlet", "Jane", "Doe");
            API.service.ReturnBook("Shakespeare", "Hamlet", "Jane", "Doe");
            Assert.IsTrue(API.service.getAvailability("Shakespeare", "Hamlet"));
        }

        [TestMethod]
        public void Should_throw_UserNotFound_Exception()
        {
            GenerateData_severalBook();

            Assert.ThrowsException<ArgumentException>(() => API.service.BorrowBook("Shakespeare", "Hamlet", "John", "Smith"), "User not found");
        }

        [TestMethod]
        public void Should_throw_BookNotFound_Exception()
        {
            GenerateData_severalBook();

            Assert.ThrowsException<ArgumentException>(() => API.service.BorrowBook("Shakespeare", "Macbeth", "John", "Smith"), "Book not found");
        }

    }
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
}