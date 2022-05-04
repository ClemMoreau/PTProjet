using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task1.LibraryData;
using Task2WPF.Commands;
using Task2WPF.Services;

namespace Task2WPF.ViewModel
{
    public class CatalogListViewModel : ViewModelBase
    {
        private readonly DataContext _library;
        private readonly ObservableCollection<CatalogViewModel> _catalogs;

        public IEnumerable<CatalogViewModel> Catalogs => _catalogs;

        public ICommand AddCatalogCommand { get;  }

        public CatalogListViewModel(DataContext library, NavigationService addCatalogNavigationService)
        {
            _library = library;
            _catalogs = new ObservableCollection<CatalogViewModel>();

            AddCatalogCommand = new NavigateCommand(addCatalogNavigationService);

            UpdateCatalogs();
        }

        private void UpdateCatalogs()
        {
            _catalogs.Clear();

            foreach (Catalog catalog in _library.Catalog)
            {
                CatalogViewModel catalogViewModel = new CatalogViewModel(catalog);
                _catalogs.Add(catalogViewModel);
            }
        }
    }
}
