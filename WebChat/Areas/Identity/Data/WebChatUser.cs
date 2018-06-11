using Microsoft.AspNetCore.Identity;
using System;

namespace WebChat.Areas.Identity.Data
{
    public class WebChatUser : IdentityUser
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }
    }
}
