using AsyncAwaitBestPractices;
using MediatR;
using ServitiaTest_Backend_Application.Message.Command;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Message.CommandHandler
{
    internal class PostMessageCommandHandler : IRequestHandler<PostMessageCommand, ServitiaTest_Backend_Domain.Message>
    {
        private readonly ServitiaTestContext _context;
        //private readonly MessageNotificationHub _hubContext;

        public PostMessageCommandHandler(ServitiaTestContext context)
        {
            _context = context;
        }

        public async Task<ServitiaTest_Backend_Domain.Message> Handle(PostMessageCommand request, CancellationToken cancellationToken)
        {
            var message = request._message;
            message.CreationDate = DateTime.Now;
            message.Read = false;
            message.Id = Guid.NewGuid();
            using (var connection = _context.GetDbConnection())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                using (var transaction = connection.BeginTransaction())
                {
                    var sentMessage = _context.Messages.Add(message).Entity;
                    _context.SaveChanges();
                    transaction.Commit();

                    return sentMessage;
                }
            }
        }
    }
}
