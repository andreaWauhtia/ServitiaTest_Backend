using MediatR;
using ServitiaTest_Backend_Application.User.Command;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.User.CommandHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ServitiaTest_Backend_Domain.User>
    {
        private readonly ServitiaTestContext _context;
        public AddUserCommandHandler(ServitiaTestContext context)
        {
            _context = context;
        }
        public async Task<ServitiaTest_Backend_Domain.User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            request.User.DateCreation = DateTime.Now;
            using (var connection = _context.GetDbConnection())
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                if (_context.Users.Any(u => u.Email == request.User.Email))
                {
                    throw new InvalidDataException("An user with this email already exists!");
                }
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await _context.Users.AddAsync(request.User).ConfigureAwait(false);
                        _context.SaveChanges();
                        transaction.Commit();
                        return result.Entity;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Failed to add user to database. See inner exception for details.", ex);
                    }
                }
            }
        }
    }
}
