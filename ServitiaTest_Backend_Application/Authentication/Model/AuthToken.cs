using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Authentication.Model
{
    public class AuthToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AuthToken()
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
        }

    }
}
