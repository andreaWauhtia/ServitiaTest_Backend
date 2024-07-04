using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Message.Query
{
    public class GetNumberOfUnreadMessageByUserQuery: IRequest<int>
    {
        public readonly string Recipient;
        public GetNumberOfUnreadMessageByUserQuery(string recipient) {
            this.Recipient = recipient;
        }

    }
}
