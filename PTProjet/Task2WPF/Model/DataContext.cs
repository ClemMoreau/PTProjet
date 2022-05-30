using Services;
using System;
using System.Collections.Generic;

namespace Task1.LibraryData
{
    public class DataContext
    {
		public List<User> Users { get; set; } = new List<User>();

		public List<Event> Events { get; set; } = new List<Event>();

		public List<State> States { get; set; } = new List<State>();

		public List<Catalog> Catalog { get; set; } = new List<Catalog>();

		public CatalogDictionary catalogDictionary { get; set; }

		public Service serviceAPI { get; set; }

		public DataContext()
        {
			serviceAPI = Service.CreateService("TODO PUT STRING CONNEXION");

			foreach(var catalog in serviceAPI.getCatalogs())
            {
				Catalog.Add(new Catalog(catalog.idCatalog, catalog.Title, catalog.Author, catalog.NbAvailable));
            }
			catalogDictionary = new CatalogDictionary(Catalog);

			foreach(var user in serviceAPI.getUsers())
            {
				Users.Add(new User(user.idUser, user.FirstName, user.LastName));
            }
		}

		public void borrowABook(Catalog book, User user)
		{
			
			if (book == null)
            {
				Console.WriteLine("Author is not register in the library.");
            }
			else
            {
				if (book.NbAvailable == 0)
                {
					Console.WriteLine("This book is not available for the moment.");
                }
                else
                {
					book.NbAvailable--;
					Events.Add(new BorrowEvent(user, book));
                }

				if (Users.Contains(user) == false)
                {
					Users.Add(user);
                }
            }
		}

		public void returnABook(Catalog book, User user)
		{
			if (book == null)
			{
				Console.WriteLine("Author is not register in the library.");
			}
			else
			{
				book.NbAvailable++;
				Events.Add(new ReturnEvent(user, book));

				if (Catalog.Contains(book) == false)
                {
					Catalog.Add(book);
                }

				if (Users.Contains(user) == false)
                {
					Users.Add(user);
                }

			}
		}
	}
}
