using Microsoft.AspNetCore.SignalR;

namespace ServitiaTest_Backend_Api.Hubs
{
    public class MessageReadHub: Hub
    {
        public async Task SendNotification(string channel, string messageContent)
        {
            if (Clients != null)
                await Clients.All.SendAsync($"{channel}", messageContent);
        }
    }
}
