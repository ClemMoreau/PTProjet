using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using View.Model;

namespace View.ViewModels
{
    //List of all books in catalog
    //with button to go to the borrow page and a button to add a book to catalog
    public class ManageStockViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CatalogViewModel> _books;
        private readonly library _library;

        public IEnumerable<CatalogViewModel> Books => _books;

        public ICommand BorrowReturnCommand { get; }
        public ICommand AddBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public ManageStockViewModel(library library, NavigationStore navigationStore, 
            Func<AddBookViewModel> createAddBookViewModel, Func<DeleteBookViewModel> createDeleteBookViewModel, NavigationService borrowBookNavigationService)
        {
            _library = library;
            _books = new ObservableCollection<CatalogViewModel>();
            BorrowReturnCommand = new NavigateCommand(borrowBookNavigationService);
            AddBookCommand = new NavigateCommand(new NavigationService(navigationStore, createAddBookViewModel));
            DeleteBookCommand = new NavigateCommand(new NavigationService(navigationStore, createDeleteBookViewModel));
            UpdateCatalog();
        }

        private void UpdateCatalog()
        {
            _books.Clear();
            foreach (var book in _library.GetCatalogs())
            {
                CatalogViewModel catalogViewModel = new CatalogViewModel(book);
                _books.Add(catalogViewModel);
            }
        }
    }
}
