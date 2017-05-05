using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Payments;
using Pinch.SDK.WebSample.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly PinchSettings _settings;

        public PaymentsController(IOptions<PinchSettings> settings) : base(settings)
        {
            _settings = settings.Value;
        }

        public async Task<IActionResult> Scheduled()
        {
            var result = await GetApi().Payment.GetScheduled();
            var payments = result.Data;

            return View(payments.ToList());
        }

        public async Task<IActionResult> Processed()
        {
            var result = await GetApi().Payment.GetProcessed();
            var payments = result.Data;

            return View(payments.ToList());
        }

        public async Task<IActionResult> Details(string id)
        {
            var payment = await GetApi().Payment.Get(id);

            return View(payment);
        }

        public async Task<IActionResult> New()
        {
            return View("Edit", new Payment());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var details = await GetApi().Payment.Get(id);

            var payment = new Payment()
            {
                Id = details.Id,
                Amount = details.Amount,
                TransactionDate = details.TransactionDate,
                Description = details.Description,
                PayerId = details.Payer.Id,
                Status = details.Status
            };

            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Payment model)
        {
            var result = await GetApi().Payment.Save(new PaymentSaveOptions()
            {
                Id = model.Id,
                PayerId = model.PayerId,
                TransactionDate = model.TransactionDate,
                Amount = model.Amount,
                Description = model.Description
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View(model);
            }

            return RedirectToAction("Scheduled");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await GetApi().Payment.Delete(id);

            return RedirectToAction("Scheduled");
        }
    }
}
