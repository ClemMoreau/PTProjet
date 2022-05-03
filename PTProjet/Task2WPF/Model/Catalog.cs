using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
	public class Catalog
	{
		public string title { get; set; }

		public string author { get; set; }

		public int nbAvailable { get; set; }

		public Catalog(string title, string author, int nbAvailable)
        {
			this.title = title;
			this.author = author;
			this.nbAvailable = nbAvailable;
        }

		public Catalog(Catalog catalog)
		{
			this.title = catalog.title;
			this.author = catalog.author;
			this.nbAvailable = catalog.nbAvailable;
		}

		public void addBook()
		{
			nbAvailable++;
		}

		public void removeBook()
		{
			nbAvailable--;
		}
	}
}
