using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.User.Command
{

    public class AddUserCommand: IRequest<ServitiaTest_Backend_Domain.User>
    {
        public readonly ServitiaTest_Backend_Domain.User User;
        public AddUserCommand(ServitiaTest_Backend_Domain.User user)
        {
            this.User = user;
        }
    }
}
