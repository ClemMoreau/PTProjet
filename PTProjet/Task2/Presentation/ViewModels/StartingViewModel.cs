using System.Windows.Input;
using View.Commands;
using View.Model;

namespace View.ViewModels
{
    //Page to borrow or return a book
    //with a button to submit and a button to go back to the list of all books
    public class StartingViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _description = "Borrow";
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public StartingViewModel(library library,NavigationService manageStockViewNavigationService, NavigationService manageBorrowViewNavigationService)
        {
            SubmitCommand = new MakeEventCommand(this, library, manageBorrowViewNavigationService);
            CancelCommand = new NavigateCommand(manageStockViewNavigationService);
        }
    }
}
