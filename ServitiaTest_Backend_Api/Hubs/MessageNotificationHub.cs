using MediatR;
using Microsoft.AspNetCore.SignalR;
using ServitiaTest_Backend_Application.Message.Query;
using ServitiaTest_Backend_Domain;

namespace ServitiaTest_Backend_Api.Hubs
{
    public class MessageNotificationHub : Hub
    {

        public async Task SendNotification(string recipientUsername, string messageContent)
        {
            if (Clients != null )
                await Clients.All.SendAsync($"ReceiveMessage_{recipientUsername}", messageContent);
        }
    }
}
