using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WebChat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.User("e808636f-b97e-4cf5-b010-ac58c648e430").SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageMyself(string user, string message)
        {
            var userId = Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            await Clients.User(userId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
