using System.Windows.Input;
using View.Model;

namespace View.ViewModels
{
    //Delete Book from the catalog
    //with a button to submit and a button to go back to catalog
    public class DeleteBookViewModel : ViewModelBase
    {
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
        
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public DeleteBookViewModel(library library, NavigationService borrowViewnavigationService)
        {
            SubmitCommand = new DeleteBookCommand(this, library, borrowViewnavigationService);
            CancelCommand = new NavigateCommand(borrowViewnavigationService);
        }

        
    }
}
