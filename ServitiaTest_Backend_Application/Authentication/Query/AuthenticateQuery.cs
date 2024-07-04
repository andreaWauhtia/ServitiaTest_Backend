using MediatR;
using ServitiaTest_Backend_Application.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Authentication.Query
{
    public class AuthenticateQuery: IRequest<AuthToken>
    {
        public readonly string Email;
        public readonly string Password;
        public AuthenticateQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
