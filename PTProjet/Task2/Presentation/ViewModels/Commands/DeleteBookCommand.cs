using System.ComponentModel;
using System.Windows;
using View.Model;

namespace View.ViewModels
{
    public class DeleteBookCommand : CommandBase
    {
        private readonly DeleteBookViewModel _deleteBookViewModel;
        private readonly library _library;
        private readonly NavigationService _stockViewnavigationService;

        public DeleteBookCommand(DeleteBookViewModel deleteBookViewModel, library library, NavigationService StockViewnavigationService)
        {
            _deleteBookViewModel = deleteBookViewModel;
            _library = library;
            _stockViewnavigationService = StockViewnavigationService;

            _deleteBookViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_deleteBookViewModel.Title) &&
                !string.IsNullOrEmpty(_deleteBookViewModel.Author) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            catalog catalog;
            if (_library.catalogExist(_deleteBookViewModel.Title, _deleteBookViewModel.Author))
            {
                catalog = _library.GetCatalog(_deleteBookViewModel.Title, _deleteBookViewModel.Author);
                _library.DeleteCatalog(catalog);
                MessageBox.Show("Book successfully deleted", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);

            } else
            {
                MessageBox.Show("Book not found", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _stockViewnavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(DeleteBookViewModel.Title) ||
                e.PropertyName == nameof(DeleteBookViewModel.Author))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
