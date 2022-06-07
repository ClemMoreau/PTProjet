﻿using View.Model;

namespace View.ViewModels
{
    public class ActionViewModel : ViewModelBase
    {
        private readonly Event _action;

        public string title => _action.book.catalog.title;
        public string author => _action.book.catalog.author;
        public string name => _action.user.name;
        public string surname => _action.user.surname;
        public string description => _action.description;

        public ActionViewModel(Event actionEvent)
        {
            _action = actionEvent;
        }
    }
}
