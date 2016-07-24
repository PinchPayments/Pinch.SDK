using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Pinch.SDK.Auth;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;
using Pinch.SDK.WebSample.ViewModels;

namespace Pinch.SDK.WebSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly PinchSettings _settings;

        public HomeController(IOptions<PinchSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Connect()
        {
            var token = HttpContext.Session.GetObjectFromJson<GetAccessTokenFromCodeResponse>("AccessToken");
            var model = new IndexVm()
            {
                AccessToken = token
            };

            if (!string.IsNullOrEmpty(model.AccessToken?.AccessToken))
            {
                var api = new PinchApi(_settings.SecretKey, _settings.MerchantId);
                var result = await api.Auth.GetClaims(model.AccessToken.AccessToken);
                model.Claims = result;
            }

            return View(model);
        }
    }
}
