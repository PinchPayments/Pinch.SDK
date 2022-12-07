﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Auth;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class BaseController : Controller
    {
        private readonly PinchSettings _settings;

        protected string ImpersonatedMerchantId => HttpContext.Session.GetObjectFromJson<string>(SessionConstants.IMPERSONATED_MERCHANT_ID);

        public BaseController(IOptions<PinchSettings> options)
        {
            _settings = options.Value;
        }

        protected PinchApi GetApi()
        {
            var token = HttpContext.Session.GetObjectFromJson<GetAccessTokenFromCodeResponse>("AccessToken");

            if (token != null)
            {
                return new PinchApi(_settings.MerchantId, _settings.SecretKey, new PinchApiOptions(){
                    IsLive = _settings.IsLive,
                    BaseUri = _settings.BaseUri,
                    AuthUri = _settings.AuthUri,
                    ApplicationId = _settings.ApplicationId,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    ImpersonateMerchantId = ImpersonatedMerchantId
                });
            }

            return new PinchApi(_settings.MerchantId, _settings.SecretKey, new PinchApiOptions()
            {
                IsLive = _settings.IsLive,
                BaseUri = _settings.BaseUri,
                AuthUri = _settings.AuthUri,
                ImpersonateMerchantId = ImpersonatedMerchantId
            });
        }
    }
}
