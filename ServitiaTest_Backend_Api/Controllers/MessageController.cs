using AsyncAwaitBestPractices;
using Microsoft.AspNetCore.Mvc;
using ServitiaTest_Backend_Api.Hubs;
using ServitiaTest_Backend_Application.Message.Command;
using ServitiaTest_Backend_Application.Message.Query;
using ServitiaTest_Backend_Domain;

namespace ServitiaTest_Backend_Api.Controllers
{
    public class MessageController: ApiControllerBase
    {
        private readonly MessageNotificationHub messageNotificationHub; 
        private readonly MessageReadHub messageReadHub;
        public MessageController(MessageNotificationHub hub, MessageReadHub messageReadHub):base()
        {
            this.messageNotificationHub = hub;
            this.messageReadHub = messageReadHub;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Create(Message msg)
        {
            var command = new PostMessageCommand(msg);
            try
            {
                if (!string.IsNullOrEmpty(msg.Recipient))
                {
                    var message = await Mediator.Send(command).ConfigureAwait(false);
                    var unreadMessage = await Mediator.Send(new GetNumberOfUnreadMessageByUserQuery(msg.Recipient)).ConfigureAwait(false);
                    messageNotificationHub.SendNotification(message.Recipient, unreadMessage.ToString()).SafeFireAndForget();
                    messageReadHub.SendNotification($"readMessage_{message.Recipient}_{message.Sender}".ToLower(),  "Done").SafeFireAndForget();
                    return Ok(message);
                }
                throw new InvalidDataException("You must select a recipient!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<int>> GetUnreadMessage(string recipient)
        {
            var query = new GetNumberOfUnreadMessageByUserQuery(recipient);
            try
            {
                var number = await Mediator.Send(query).ConfigureAwait(false);
                return Ok(number);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetChatWith(string sender, string recipient)
        {
           
            try
            {
               var query = new GetDiscussionQuery(sender, recipient);
                var messages = await Mediator.Send(query).ConfigureAwait(false);
                messageReadHub.SendNotification($"readMessage_{recipient}_{sender}", string.IsNullOrEmpty(recipient) ? "None": "Done").SafeFireAndForget();
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
