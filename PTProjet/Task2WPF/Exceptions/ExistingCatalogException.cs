using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;

namespace Task2WPF.Exceptions
{
    public class CatalogConflictException : Exception
    {
        public Catalog ExistingCatalog { get; }
        public Catalog IncomingCatalog { get; }

        public CatalogConflictException(Catalog existingCatalog, Catalog incomingCatalog)
        {
            ExistingCatalog = existingCatalog;
            IncomingCatalog = incomingCatalog;
        }

        public CatalogConflictException(string message, Catalog existingCatalog, Catalog incomingCatalog) : base(message)
        {
            ExistingCatalog = existingCatalog;
            IncomingCatalog = incomingCatalog;
        }

        public CatalogConflictException(string message, Exception innerException, Catalog existingCatalog, Catalog incomingCatalog) : base(message, innerException)
        {
            ExistingCatalog = existingCatalog;
            IncomingCatalog = incomingCatalog;
        }
    }
}
