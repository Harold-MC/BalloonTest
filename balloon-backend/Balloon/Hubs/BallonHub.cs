using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Balloon.Hubs
{
    public class BallonHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}