using Task1.LibraryData;

namespace Task1.LibraryLogic
{
    public abstract class BusinessLogicAbstractAPI
    {

        private DataLayerAbstractAPI dataLayerAbstractAPI;

        public static BusinessLogic CreateLayer(DataLayerAbstractAPI data)
        {
            return new BusinessLogic(data == null ? DataLayerAbstractAPI.CreateLink2Data() : data);
        }


    }
    public class BusinessLogic : BusinessLogicAbstractAPI
    {
        public readonly DataLayerAbstractAPI dataLayer;

        public DataContext data;

        public BusinessLogic(DataLayerAbstractAPI data)
        {
            dataLayer = data;
            dataLayer.connect();
            this.data = dataLayer.dataContext;
        }
    }

}