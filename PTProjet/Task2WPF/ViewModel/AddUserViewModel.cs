using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.LibraryData;
using Task2WPF.Commands;
using Task2WPF.Services;

namespace Task2WPF.ViewModel
{
    public class AddUserViewModel : ViewModelBase
    {
        private string _firstname;

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string _lastname;

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddUserViewModel(DataContext library, NavigationService userViewNavigationService)
        {
            SaveCommand = new SaveUserCommand(this, library, userViewNavigationService);
            CancelCommand = new NavigateCommand(userViewNavigationService);
        } 
    }
}
