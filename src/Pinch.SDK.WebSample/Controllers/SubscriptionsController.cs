using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pinch.SDK.Plans;
using Pinch.SDK.Subscriptions;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.ViewModels.Plans;
using Pinch.SDK.WebSample.ViewModels.Subscriptions;

namespace Pinch.SDK.WebSample.Controllers
{
    public class SubscriptionsController : BaseController
    {
        public SubscriptionsController(IOptions<PinchSettings> settings) : base(settings)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await GetApi().Subscriptions.GetSubscriptionsAll();

            return View(result.Data ?? new List<Subscription>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionCreateVm model)
        {
            var result = await GetApi().Subscriptions.Create(new SubscriptionCreateOptions()
            {
                PayerId = model.PayerId,
                PlanId = model.PlanId,
                StartDate = model.StartDate,
                TotalAmount = model.TotalAmount
            });

            if (!result.Success)
            {
                ModelState.Clear(); // Lets me return a changed model below.

                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName ?? "", x.ErrorMessage);
                });

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var plan = await GetApi().Subscriptions.Get(id);
            var payments = await GetApi().Payment.GetForSubscriptionAll(id);

            var model = new SubscriptionDetailsVm()
            {
                Subscription = plan.Data,
                Payments = payments.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(string id)
        {
            await GetApi().Subscriptions.Cancel(id);

            return RedirectToAction("Index");
        }
    }
}
