using Microsoft.VisualStudio.TestTools.UnitTesting;
using View.Model;
using View.ViewModels;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace UnitTest_ProjetTask_2
{
    [TestClass]
    public class Test_ViewModel
    {

        public library library;
        public NavigationService navigationService;

        [TestInitialize]
        public void TestInitialize()
        {
            library = new library();
            navigationService = new NavigationService(new NavigationStore(), CreateAddBookViewModel);
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
            library.Addperson(new person("John", "Doe"));
            library.Addperson(new person("Jane", "Doe"));
            library.Addperson(new person("Jack", "Doe"));
            library.Addperson(new person("Jill", "Doe"));
            library.Addperson(new person("Joe", "Doe"));


            library.Addstate(new state(new catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new state(new catalog("Stendhal", "Le Comte de Monte Cristo")));
            library.Addstate(new state(new catalog("Shakespeare", "Hamlet")));
        }

        public void GenerateData_Duplicate()
        {
            library.Addperson(new person("John", "Doe"));
            library.Addperson(new person("Jane", "Doe"));
            library.Addperson(new person("Jack", "Doe"));
            library.Addperson(new person("Jill", "Doe"));
            library.Addperson(new person("Joe", "Doe"));


            library.Addstate(new state(new catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new state(new catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new state(new catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new state(new catalog("Stendhal", "Le Comte de Monte Cristo")));
            library.Addstate(new state(new catalog("Shakespeare", "Hamlet")));
            library.Addstate(new state(new catalog("Shakespeare", "Hamlet")));
            library.Addstate(new state(new catalog("Shakespeare", "Hamlet")));
            library.Addstate(new state(new catalog("Shakespeare", "Hamlet")));
        }

        //Used for random navigation service for testing purpose
        private AddBookViewModel CreateAddBookViewModel()
        {
            return new AddBookViewModel(library, navigationService);
        }


        [TestMethod]
        public void Should_have_the_correct_number_into_db()
        {
            GenerateData_noDuplicate();
            Assert.AreEqual(5, library.businessLogicAPI.dataAPI.newGetNbUser());

            DeleteBookViewModel viewmodel = new DeleteBookViewModel(library, navigationService);
            Assert.IsFalse(viewmodel.SubmitCommand.CanExecute(null));
        }

        [TestMethod]
        public void CanExecutre_should_be_false()
        {
            GenerateData_Duplicate();
            Assert.AreEqual(5, library.businessLogicAPI.dataAPI.newGetNbUser());

            AddBookViewModel viewmodel = new AddBookViewModel(library, navigationService);
            Assert.IsFalse(viewmodel.SubmitCommand.CanExecute(null));
        }

        [TestMethod]
        public void CanExecute_should_be_true()
        {
            GenerateData_noDuplicate();
            Assert.AreEqual(5, library.businessLogicAPI.dataAPI.newGetNbUser());

            DeleteBookViewModel viewmodel = new DeleteBookViewModel(library, navigationService);
            viewmodel.Author = "Victor Hugo";
            viewmodel.Title = "Les Misérables";
            Assert.IsTrue(viewmodel.SubmitCommand.CanExecute(null));
        }

    }
}