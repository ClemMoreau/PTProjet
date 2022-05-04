using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task1.LibraryData;
using Task2WPF.Services;
using Task2WPF.ViewModel;

namespace Task2WPF.Commands
{
    public class SaveUserCommand : CommandBase
    {
        private readonly DataContext _library;
        private readonly NavigationService _userViewNavigationService;
        private readonly AddUserViewModel _addUserViewModel;

        public SaveUserCommand(AddUserViewModel addUserViewModel,
            DataContext library,
            NavigationService userViewNavigationService)
        {
            _library = library;
            _userViewNavigationService = userViewNavigationService;
            _addUserViewModel = addUserViewModel;

            _addUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addUserViewModel.Firstname)
                && !string.IsNullOrEmpty(_addUserViewModel.Lastname)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            User user = new User(
                _addUserViewModel.Firstname,
                _addUserViewModel.Lastname);
            
            _library.Users.Add(user);
            MessageBox.Show("User added to the library.", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            _userViewNavigationService.Navigate();
            
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddUserViewModel.Firstname)
            || e.PropertyName == nameof(AddUserViewModel.Lastname))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
