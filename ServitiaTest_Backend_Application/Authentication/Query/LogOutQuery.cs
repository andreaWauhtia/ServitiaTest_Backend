using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Authentication.Query
{
    public class LogOutQuery: IRequest<bool>
    {
        public string Email { get; set; }
    }
}
