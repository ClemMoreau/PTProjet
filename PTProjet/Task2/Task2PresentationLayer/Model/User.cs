namespace View.Model
{
    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }

        public User(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return name + " " + surname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            User p = (User)obj;
            return (this.name == p.name && this.surname == p.surname);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.surname.GetHashCode();
        }
    }
}
