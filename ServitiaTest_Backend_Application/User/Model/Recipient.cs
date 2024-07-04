using ServitiaTest_Backend_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.User.Model
{
    public class Recipient : ServitiaTest_Backend_Domain.User
    {
        public bool HasMessage { get; set; }
    }
}
