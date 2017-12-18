using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Payers;
using Pinch.SDK.Sources;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;
using Pinch.SDK.WebSample.ViewModels.Payers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class PayersController : BaseController
    {
        private readonly PinchSettings _settings;

        public PayersController(IOptions<PinchSettings> settings) : base(settings)
        {
            _settings = settings.Value;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var payers = await GetApi().Payer.GetPayersAll();

            if (!payers.Success)
            {
                throw new Exception(string.Join(" - ", payers.Errors.Select(x => x.ErrorMessage)));
            }

            return View(payers.Data.ToList());
        }

        public async Task<IActionResult> Details(string id)
        {
            var payer = await GetApi().Payer.Get(id);
            var payments = await GetApi().Payment.GetForPayer(id);

            var model = new PayerDetailsVm()
            {
                Payer = payer.Data,
                Payments = payments
            };

            return View(model);
        }

        public async Task<IActionResult> New()
        {
            return View("Edit", new PayerDetailed());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var payer = await GetApi().Payer.Get(id);

            if (!payer.Success)
            {
                return BadRequest(payer.Errors);
            }

            return View(payer.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PayerDetailed model)
        {
            var result = await GetApi().Payer.Save(new PayerSaveOptions()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await GetApi().Payer.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> NewSource(string payerId)
        {
            return View("NewSource", new SourceSaveVm()
            {
                PayerId = payerId
            });
        }

        [HttpPost]
        public async Task<IActionResult> NewSource(SourceSaveVm model)
        {
            if (!string.IsNullOrEmpty(model.BankAccountBsb))
            {
                model.SourceType = "bank-account";
            }
            else if (!string.IsNullOrEmpty(model.CreditCardToken))
            {
                model.SourceType = "credit-card";
            }

            var result = await GetApi().Payer.SaveSource(model.PayerId, new SourceSaveOptions() 
            {            
                SourceType = model.SourceType,
                BankAccountName = model.BankAccountName,
                BankAccountBsb = model.BankAccountBsb,
                BankAccountNumber = model.BankAccountNumber,
                CreditCardToken = model.CreditCardToken
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });

                return View(model);
            }

            return RedirectToAction("Details", new {id = model.PayerId});
        }
    }
}
