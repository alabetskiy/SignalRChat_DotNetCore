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
            var userName = Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            
            // Add custom claims in order to retrive a UserName instead of Email address. 

            await Clients.User(user).SendAsync("ReceiveMessage", userName, message);
        }

        public async Task SendMessageMyself(string message)
        {
            var user = Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            var userId = Context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            await Clients.User(userId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
