
using Task2WPF.ViewModel;
using System;
using System.Windows;
using System.ComponentModel;
using Task2WPF.Services;
using StructuralData;
using Task1.LibraryData;

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
            StructuralData.Catalog catalog = new StructuralData.Catalog();
            catalog.Author = _addCatalogViewModel.Author;
            catalog.Title = _addCatalogViewModel.Title;
            catalog.NbAvailable = _addCatalogViewModel.NbAvailable;
            try
            {
                _library.catalogDictionary.AddCatalog(new Task1.LibraryData.Catalog(catalog.idCatalog, catalog.Author, catalog.Title, catalog.NbAvailable));
                _library.Catalog.Add(new Task1.LibraryData.Catalog(catalog.idCatalog, catalog.Author, catalog.Title, catalog.NbAvailable));
                _library.serviceAPI.addCatalog(catalog.Title, catalog.Author);
                MessageBox.Show("Catalog added to the library.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _catalogViewNavigationService.Navigate();
            }
            catch(Exception)
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
