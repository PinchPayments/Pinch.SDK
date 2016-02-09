using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Pinch.SDK.Auth;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;
using Pinch.SDK.WebSample.ViewModels;

namespace Pinch.SDK.WebSample.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObjectFromJson<GetAccessTokenResponse>("AccessToken");
            var model = new IndexVm()
            {
                AccessToken = token
            };

            if (!string.IsNullOrEmpty(model.AccessToken?.AccessToken))
            {
                var api = new PinchApi("TestSecretKey");
                var result =  await api.Auth.GetClaims(model.AccessToken.AccessToken);
                model.Claims = result;
            }

            return View(model);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
