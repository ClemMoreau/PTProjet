using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
    internal class DataGenerator
    {
        public static void generateData(DataContext data)
        {
            // Adding users 
            data.Users.Add(new User("Gustavo", "Fring"));
            data.Users.Add(new User("Saul", "Goodman"));
            data.Users.Add(new User("Gustavo", "Fringe"));
            data.Users.Add(new User("Walter", "White"));
            data.Users.Add(new User("Jesse", "Pinkman"));
            data.Users.Add(new User("Mike", "Ehrmantraut"));
            data.Users.Add(new User("Huell", "Babineaux"));
            data.Users.Add(new User("Hector", "Salamanca"));
            data.Users.Add(new User("Hank", "Schrader"));
            data.Users.Add(new User("Nacho", "Varga"));
            
            // Adding book
            data.States.Add(new State("Sybil", " Benjamin Disraeli", 2));
            data.States.Add(new State("Nightmare Abbey", "Thomas Love Peacock", 1));
            data.States.Add(new State("Frankenstein ", "Mary Shelley ", 5));
            data.States.Add(new State("Emma", "Jane Austen", 3));
            data.States.Add(new State("The Pilgrim’s Progress ", "John Bunyan", 2));
            data.States.Add(new State("Tom Jones", "Henry Fielding", 1));
            data.States.Add(new State("Clarissa ", "Samuel Richardson",4));
            data.States.Add(new State("Gulliver’s Travels ", "Jonathan Swift", 3));
            data.States.Add(new State("Robinson Crusoe ", "Daniel Defoe ", 2));

            foreach (State state in data.States)
            {
                data.Catalog.Add(state.catalog);
            }
        }
    }
}
