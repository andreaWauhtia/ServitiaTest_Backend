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
    internal class GetDiscussionQueryHandler : IRequestHandler<GetDiscussionQuery, IEnumerable<ServitiaTest_Backend_Domain.Message>>
    {
        private readonly ServitiaTestContext _context;

        public GetDiscussionQueryHandler(ServitiaTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServitiaTest_Backend_Domain.Message>> Handle(GetDiscussionQuery request, CancellationToken cancellationToken)
        {
            var messages = _context.Messages.Where(m => (m.Sender == request.Sender && m.Recipient == request.Recipient) || (m.Sender == request.Recipient && m.Recipient == request.Sender)).OrderBy(m => m.CreationDate).ToList();

            foreach (var message in messages)
            {
                if (message.Recipient == request.Sender && !message.Read)
                {
                    message.Read = true;
                    message.LastModification = DateTime.Now;
                };
            }
            _context.UpdateRange(messages);
            _context.SaveChanges();
            return messages;
        }
    }
}
