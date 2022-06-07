using View.Model;

namespace View.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly person _person;

        public string name => _person.name;
        public string surname => _person.surname;

        public PersonViewModel(person user)
        {
            _person = user;
        }
    }
}
