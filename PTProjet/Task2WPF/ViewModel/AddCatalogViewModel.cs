using System;
using System.Windows.Input;
using Task1.LibraryData;
using Task2WPF.Commands;
using Task2WPF.Services;

namespace Task2WPF.ViewModel
{
    public class AddCatalogViewModel : ViewModelBase
    {
        private string _author;

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private int _nbAvailable;

        public int NbAvailable
        {
            get
            {
                return _nbAvailable;
            }
            set
            {
                _nbAvailable = value;
                OnPropertyChanged(nameof(NbAvailable));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCatalogViewModel(DataContext library, NavigationService catalogViewNavigationService)
        {
            SaveCommand = new SaveCatalogCommand(this, library, catalogViewNavigationService);
            CancelCommand = new NavigateCommand(catalogViewNavigationService);
        }
    }
}
