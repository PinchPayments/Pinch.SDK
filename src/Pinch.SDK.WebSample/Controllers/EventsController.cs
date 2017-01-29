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
    public class EventsController : BaseController
    {
        public EventsController(IOptions<PinchSettings> settings) : base(settings)
        {
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await GetApi().Event.GetEventsAll();

            return View(model);
        }

        //public async Task<IActionResult> Details(string id)
        //{
        //    var model = await GetApi().Event.Get();
        //}
    }
}
