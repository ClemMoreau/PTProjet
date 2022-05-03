using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryData
{
    public class User
    {
        public String firstname { get; set; }

        public String lastname { get; set; }

        public User(String firstname, String lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public User(User user)
        {
            this.firstname = user.firstname;
            this.lastname = user.lastname;
        }

    }
}
