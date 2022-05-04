﻿using System.Collections.Generic;
using Task2WPF.Exceptions;

namespace Task1.LibraryData
{
	public class CatalogDictionary : Dictionary<string, Catalog>
	{
        public CatalogDictionary(List<Catalog> catalogs)
        {
            foreach (var catalog in catalogs)
            {
                this.Add(catalog.Author, catalog);
            }
        }

		public void AddCatalog(Catalog catalog)
        {
            Catalog? existingCatalog;
            this.TryGetValue(catalog.Author, out existingCatalog);            

            if (existingCatalog == null)
            {
			    this.Add(catalog.Author, catalog);
            }
            else
            {
                throw new CatalogConflictException(existingCatalog, catalog);  
            }
        }
		public Catalog findCatalog(State book)
		{
            Catalog? catalog;
            
            this.TryGetValue(book.catalog.Author, out catalog);
            
            return catalog;            
        }
	}
}