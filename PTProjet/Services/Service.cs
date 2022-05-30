using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructuralData;

namespace Services
{
    public abstract class Service
    {
        protected LibraryCatalogDataContext context;

        public Service(string connectionstring)
        {
            context = new LibraryCatalogDataContext(connectionstring);
        }
        #region User methods
        abstract public IEnumerable<User> getUsers();
        abstract public User getUserById(int _userId);
        abstract public User getUserByLastName(string _lastname);
        abstract public bool addUser(string _firstname, string _lastname);
        abstract public bool setUser(int _id, string _firstname, string _lastname);
        abstract public bool deleteUserByID(int _userId);
        #endregion

        #region Event Method
        abstract public IEnumerable<Event> getEvents();
        abstract public Event getEventsbyId(int _eventId);
        abstract public IEnumerable<Event> getEventByCatId(int _catalogId);
        abstract public IEnumerable<Event> getEventByUserId(int _userId);

        abstract public void addEvent(int _catalogid, int _userId);

        abstract public void deleteEventById(int _eventId);

        #endregion
        #region Catalog Method
        public abstract IEnumerable<Catalog> getCatalogs();
        public abstract Catalog getCatalogById(int _catalogId);
        public abstract Catalog getCatalogByTitle(string _title);
        public abstract Catalog getCatalogByAuthor(string _author);
        public abstract void addCatalog(string _title, string _author);
        public abstract bool setCatalog(int _catalogId, string _author, string _title);
        public abstract void deleteCatalog(int _catalogId);

        #endregion

        public static Service CreateService(string connectionString)
        {
            return new DataInteraction(connectionString);
        }

    }

    public class DataInteraction : Service
    {
        public DataInteraction(string connectionString) : base(connectionString)
        {

        }
        #region User Method Declaration
        override public IEnumerable<User> getUsers()
        {
            return context.User.ToList();
        }

        override public User getUserById(int _userId)
        {
            foreach(User u in context.User.ToList())
            {
                if (u.idUser.Equals(_userId))
                {
                    return u;
                }
            }
            return null;
        }
        override public User getUserByLastName(string _lastname)
        {
            foreach (User u in context.User.ToList())
            {
                if (u.LastName.Equals(_lastname))
                {
                    return u;
                }
            }
            return null;
        }

        override public bool addUser(string _firstname, string _lastname)
        {
            int userId = 0;
            if (context.User.Count() >= 1)
            {
                userId = context.User.Max(u => u.idUser) + 1;
            }

            User newUser = new User
            {
                idUser = userId,
                FirstName = _firstname,
                LastName = _lastname
            };
            context.User.InsertOnSubmit(newUser);
            context.SubmitChanges();
            return true;
        }

        override public bool setUser(int _id, string _firstname, string _lastname)
        {
            User user = context.User.SingleOrDefault(i => i.idUser == _id);
            user.LastName = _lastname;
            user.FirstName = _firstname;

            context.SubmitChanges();
            return true;

        }

        override public bool deleteUserByID(int _userId)
        {
            User usertodelete = context.User.SingleOrDefault(user => user.idUser == _userId);
            context.User.DeleteOnSubmit(usertodelete);
            context.SubmitChanges();
            return true;
        }
        #endregion

        #region Catalog Method Declaration
        override public IEnumerable<Catalog> getCatalogs()
        {
            return context.Catalog.ToList();
        }

        override public Catalog getCatalogById(int _catalogId)
        {
            foreach (Catalog catalog in context.Catalog.ToList())
            {
                if (catalog.idCatalog.Equals(_catalogId))
                {
                    return catalog;
                }
            }
            return null;
        }

        override public Catalog getCatalogByTitle(string _title)
        {
            foreach(Catalog catalog in context.Catalog.ToList())
            {
                if (catalog.Title.Equals(_title))
                {
                    return catalog;
                }
            }
            return null;
        }

        override public Catalog getCatalogByAuthor(string _author)
        {
            foreach (Catalog catalog in context.Catalog.ToList())
            {
                if (catalog.Author.Equals(_author)){
                    return catalog;
                }
            }
            return null;
        }
    
        override public void addCatalog(string _title, string _author)
        {
            int catalogId = 0;
            if (context.Catalog.Count() >= 1)
            {
                catalogId = context.Catalog.Max(catalog => catalog.idCatalog) + 1;
            }
            Catalog newCatalog = new Catalog
            {
                idCatalog = catalogId,
                Author = _author,
                Title = _title
            };
            context.Catalog.InsertOnSubmit(newCatalog);
            context.SubmitChanges();
        }

        override public bool setCatalog(int _catalogId, string _author, string _title)
        {
            Catalog catalog = context.Catalog.SingleOrDefault(id => id.idCatalog == _catalogId);
            catalog.Title = _title;
            catalog.Author = _author;
            context.SubmitChanges();
            return true;
        }

        override public void deleteCatalog(int _catalogId)
        {
            Catalog catalog = context.Catalog.FirstOrDefault(id => id.idCatalog == _catalogId);
            context.Catalog.DeleteOnSubmit(catalog);
            context.SubmitChanges();
        }
        #endregion

        #region Event Method Declaration
        override public IEnumerable<Event> getEvents()
        {
            return context.Event.ToList();
        }

        override public Event getEventsbyId(int _eventId)
        {
            //List<Event> 
            foreach(Event e in context.Event.ToList())
            {
                if (e.idEvent.Equals(_eventId))
                {
                    return e;
                }
            }
            return null;
         }

        override public IEnumerable<Event> getEventByCatId(int _catalogId)
        {
            List<Event> result = new List<Event>();
            foreach (Event e in context.Event)
            {
                if (e.idCatalog == _catalogId)
                {
                    result.Add(e);
                }
            }
            return result;
        }

        override public IEnumerable<Event> getEventByUserId(int _userId)
        {
            List<Event> result = new List<Event>();
            foreach (Event e in context.Event)
            {
                if (e.idUser == _userId)
                {
                    result.Add(e);
                }
            }
            return result;
        }

        override public void addEvent(int _catalogid, int _userId)
        {
            if (context.User.SingleOrDefault(u => u.idUser.Equals(_userId)) != null &&
                context.Catalog.SingleOrDefault(c => c.idCatalog.Equals(_catalogid)) != null)
            {
                int eventid = 0;
                if (context.Event.Count() >= 1)
                {
                    eventid = context.Event.Max(e => e.idEvent) + 1;
                }
                Event newEvent = new Event
                {
                    idEvent = eventid,
                    idCatalog = _catalogid,
                    idUser = _userId
                };
                context.Event.InsertOnSubmit(newEvent);
                context.SubmitChanges();
             }
        }

        override public void deleteEventById(int _eventId)
        {
            Event ev = context.Event.FirstOrDefault(e => e.idEvent == _eventId);
            context.Event.DeleteOnSubmit(ev);
            context.SubmitChanges();
    
        }
        #endregion
    }
}
