using View.Model;

namespace View.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly User _person;

        public string name => _person.name;
        public string surname => _person.surname;

        public PersonViewModel(User user)
        {
            _person = user;
        }
    }
}
