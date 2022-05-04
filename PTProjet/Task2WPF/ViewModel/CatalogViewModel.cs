using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;

namespace Task2WPF.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly Catalog _catalog;

        public int Id => _catalog.Id;

        public string Title => _catalog.Title;

        public string Author => _catalog.Author;

        public int NbAvailable => _catalog.NbAvailable;

        public CatalogViewModel(Catalog catalog)
        {
            _catalog = catalog;
        }
    }
}
