using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
	public class Catalog
	{
		private static int nextId = 1;
		public int Id { get; set; }
		public string Title { get; set; }

		public string Author { get; set; }

		public int NbAvailable { get; set; }

        public Catalog()
        {
			this.Id = 0;
			this.Title = "";
			this.Author = "";
			this.NbAvailable = 0;
		}

		public Catalog(string title, string author, int nbAvailable)
        {
			this.Id = nextId;
			nextId++;
			this.Title = title;
			this.Author = author;
			this.NbAvailable = nbAvailable;
        }

		public Catalog(Catalog catalog)
		{
			this.Id = nextId;
			nextId++;
			this.Title = catalog.Title;
			this.Author = catalog.Author;
			this.NbAvailable = catalog.NbAvailable;
		}

		public void addBook()
		{
			NbAvailable++;
		}

		public void removeBook()
		{
			NbAvailable--;
		}
	}
}
