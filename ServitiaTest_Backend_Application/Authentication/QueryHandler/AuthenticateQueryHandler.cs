using MediatR;
using Microsoft.IdentityModel.Tokens;
using ServitiaTest_Backend_Application.Authentication.Model;
using ServitiaTest_Backend_Application.Authentication.Query;
using ServitiaTest_Backend_Domain;
using ServitiaTest_Backend_Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServitiaTest_Backend_Application.Authentication.QueryHandler
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, AuthToken>
    {
        private readonly ServitiaTestContext _context;
        public AuthenticateQueryHandler(ServitiaTestContext context)
        {
            _context = context;
        }
        public async Task<AuthToken> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
            {
                throw new InvalidDataException("Email or pasword are incorrect");
            }
            else
            {
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Iss,"MyApp"),
                    new Claim(JwtRegisteredClaimNames.Aud, "MyAppUser"),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,   DateTime.Now.ToString()),
                };

                var token = new JwtSecurityToken(claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(60), signingCredentials: null);
                var tokenHandler = new JwtSecurityTokenHandler();
                AuthToken tok = new AuthToken();
                tok.AccessToken = tokenHandler.WriteToken(token);
                tok.RefreshToken = tokenHandler.WriteToken(token);

                Session session = new Session()
                {
                    ConnectionTime = DateTime.Now,
                    LogoutTime = null,
                    Email = request.Email,
                    Id = Guid.NewGuid(),
                };
                var newSession = _context.Sessions.Add(session);
                _context.SaveChanges();
                return tok;
            }

        }
    }
}
