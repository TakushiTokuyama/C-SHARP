using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignIRSample.Hubs
{
    /// <summary>
    /// 接続 グループ メッセージング 管理Class
    /// </summary>
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
