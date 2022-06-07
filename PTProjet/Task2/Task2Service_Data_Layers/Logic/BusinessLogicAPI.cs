using ProjetTask_2.DataLayer;

namespace ProjetTask_2.LogicLayer
{
    public class BusinessLogicAPI
    {
        public AbstractDataAPI dataAPI;
        public DataService service { get; set; }
        public DataContext dataContext;

        public BusinessLogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            service = new DataService(this);
            dataContext = new DataContext();
        }

        public BusinessLogicAPI()
        {
            dataAPI = AbstractDataAPI.createAPI();
            service = new DataService(this);
            dataContext = new DataContext();
        }
    }
}
