using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pinch.SDK.Plans;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.ViewModels.Plans;

namespace Pinch.SDK.WebSample.Controllers
{
    public class PlansController : BaseController
    {
        public PlansController(IOptions<PinchSettings> settings) : base(settings)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await GetApi().Plan.GetPlansAll();

            return View(result.Data ?? new List<Plan>());
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(PlanSaveVm model)
        {
            var options = JsonConvert.DeserializeObject<PlanSaveOptions>(model.JsonData ?? "");

            var result = await GetApi().Plan.Save(options);

            if (!result.Success)
            {
                ModelState.Clear(); // Lets me return a changed model below.

                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName ?? "", x.ErrorMessage);
                });

                model.JsonData = JsonConvert.SerializeObject(result.InlineErrors,Formatting.Indented);

                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}