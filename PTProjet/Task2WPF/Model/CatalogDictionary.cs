using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
	public class CatalogDictionary : Dictionary<string, Catalog>
	{
        public CatalogDictionary(List<Catalog> catalogs)
        {
            foreach (var catalog in catalogs)
            {
                this.Add(catalog.author, catalog);
            }
        }

		public void AddCatalog(Catalog catalog)
        {
			this.Add(catalog.author, catalog);
        }
		public Catalog findCatalog(State book)
		{
            Catalog catalog;
            
            bool hasValue = this.TryGetValue(book.catalog.author, out catalog);
            if (hasValue)
            {
                return catalog;            
            }
            else
            {
                return null;
            }
        }
	}
}
