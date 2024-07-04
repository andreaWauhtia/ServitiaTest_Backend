using MediatR;
using ServitiaTest_Backend_Application.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.User.Query
{
    public class GetRecipientsQuery: IRequest<IEnumerable<Recipient>>
    {
        public readonly string CurrentUser;
        public GetRecipientsQuery(string currentUser) {
            this.CurrentUser = currentUser;
        }
    }
}
