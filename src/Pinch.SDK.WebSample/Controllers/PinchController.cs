﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.WebSample.Helpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class PinchController : BaseController
    {
        private readonly PinchSettings _settings;

        public PinchController(IOptions<PinchSettings> settings) : base(settings)
        {
            _settings = settings.Value;
        }

        public async Task<IActionResult> Callback(string code)
        {            
            var result = await GetApi().Auth.GetAccessTokenFromCode(code, _settings.ApplicationId, Url.Action("Callback", "Pinch", null, Request.Scheme));

            HttpContext.Session.SetObjectAsJson("AccessToken", result);

            return RedirectToAction("Connect", "Home");
        }
    }
}
