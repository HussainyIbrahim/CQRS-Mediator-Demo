using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CQRS_MidatR_API_Demo_DotNet5.Hubes
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
