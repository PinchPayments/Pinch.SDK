using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.WebSample.Helpers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class TransfersController : Controller
    {
        private readonly PinchSettings _settings;

        public TransfersController(IOptions<PinchSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var api = new PinchApi(_settings.SecretKey, _settings.MerchantId, false, _settings.BaseUri, _settings.AuthUri);

            var transfers = await api.Transfer.GetTransfers();

            return View(transfers);
        }

        public async Task<IActionResult> Details(string id)
        {
            var api = new PinchApi(_settings.SecretKey, _settings.MerchantId, false, _settings.BaseUri, _settings.AuthUri);

            var lineItems = await api.Transfer.GetLineItemsAll(id);

            return View(lineItems);
        }
    }
}
