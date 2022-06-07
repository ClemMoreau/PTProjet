namespace View.Model
{
    public class Catalog
    {
        public string author { get; }
        public string title { get; }

        public Catalog(string author, string title)
        {
            this.author = author;
            this.title = title;
        }
    }
}
