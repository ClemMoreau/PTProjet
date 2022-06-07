namespace View.Model
{
    public abstract class Event
    {
        public string description { get; set; }
        public State book { get; }
        public User user { get; }

        public Event(State book, User user)
        {
            this.book = book;
            this.user = user;
        }
    }

    public class borrowBook : Event
    {
        public borrowBook(State book, User user) : base(book, user)
        {
            description = "Borrow";
        }
    }

    public class returnBook : Event
    {
        public returnBook(State book, User user) : base(book, user)
        {
            description = "Return";
        }
    }

    
}
