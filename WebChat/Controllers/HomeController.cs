using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebChat.Areas.Identity.Data;
using WebChat.Models;
using WebChat.Models.ViewModels;

namespace WebChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<WebChatUser> _userManager;
        public HomeController(UserManager<WebChatUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result.Name;

            var usersList = _userManager.Users.ToList();

            var userDtob = new UserChatRoomViewModel() { UserName = user, Users = usersList };

            return View(userDtob);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
