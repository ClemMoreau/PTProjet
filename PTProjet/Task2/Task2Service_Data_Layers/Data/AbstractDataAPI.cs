using System;
using System.Collections.Generic;
using System.Linq;
using ProjetTask_2.Data;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTask_2.DataLayer
{
    public abstract class AbstractDataAPI
    {
        private DataContext dataContext = new DataContext();

        private List<Catalog> catalogs = new List<Catalog>();
        private List<State> states = new List<State>();
        private List<User> users = new List<User>();
        private List<Event> events = new List<Event>();

        public AbstractDataAPI()
        {
            catalogs = dataContext.GetTable<Catalog>().ToList();
            users = dataContext.GetTable<User>().ToList();
            events = dataContext.GetTable<Event>().ToList();
            states = dataContext.GetTable<State>().ToList();

            dataContext.Catalog.InsertOnSubmit(new Catalog() { title = "coucoujetest", author = "jesperequecamarche" });
            dataContext.SubmitChanges();
        }

        public static AbstractDataAPI createAPI()
        {
            return new DataLayer.DataAPI();
        }
        
        /*Search a catalog id by its title and author*/
        private int searchCatalog(string title, string author)
        {
            foreach (Catalog c in catalogs)
            {
                if (c.title == title && c.author == author)
                {
                    return c.id;
                }
            }
            return -1;
        }
        private State SearchBook(string title, string author, bool available)
        {
            int truefalse;
            if (available)
            {
                truefalse = 1;
            }
            else
            {
                truefalse = 0;
            }

            int id = searchCatalog(title, author);

            //If there is several copies of the book, there is several state in the list
            Predicate<State> predicate = x => x.book == id && x.available == truefalse;
            if (states.Exists(predicate))
            {
                return states.Find(predicate);
            }
            else
            {
                return null;
            }
        }
        private User SearchUser(string Name, string Surname)
        {
            //We suppose that there is only one user with the same name and surname
            Predicate<User> predicate = x => x.name == Name && x.surname == Surname;
            if (users.Exists(predicate))
            {
                return users.Find(predicate);
            }
            else
            {
                return null;
            }
        }


        public void newBorrow(String Title, String Author, String Name, String Surname)
        {
            State state = SearchBook(Title, Author, true);
            if (state != null)
            {
                User User = SearchUser(Name, Surname);
                if (User != null)
                {
                    dataContext.Event.InsertOnSubmit(new Event { stateId = state.id, personId = User.id, description = "Borrow" });
                    dataContext.SubmitChanges();
                    events = dataContext.GetTable<Event>().ToList();
                }
                else
                {
                    throw new ArgumentException("User not found");
                }
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }
        public void newReturn(String Title, String Author, String Name, String Surname)
        {
            User User = SearchUser(Name, Surname);
            if (User == null)
            {
                throw new ArgumentException("User not found");
            }
            else
            {
                State state = SearchBook(Title, Author, false);
                if (state != null)
                {
                    dataContext.Event.InsertOnSubmit(new Event { stateId = state.id, personId = User.id, description = "Return" });
                    dataContext.SubmitChanges();
                    events = dataContext.GetTable<Event>().ToList();
                }
                else
                {
                    throw new ArgumentException("Book not found");
                }
            }
        }
        public void newChangeAvailabilityState(String Title, String Author, bool avail)
        {
            State state = SearchBook(Title, Author, avail);
            if (state != null)
            {
                state.available = (avail ? 0 : 1);
                dataContext.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }
        public void newAddBook(String Title, String Author, int Quantity)
        {
            int id = searchCatalog(Title, Author);

            if (id == -1)
            {
                dataContext.Catalog.InsertOnSubmit(new Catalog { title = Title, author = Author });
                dataContext.SubmitChanges();
                catalogs = dataContext.GetTable<Catalog>().ToList();
                id = searchCatalog(Title, Author);
            }

            for (int i = 0; i < Quantity; i++)
            {
                dataContext.State.InsertOnSubmit(new State { book = id, available = 1 });
                dataContext.SubmitChanges();
                states = dataContext.GetTable<State>().ToList();

            }

        }
        public void newDeleteBook(String Title, String Author)
        {
            int id = searchCatalog(Title, Author);
            Predicate<Catalog> Predicate = x => x.id == id;
            Catalog catalog;
            if (catalogs.Exists(Predicate))
            {
                catalog = catalogs.Find(Predicate);
            }
            else
            {
                throw new ArgumentException("Book not found");
            }

            Predicate<State> predicate = x => x.id == catalog.id;

            if (states.Exists(predicate))
            {
                foreach (State s in states.FindAll(predicate))
                {
                    dataContext.State.DeleteOnSubmit(s);
                }
            }
            dataContext.Catalog.DeleteOnSubmit(catalog);
            dataContext.SubmitChanges();
            catalogs = dataContext.GetTable<Catalog>().ToList();

        }
        public void newAddUser(String Name, String Surname)
        {
            dataContext.User.InsertOnSubmit(new User { name = Name, surname = Surname });
            dataContext.SubmitChanges();
            users = dataContext.GetTable<User>().ToList();
        }
        public int newGetNbUser()
        {
            return users.Count;
        }
        public int newGetNbBook()
        {
            return states.Count;
        }
        public bool newGetAvailability(String Author, String Title)
        {
            State state = SearchBook(Title, Author, true);
            if (state != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void Borrow(String Title, String Author, String Name, String Surname);
        public abstract void Return(String Title, String Author, String Name, String Surname);

    }

    internal class DataAPI : AbstractDataAPI
    {
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            newBorrow(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, true); //Looking for state w available = true to make it false

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            newReturn(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, false); //Looking for state w available = false to make it true
        }
    }
}

