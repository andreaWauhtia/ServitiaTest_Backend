using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServitiaTest_Backend_Application.Authentication.Model;
using ServitiaTest_Backend_Application.Authentication.Query;

namespace ServitiaTest_Backend_Api.Controllers.Authentication
{
    public class AuthenticationController: ApiControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AuthToken>> Login(AuthenticateRequest request)
        {
            AuthenticateQuery query = new AuthenticateQuery(request.Email, request.Password);
            try
            {
                var result = await Mediator.Send(query).ConfigureAwait(false);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(501, ex);
            }

        }
        [HttpGet]
        public async Task<ActionResult<AuthToken>> Logout(string email)
        {
            LogOutQuery query = new LogOutQuery()
            {
                Email = email
            };
            try
            {
                var result = await Mediator.Send(query).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex);
            }
        }
    }
}
