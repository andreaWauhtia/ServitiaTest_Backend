using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Domain
{
    public class User
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public User()
        {
            Email = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
