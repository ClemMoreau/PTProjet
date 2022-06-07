using View.Model;

namespace View.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly catalog _catalog;

        public string title => _catalog.title;
        public string author => _catalog.author;

        public CatalogViewModel(catalog book)
        {
            _catalog = book;
        }
    }
}
