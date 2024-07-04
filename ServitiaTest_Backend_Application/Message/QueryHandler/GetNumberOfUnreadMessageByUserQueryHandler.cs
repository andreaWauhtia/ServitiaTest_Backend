using MediatR;
using ServitiaTest_Backend_Application.Message.Query;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Message.QueryHandler
{
    internal class GetNumberOfUnreadMessageByUserQueryHandler : IRequestHandler<GetNumberOfUnreadMessageByUserQuery, int>
    {
        private readonly ServitiaTestContext _context;

        public GetNumberOfUnreadMessageByUserQueryHandler(ServitiaTestContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetNumberOfUnreadMessageByUserQuery request, CancellationToken cancellationToken)
        {
            return _context.Messages.Where(m => m.Recipient == request.Recipient && !m.Read).Count();
        }
    }
}

