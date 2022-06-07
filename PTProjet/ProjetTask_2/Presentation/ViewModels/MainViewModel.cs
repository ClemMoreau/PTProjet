using View.Model;

namespace View.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private readonly library _library;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _library = new library();
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = CreateStartingViewModel();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        //when on starting view, go to manage borrow view or manage stock view if cancel
        private StartingViewModel CreateStartingViewModel()
        {
            return new StartingViewModel(_library, new ViewModels.NavigationService(_navigationStore, CreateManageStockViewModel), new NavigationService(_navigationStore, CreateManageBorrowViewModel));
        }

        //when on addbook view, go to manage stock view
        private AddBookViewModel CreateAddBookViewModel()
        {
            return new AddBookViewModel(_library, new NavigationService(_navigationStore, CreateManageStockViewModel));
        }

        //when on deletebook view, go to manage stock view
        private DeleteBookViewModel CreateDeleteBookViewModel()
        {
            return new DeleteBookViewModel(_library, new NavigationService(_navigationStore, CreateManageStockViewModel));
        }

        //when on manage stock view, go to starting view
        private ManageStockViewModel CreateManageStockViewModel()
        {
            return new ManageStockViewModel(_library, _navigationStore, CreateAddBookViewModel, CreateDeleteBookViewModel, new NavigationService(_navigationStore, CreateStartingViewModel));
        }

        //when on manage borrow view, go to starting view
        private ManageBorrowViewModel CreateManageBorrowViewModel()
        {
            return new ManageBorrowViewModel(_library, new NavigationService(_navigationStore, CreateStartingViewModel));
        }
    }
}
