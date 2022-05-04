using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2WPF.Services;
using Task2WPF.Commands;
using System.Windows.Input;

namespace Task2WPF.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand CatalogCommand { get; }
        public ICommand UserCommand { get; }

        public MainPageViewModel(NavigationService catalogViewNavigationService,
            NavigationService userViewNavigationService)
        {
            CatalogCommand = new NavigateCommand(catalogViewNavigationService);
            UserCommand = new NavigateCommand(userViewNavigationService);
        }
    }
}
