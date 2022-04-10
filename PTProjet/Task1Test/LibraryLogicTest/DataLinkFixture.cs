using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryData;

namespace Task1Test.LibraryLogicTest
{
    public class DataLinkFixture : DataLayerAbstractAPI
    {
        internal int ConnectedCount = 0;
        #region DataConnection

        public override void connect()
        {
            ConnectedCount++;
        }

        #endregion
    }
}
