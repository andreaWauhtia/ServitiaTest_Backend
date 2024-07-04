using MediatR;
using ServitiaTest_Backend_Application.User.Model;
using ServitiaTest_Backend_Application.User.Query;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.User.QueryHandler
{
    internal class GetRecipientsQueryHandler : IRequestHandler<GetRecipientsQuery, IEnumerable<Recipient>>
    {
        private readonly ServitiaTestContext _context;
        public GetRecipientsQueryHandler(ServitiaTestContext context)
        {
            this._context = context;    
        }
        public async Task<IEnumerable<Recipient>> Handle(GetRecipientsQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Where(u => u.Email != request.CurrentUser);
            var unReadMessagesFromUsers = _context.Messages.Where(m => m.Sender != request.CurrentUser && !m.Read);
            return users.Select(u => new Recipient()
            {
                Email = u.Email,
                Username = u.Username,
                HasMessage = unReadMessagesFromUsers.Any(m => m.Sender == u.Email)
            });
        }
    }
}
