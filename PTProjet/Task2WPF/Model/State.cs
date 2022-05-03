using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
	public class State
	{
		public Catalog catalog { get; set; }

		public State(string title, string author, int nbAvailable)
        {
			this.catalog = new Catalog(title, author, nbAvailable);
        }

		public State(Catalog catalog)
        {
			this.catalog = new Catalog(catalog);
        }

		public void ReturnOne()
		{
			this.catalog.addBook();
		}

		public void BorrowOne()
		{
			this.catalog.removeBook();
		}

	}
}
