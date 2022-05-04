using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.LibraryData;
using Task2WPF.Commands;
using Task2WPF.Services;

namespace Task2WPF.ViewModel
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly DataContext _library;
        private readonly ObservableCollection<UserViewModel> _user;

        public IEnumerable<UserViewModel> Users => _user;

        public ICommand AddUserCommand { get; }

        public UserListViewModel(DataContext library, NavigationService addUserNavigationService)
        {
            _library = library;
            _user = new ObservableCollection<UserViewModel>();

            AddUserCommand = new NavigateCommand(addUserNavigationService);

            UpdateUsers();
        }

        private void UpdateUsers()
        {
            _user.Clear();

            foreach (User user in _library.Users)
            {
                UserViewModel userViewModel = new UserViewModel(user);
                _user.Add(userViewModel);
            }
        }
    }
}
