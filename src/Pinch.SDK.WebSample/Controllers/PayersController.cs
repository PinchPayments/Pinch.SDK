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
    public class PayersController : Controller
    {
        private readonly PinchSettings _settings;

        public PayersController(IOptions<PinchSettings> settings)
        {
            _settings = settings.Value;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var api = new PinchApi(_settings.SecretKey, _settings.MerchantId);

            var payers = await api.Payer.GetPayers();

            return View(payers);
        }
    }
}
