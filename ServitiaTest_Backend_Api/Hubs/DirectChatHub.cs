using Microsoft.AspNetCore.SignalR;

namespace ServitiaTest_Backend_Api.Hubs
{
    public class DirectChatHub: Hub
    {
        public async Task SendNotification(string channel, string messageContent)
        {
            await Clients.All.SendAsync($"ReceiveMessage_{channel}", messageContent);
        }
    }
}
