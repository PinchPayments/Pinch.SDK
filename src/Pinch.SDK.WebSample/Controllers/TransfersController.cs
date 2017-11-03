using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class TransfersController : BaseController
    {
        private readonly PinchSettings _settings;

        public TransfersController(IOptions<PinchSettings> settings) : base(settings)
        {
            _settings = settings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var transfers = await GetApi().Transfer.GetTransfers();

            return View(transfers);
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = new TransferDetailsVm()
            {
                Transfer = await GetApi().Transfer.Get(id),
                LineItems = await GetApi().Transfer.GetLineItemsAll(id)
            };           
            
            return View(model);
        }
    }
}
