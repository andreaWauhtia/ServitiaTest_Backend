using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Message.Query
{
    public class GetDiscussionQuery: IRequest<IEnumerable<ServitiaTest_Backend_Domain.Message>>
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public GetDiscussionQuery(string sender, string recipient)
        {
            this.Sender = sender;
            this.Recipient = recipient;
        }
    }
}
