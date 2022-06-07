namespace View.Model
{
    public abstract class action
    {
        public string description { get; set; }
        public state book { get; }
        public person user { get; }

        public action(state book, person user)
        {
            this.book = book;
            this.user = user;
        }
    }

    public class borrowBook : action
    {
        public borrowBook(state book, person user) : base(book, user)
        {
            description = "Borrow";
        }
    }

    public class returnBook : action
    {
        public returnBook(state book, person user) : base(book, user)
        {
            description = "Return";
        }
    }

    
}
