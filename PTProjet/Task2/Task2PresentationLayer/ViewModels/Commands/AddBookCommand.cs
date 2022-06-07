﻿using System.ComponentModel;
using System.Windows;
using View.Model;

namespace View.ViewModels
{
    public class AddBookCommand : CommandBase
    {
        private readonly AddBookViewModel _addBookViewModel;
        private readonly Library _library;
        private readonly NavigationService _stockViewnavigationService;

        public AddBookCommand(AddBookViewModel addBookViewModel, Library library, NavigationService StockViewnavigationService)
        {
            _addBookViewModel = addBookViewModel;
            _library = library;
            _stockViewnavigationService = StockViewnavigationService;

            _addBookViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addBookViewModel.Title) &&
                !string.IsNullOrEmpty(_addBookViewModel.Author) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Catalog catalog;
            if (_library.catalogExist(_addBookViewModel.Title, _addBookViewModel.Author))
            {
                catalog = _library.GetCatalog(_addBookViewModel.Title, _addBookViewModel.Author);
                
            } else
            {
                catalog = new Catalog(_addBookViewModel.Title, _addBookViewModel.Author);            
            }
            _library.Addstate(new State(catalog));
            MessageBox.Show("Book successfully added", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            _stockViewnavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(AddBookViewModel.Title) ||
                e.PropertyName == nameof(AddBookViewModel.Author))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
