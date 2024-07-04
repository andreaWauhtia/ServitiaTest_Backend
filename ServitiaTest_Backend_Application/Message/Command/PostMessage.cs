using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Message.Command
{
    public class PostMessageCommand: IRequest<ServitiaTest_Backend_Domain.Message>
    {
        public readonly ServitiaTest_Backend_Domain.Message _message;

        public PostMessageCommand(ServitiaTest_Backend_Domain.Message message)
        {
            _message = message;
        }
    }
}
