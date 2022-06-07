using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTask_2.LogicLayer
{
    public class DataService
    {
        private BusinessLogicAPI LogicAPI;

        public DataService(BusinessLogicAPI logicAPI)
        {
            LogicAPI = logicAPI;
        }

        public void BorrowBook(String Author, String Title, String Name, String Surname)
        {
            LogicAPI.dataAPI.Borrow(Title, Author, Name, Surname);
        }
        public void ReturnBook(String Author, String Title, String Name, String Surname)
        {
            LogicAPI.dataAPI.Return(Title, Author, Name, Surname);
        }

        public void AddBook(String Author, String Title, int Quantity)
        {
            LogicAPI.dataAPI.newAddBook(Title, Author, Quantity);
        }
        public void AddUser(String Name, String Surname)
        {
            LogicAPI.dataAPI.newAddUser(Name, Surname);
        }
        public void DeleteBook(String Author, String Title)
        {
            LogicAPI.dataAPI.newDeleteBook(Title, Author);
        }

        public int getNbBook()
        {
            return LogicAPI.dataAPI.newGetNbBook();
        }
        public int getNbUser()
        {
            return LogicAPI.dataAPI.newGetNbUser();
        }

        public bool getAvailability(String Author, String Title)
        {
            return LogicAPI.dataAPI.newGetAvailability(Author, Title);
        }
        public void ChangeAvailability(String Title, String Author, bool available)
        {
            LogicAPI.dataAPI.newChangeAvailabilityState(Title, Author, available);
            LogicAPI.dataContext.SubmitChanges();
        }
    }
}
