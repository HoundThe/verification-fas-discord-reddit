﻿using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
//    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userModel = new UserModel
                {
                    Groups = HttpContext.Session.GetString("Groups"),
                    BaseLogintype = HttpContext.Session.GetString("BaseLoginType"),
                    FasNickname = HttpContext.Session.GetString("FasNickname"),
                    RedhatNickname = HttpContext.Session.GetString("RedhatNickname")
                };
                return View(userModel);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}