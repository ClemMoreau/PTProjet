namespace View.Model
{
    public class State
    {
        public Catalog catalog { get; }
        public int available { get; set; }  //1 if true, else 0

        public State(Catalog catalog)
        {
            this.catalog = catalog;
            this.available = 1;
        }
    }
}
