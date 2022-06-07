using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProjetTask_2.LogicLayer;

namespace View.Model
{
    public class Library
    {
        public  BusinessLogicAPI businessLogicAPI;
        private readonly List<Event> _actions;
        private readonly List<State> _stock;
        private readonly List<User> _users;
        private readonly List<Catalog> _catalog;

        public Library()
        {
            businessLogicAPI = new BusinessLogicAPI();
            _actions = new List<Event>();
            _stock = new List<State>();
            _users = new List<User>();
            _catalog = new List<Catalog>();
        }

        public Library(BusinessLogicAPI businessLogicAPI)
        {
            _actions = new List<Event>();
            _stock = new List<State>();
            _users = new List<User>();
            _catalog = new List<Catalog>();
        }

        public IEnumerable<State> GetStock()
        {
            return _stock;
        }

        public IEnumerable<Catalog> GetCatalogs()
        {
            return _catalog;
        }

        public IEnumerable<Event> GetActions(){
            
            return _actions;
        }

        public IEnumerable<State> GetStateByTitle(string title)
        {
            return _stock.Where(s => s.catalog.title == title);
        }

        public Catalog GetCatalog(string title, string author)
        {
            return _catalog.First(c => c.title == title && c.author == author);
        }

        public IEnumerable<User> GetCustomers()
        {
            return _users;
        }
        
        public bool ExistCustomer(string name, string surname)
        {
            foreach (User user in _users)
            {
                if (user.name == name && user.surname == surname)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetCustomersByName(string name, string surname)
        {
            if (ExistCustomer(name, surname))
            {
                return _users.First(u => u.name == name && u.surname == surname);
            }
            else return null;
        }

        public void NewAction(String title, String author, User Person, String description)
        {
            if (catalogExist(title, author))
            {
                if (description == "Borrow")
                {
                    State state = _stock.First(s => s.catalog.title == title && s.catalog.author == author && s.available == 1);
                    _actions.Add(new borrowBook(state, Person));
                    businessLogicAPI.dataAPI.Borrow(state.catalog.title, state.catalog.author, Person.name, Person.surname);
                    MessageBox.Show("Successfully borrowed", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (_users.Contains(Person))
                    {
                        State state = _stock.First(s => s.catalog.title == title && s.catalog.author == author && s.available == 0);
                        _actions.Add(new returnBook(state, Person));
                        businessLogicAPI.dataAPI.Return(state.catalog.title, state.catalog.author, Person.name, Person.surname);
                        MessageBox.Show("Successfully returned", "Success",
                           MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("You are not a customer", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            } else
            {
                MessageBox.Show("Book not found", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Addstate(State state)
        {
            if (!catalogExist(state.catalog.title, state.catalog.author))
            {
                _catalog.Add(state.catalog);
            }
            _stock.Add(state);
            businessLogicAPI.dataAPI.newAddBook(state.catalog.title, state.catalog.author, 1);
        }

        public void Addperson(User user)
        {
            _users.Add(user);
            businessLogicAPI.dataAPI.newAddUser(user.name, user.surname);
        }

        public void DeleteCatalog(Catalog book)
        {
            foreach (State state in _stock)
            {
                if (state.catalog.title == book.title && state.catalog.author == book.author)
                {
                    _stock.Remove(state);
                }
            }
            _catalog.Remove(book);
            businessLogicAPI.dataAPI.newDeleteBook(book.title, book.author);
        }

        public bool catalogExist(string title, string author)
        {
            foreach (Catalog book in _catalog)
            {
                if (book.title == title && book.author == author)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

