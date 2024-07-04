using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServitiaTest_Backend_Application.User.Command;
using ServitiaTest_Backend_Application.User.Model;
using ServitiaTest_Backend_Application.User.Query;
using ServitiaTest_Backend_Domain;

namespace ServitiaTest_Backend_Api.Controllers
{
    public class UserController: ApiControllerBase
    {
        public UserController(): base()
        {

        }
        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            var req = new AddUserCommand(user);
            try
            {
                var result = await Mediator.Send(req);
                return Ok(result);
            }
            catch(InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<IEnumerable<Recipient>>> GetRecipients(string currentUser)
        {
            return Ok(await Mediator.Send(new GetRecipientsQuery(currentUser)).ConfigureAwait(false));
        }
    }
}
