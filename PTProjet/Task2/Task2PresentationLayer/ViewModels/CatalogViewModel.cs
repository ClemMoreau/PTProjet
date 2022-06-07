using View.Model;

namespace View.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly Catalog _catalog;

        public string title => _catalog.title;
        public string author => _catalog.author;

        public CatalogViewModel(Catalog book)
        {
            _catalog = book;
        }
    }
}
