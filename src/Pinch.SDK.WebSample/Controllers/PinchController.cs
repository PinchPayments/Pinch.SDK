using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pinch.SDK.WebSample.Helpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class PinchController : Controller
    {

        public IActionResult Callback(string code)
        {
            return View("Callback", code);
        }

        public async Task<IActionResult> GetAccessToken(string code)
        {
            var api = new PinchApi("sk_1234", "mr_9999");

            var result = await api.Auth.GetAccessTokenFromCode(code, "ap_9999", "https://localhost:44389/pinch/callback");

            HttpContext.Session.SetObjectAsJson("AccessToken", result);

            return View("GetAccessToken", result);
        }
    }
}
