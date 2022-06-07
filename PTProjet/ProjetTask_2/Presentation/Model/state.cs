namespace View.Model
{
    public class state
    {
        public catalog catalog { get; }
        public int available { get; set; }  //1 if true, else 0

        public state(catalog catalog)
        {
            this.catalog = catalog;
            this.available = 1;
        }
    }
}
