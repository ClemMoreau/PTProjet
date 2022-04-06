
namespace Task1.LibraryData
{
    public class ReturnEvent : Event
    {
        public ReturnEvent()
        {
            typeOfEvent = "return";
        }

        public ReturnEvent(User user, State book)
        {
            typeOfEvent = "return";
            this.book = book;
            this.user = user;
        }
    }
}
