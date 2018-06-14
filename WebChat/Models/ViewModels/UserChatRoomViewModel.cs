using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Areas.Identity.Data;

namespace WebChat.Models.ViewModels
{
    public class UserChatRoomViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<WebChatUser> Users { get; set; }
    }
}
