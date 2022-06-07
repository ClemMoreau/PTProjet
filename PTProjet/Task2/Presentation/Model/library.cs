using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProjetTask_2.LogicLayer;

namespace View.Model
{
    public class library
    {
        public  BusinessLogicAPI businessLogicAPI;
        private readonly List<action> _actions;
        private readonly List<state> _stock;
        private readonly List<person> _users;
        private readonly List<catalog> _catalog;

        public library()
        {
            businessLogicAPI = new BusinessLogicAPI();
            _actions = new List<action>();
            _stock = new List<state>();
            _users = new List<person>();
            _catalog = new List<catalog>();
        }

        public library(BusinessLogicAPI businessLogicAPI)
        {
            _actions = new List<action>();
            _stock = new List<state>();
            _users = new List<person>();
            _catalog = new List<catalog>();
        }

        public IEnumerable<state> GetStock()
        {
            return _stock;
        }

        public IEnumerable<catalog> GetCatalogs()
        {
            return _catalog;
        }

        public IEnumerable<action> GetActions(){
            
            return _actions;
        }

        public IEnumerable<state> GetStateByTitle(string title)
        {
            return _stock.Where(s => s.catalog.title == title);
        }

        public catalog GetCatalog(string title, string author)
        {
            return _catalog.First(c => c.title == title && c.author == author);
        }

        public IEnumerable<person> GetCustomers()
        {
            return _users;
        }
        
        public bool ExistCustomer(string name, string surname)
        {
            foreach (person user in _users)
            {
                if (user.name == name && user.surname == surname)
                {
                    return true;
                }
            }
            return false;
        }

        public person GetCustomersByName(string name, string surname)
        {
            if (ExistCustomer(name, surname))
            {
                return _users.First(u => u.name == name && u.surname == surname);
            }
            else return null;
        }

        public void NewAction(String title, String author, person Person, String description)
        {
            if (catalogExist(title, author))
            {
                if (description == "Borrow")
                {
                    state state = _stock.First(s => s.catalog.title == title && s.catalog.author == author && s.available == 1);
                    _actions.Add(new borrowBook(state, Person));
                    businessLogicAPI.dataAPI.Borrow(state.catalog.title, state.catalog.author, Person.name, Person.surname);
                    MessageBox.Show("Successfully borrowed", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (_users.Contains(Person))
                    {
                        state state = _stock.First(s => s.catalog.title == title && s.catalog.author == author && s.available == 0);
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

        public void Addstate(state state)
        {
            if (!catalogExist(state.catalog.title, state.catalog.author))
            {
                _catalog.Add(state.catalog);
            }
            _stock.Add(state);
            businessLogicAPI.dataAPI.newAddBook(state.catalog.title, state.catalog.author, 1);
        }

        public void Addperson(person user)
        {
            _users.Add(user);
            businessLogicAPI.dataAPI.newAddUser(user.name, user.surname);
        }

        public void DeleteCatalog(catalog book)
        {
            foreach (state state in _stock)
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
            foreach (catalog book in _catalog)
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

