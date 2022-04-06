using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
    public abstract class DataLayerAbstractAPI
    {

        public DataContext dataContext;
        public abstract void connect();

        public static DataLayerAbstractAPI CreateLink2Data()
        {
            return new Link2Data();
        }

        private class Link2Data : DataLayerAbstractAPI
        {
            public override void connect()
            {
                dataContext = new DataContext();
            }
        }
    }
}
