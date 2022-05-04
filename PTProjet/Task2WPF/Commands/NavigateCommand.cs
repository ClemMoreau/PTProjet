using System;
using Task2WPF.Services;
using Task2WPF.Stores;
using Task2WPF.ViewModel;

namespace Task2WPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
