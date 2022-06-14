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

        public TestLibrary library;
        public NavigationService navigationService;

        [TestInitialize]
        public void TestInitialize()
        {
            library = new TestLibrary();
        }

        public void GenerateData_noDuplicate()
        {
            library.Addperson(new View.Model.User("John", "Doe"));
            library.Addperson(new View.Model.User("Jane", "Doe"));
            library.Addperson(new View.Model.User("Jack", "Doe"));
            library.Addperson(new View.Model.User("Jill", "Doe"));
            library.Addperson(new View.Model.User("Joe", "Doe"));


            library.Addstate(new State(new Catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new State(new Catalog("Stendhal", "Le Comte de Monte Cristo")));
            library.Addstate(new State(new Catalog("Shakespeare", "Hamlet")));
        }

        public void GenerateData_Duplicate()
        {
            library.Addperson(new View.Model.User("John", "Doe"));
            library.Addperson(new View.Model.User("Jane", "Doe"));
            library.Addperson(new View.Model.User("Jack", "Doe"));
            library.Addperson(new View.Model.User("Jill", "Doe"));
            library.Addperson(new View.Model.User("Joe", "Doe"));


            library.Addstate(new State(new Catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new State(new Catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new State(new Catalog("Victor Hugo", "Les Misérables")));
            library.Addstate(new State(new Catalog("Stendhal", "Le Comte de Monte Cristo")));
            library.Addstate(new State(new Catalog("Shakespeare", "Hamlet")));
            library.Addstate(new State(new Catalog("Shakespeare", "Hamlet")));
            library.Addstate(new State(new Catalog("Shakespeare", "Hamlet")));
            library.Addstate(new State(new Catalog("Shakespeare", "Hamlet")));
        }


        [TestMethod]
        public void Should_have_the_correct_number_into_db()
        {
            GenerateData_noDuplicate();
            int nbUser = 0;
            foreach(View.Model.User user in library.GetCustomers())
            {
                nbUser++;
            }
            Assert.AreEqual(5, nbUser);
        }

        [TestMethod]
        public void CanExecutre_should_be_false()
        {
            GenerateData_Duplicate();
            int nbBook = 0;
            foreach (View.Model.State state in library.GetStates())
            {
                nbBook++;
            }
            Assert.AreEqual(8, nbBook);
        }

        [TestMethod]
        public void CanExecute_should_be_true()
        {
            GenerateData_noDuplicate();
            int nbEvent = 0;
            foreach (State book in library.GetStates())
            {
                nbEvent++;
            }
            Assert.AreEqual(3, nbEvent);
        }

    }
}