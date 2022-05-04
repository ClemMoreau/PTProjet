using Task1.LibraryData;
using Task2WPF.ViewModel;
using Task2WPF.Exceptions;
using System.Windows;
using System.ComponentModel;
using Task2WPF.Services;

namespace Task2WPF.Commands
{
    public class SaveCatalogCommand : CommandBase
    {
        private readonly DataContext _library;
        private readonly NavigationService _catalogViewNavigationService;
        private readonly AddCatalogViewModel _addCatalogViewModel;

        public SaveCatalogCommand(AddCatalogViewModel addCatalogViewModel,
            DataContext library,
            NavigationService catalogViewNavigationService)
        {
            _library = library;
            _catalogViewNavigationService = catalogViewNavigationService;
            _addCatalogViewModel = addCatalogViewModel;

            _addCatalogViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addCatalogViewModel.Title)
                && !string.IsNullOrEmpty(_addCatalogViewModel.Author)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Catalog catalog = new Catalog(
                _addCatalogViewModel.Title,
                _addCatalogViewModel.Author,
                _addCatalogViewModel.NbAvailable
                );
            try
            {
                _library.catalogDictionary.AddCatalog(catalog);
                _library.Catalog.Add(catalog);
                MessageBox.Show("Catalog added to the library.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _catalogViewNavigationService.Navigate();
            }
            catch(CatalogConflictException)
            {
                MessageBox.Show("This catalog is already in the library.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AddCatalogViewModel.Title) 
            || e.PropertyName == nameof(AddCatalogViewModel.Author))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
