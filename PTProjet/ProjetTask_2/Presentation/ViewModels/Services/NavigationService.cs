using System;

namespace View.ViewModels
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }
        
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
