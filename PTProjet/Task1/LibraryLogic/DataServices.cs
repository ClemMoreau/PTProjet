using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;

namespace Task1.LibraryLogic
{
	public class DataServices
	{

		BusinessLogic BusinessLogic = BusinessLogicAbstractAPI.CreateLayer(null);
		public void borrowBook(State book, User user)
		{
			BusinessLogic.data.borrowABook(book, user);
		}

		public void getBackBook(State book, User user)
		{
			BusinessLogic.data.returnABook(book, user);
		}
	}
}
