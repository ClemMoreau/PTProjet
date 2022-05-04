using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;

namespace Task2WPF.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public int Id => _user.Id;

        public string Firstname => _user.firstname;

        public string Lastname => _user.lastname;

        public UserViewModel(User user)
        {
            _user = user;
        }
    }
}
