using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
    public class DataContext
    {
		public List<User> Users { get; set; } = new List<User>();

		public List<Event> Events { get; set; } = new List<Event>();

		public List<State> States { get; set; } = new List<State>();

		public List<Catalog> Catalog { get; set; } = new List<Catalog>();

		public CatalogDictionary catalogDictionary { get; set; }

		public DataContext()
        {
			catalogDictionary = new CatalogDictionary(Catalog);
		}

		public void borrowABook(State book, User user)
		{
			Catalog catalog = catalogDictionary.findCatalog(book);
			if (catalog == null)
            {
				Console.WriteLine("Author is not register in the library.");
            }
			else
            {
				if (catalog.nbAvailable == 0)
                {
					Console.WriteLine("This book is not available for the moment.");
                }
                else
                {
					catalog.nbAvailable--;
					Events.Add(new BorrowEvent(user, book));
                }

				if (States.Contains(book) == false)
                {
					States.Add(book);
					Catalog.Add(book.catalog);
                }

				if (Users.Contains(user) == false)
                {
					Users.Add(user);
                }
            }
		}

		public void returnABook(State book, User user)
		{
			Catalog catalog = catalogDictionary.findCatalog(book);
			if (catalog == null)
			{
				Console.WriteLine("Author is not register in the library.");
			}
			else
			{
				catalog.nbAvailable++;
				Events.Add(new ReturnEvent(user, book));

				if (States.Contains(book) == false)
                {
					States.Add(book);
					Catalog.Add(book.catalog);
                }

				if (Users.Contains(user) == false)
                {
					Users.Add(user);
                }

			}
		}
	}
}
