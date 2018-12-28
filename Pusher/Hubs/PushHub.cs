using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Pusher.Hubs
{
    public class PushHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        public override Task OnConnectedAsync()
        {
            var connectId = Context.ConnectionId;
            return Clients.Caller.SendAsync("GetId", connectId);
        }
    }
}
