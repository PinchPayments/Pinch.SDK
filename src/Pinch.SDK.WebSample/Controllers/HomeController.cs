using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            //var token = HttpContext.Session.GetObjectFromJson<GetAccessTokenFromCodeResponse>("AccessToken");
            var model = new IndexVm()
            {
                //AccessToken = token
            };

            //if (!string.IsNullOrEmpty(model.AccessToken?.AccessToken))
            //{
            //    var api = new PinchApi("sk_1234", "mr_9999");
            //    var result =  await api.Auth.GetClaims(model.AccessToken.AccessToken);
            //    model.Claims = result;
            //}

            return View(model);
        }

        public async Task<IActionResult> Connect()
        {
            var model = new IndexVm()
            {
            };

            return View(model);
        }
    }
}
