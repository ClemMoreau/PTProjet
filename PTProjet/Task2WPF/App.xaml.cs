using System.Windows;
using Task1.LibraryData;
using Task2WPF.ViewModel;
using Task2WPF.Stores;
using Task2WPF.Services;

namespace Task2WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        private readonly DataContext _library;
        public App()
        {
            _library = new DataContext();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMainPageViewModel();

            MainWindow = new MainWindow();
            {
                MainWindow.DataContext = new MainViewModel(_navigationStore);
            }
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddCatalogViewModel CreateAddCatalogViewModel()
        {
            return new AddCatalogViewModel(_library, new NavigationService(_navigationStore, CreateCatalogListViewModel));
        }

        private CatalogListViewModel CreateCatalogListViewModel()
        {
            return new CatalogListViewModel(_library, new NavigationService(_navigationStore, CreateAddCatalogViewModel), new NavigationService(_navigationStore, CreateMainPageViewModel));
        }

        private AddUserViewModel CreateAddUserViewModel()
        {
            return new AddUserViewModel(_library, new NavigationService(_navigationStore, CreateUserListViewModel));
        }

        private UserListViewModel CreateUserListViewModel()
        {
            return new UserListViewModel(_library, new NavigationService(_navigationStore, CreateAddUserViewModel), new NavigationService(_navigationStore, CreateMainPageViewModel));
        }

        private MainPageViewModel CreateMainPageViewModel()
        {
            return new MainPageViewModel(new NavigationService(_navigationStore, CreateCatalogListViewModel), new NavigationService(_navigationStore, CreateUserListViewModel));
        }

    }
}
