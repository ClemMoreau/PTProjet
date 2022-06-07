using System.ComponentModel;
using View.Model;
using View.ViewModels;

namespace View.Commands
{
    public class MakeEventCommand : CommandBase
    {
        private readonly StartingViewModel _startingViewModel;
        private readonly library _library;
        private readonly NavigationService _borrowViewnavigationService;

        public MakeEventCommand(StartingViewModel startingViewModel, library library, NavigationService borrowViewnavigationService)
        {
            _startingViewModel = startingViewModel;
            _library = library;
            _borrowViewnavigationService = borrowViewnavigationService;
            
            _startingViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_startingViewModel.Name) &&
                !string.IsNullOrEmpty(_startingViewModel.Surname) &&
                !string.IsNullOrEmpty(_startingViewModel.Title) &&
                !string.IsNullOrEmpty(_startingViewModel.Author) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            person user;
            if(_library.ExistCustomer(_startingViewModel.Name, _startingViewModel.Surname)){
                user = _library.GetCustomersByName(_startingViewModel.Name, _startingViewModel.Surname);
            } else
            {
                 user = new person(_startingViewModel.Name, _startingViewModel.Surname);
                _library.Addperson(user);
            }
            _library.NewAction(_startingViewModel.Title, _startingViewModel.Author, user, _startingViewModel.Description);
            _borrowViewnavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(StartingViewModel.Name) ||
                e.PropertyName == nameof(StartingViewModel.Surname) ||
                e.PropertyName == nameof(StartingViewModel.Title) ||
                e.PropertyName == nameof(StartingViewModel.Author))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
