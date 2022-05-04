using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
    public class User
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public String firstname { get; set; }

        public String lastname { get; set; }

        public User()
        {
            this.Id = 0;
            this.firstname = "";
            this.lastname = "";
        }

        public User(String firstname, String lastname)
        {
            this.Id = nextId;
            nextId++;
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public User(User user)
        {
            this.Id = nextId;
            nextId++;
            this.firstname = user.firstname;
            this.lastname = user.lastname;
        }

    }
}
