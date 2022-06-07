using ProjetTask_2.DataLayer;

namespace UnitTest_ProjetTask_2
{
    public class DataAPI : AbstractDataAPI
    {
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            newBorrow(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, true); //Looking for state w available = true to make it false

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            newReturn(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, false); //Looking for state w available = false to make it true
        }
    }
}