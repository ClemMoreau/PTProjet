using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using View.Model;

namespace View.ViewModels
{
    //List of all action (borrow or return)
    //with a button to go back to the borrowing page
    public class ManageBorrowViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ActionViewModel> _actions;
        private readonly library _library;
        
        public IEnumerable<ActionViewModel> Actions => _actions;
        
        public ICommand BorrowReturnCommand { get; }

        public ManageBorrowViewModel(library library, NavigationService borrowViewnavigationService)
        {
            _library = library;
            _actions = new ObservableCollection<ActionViewModel>();
            BorrowReturnCommand = new NavigateCommand(borrowViewnavigationService);

            UpdateCatalog();
        }

        private void UpdateCatalog()
        {
            _actions.Clear();
            foreach (var action in _library.GetActions())
            {
                ActionViewModel actionViewModel = new ActionViewModel(action);
                _actions.Add(actionViewModel);
            }
        }
    }
}
