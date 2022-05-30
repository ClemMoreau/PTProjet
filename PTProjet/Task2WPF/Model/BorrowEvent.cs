
namespace Task1.LibraryData
{
    public class BorrowEvent : Event
    {
        public BorrowEvent()
        {
            typeOfEvent = "borrow";
        }

        public BorrowEvent(User user, Catalog book)
        {
            typeOfEvent = "borrow";
            this.user = user;
            this.book = book;
        }
    }
}
