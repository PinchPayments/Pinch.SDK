using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Fees;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.ViewModels.Fees;

namespace Pinch.SDK.WebSample.Controllers
{
    public class FeesController : BaseController
    {
        private readonly PinchSettings _settings;

        public FeesController(IOptions<PinchSettings> settings) : base(settings)
        {
            _settings = settings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feesResponse = await GetApi().Fees.GetActiveFees();

            return View(feesResponse.Data);
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            var model = new CalculateFeesVm();

            model.PublishableKey = _settings.PublishableKey;
            model.BaseApiUrl = _settings.BaseUri.TrimEnd('/') + "/";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculateFeesVm model)
        {
            model.PublishableKey = _settings.PublishableKey;
            model.BaseApiUrl = _settings.BaseUri.TrimEnd('/') + "/";

            var result = await GetApi().Fees.Calculate(new FeesCalculateOptions()
            {
                Amount = model.Amount * 100,
                ApplicationFee = 0,
                Currency = model.Currency,
                SourceType = model.SourceType,
                SourceId = model.SourceId,
                Token = model.Token,
                Surcharge = model.Surcharge ? new List<string> {"credit-card", "bank-account"} : null
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(model);
            }

            model.FeesCalculation = result.Data;

            return View(model);
        }
    }
}