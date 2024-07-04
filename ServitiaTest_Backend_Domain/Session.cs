using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Domain
{
    public class Session
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public DateTime ConnectionTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
