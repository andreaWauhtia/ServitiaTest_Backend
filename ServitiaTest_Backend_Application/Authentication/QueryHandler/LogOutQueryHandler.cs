using MediatR;
using ServitiaTest_Backend_Application.Authentication.Query;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Application.Authentication.QueryHandler
{
    internal class LogOutQueryHandler : IRequestHandler<LogOutQuery, bool>
    {
        private readonly ServitiaTestContext _context;

        public LogOutQueryHandler(ServitiaTestContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(LogOutQuery request, CancellationToken cancellationToken)
        {
           var lastSession = _context.Sessions.Where(s => s.Email == request.Email).OrderBy(x => x.ConnectionTime).Last();
            lastSession.LogoutTime = DateTime.Now;
            _context.Sessions.Update(lastSession);
            _context.SaveChanges();
            return true;
        }
    }
}
