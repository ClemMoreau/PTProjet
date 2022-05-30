using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
	public abstract class Event
	{
		public string typeOfEvent { get; set; }

		public User user { get; set; }

		public Catalog book { get; set; }
	}
}
