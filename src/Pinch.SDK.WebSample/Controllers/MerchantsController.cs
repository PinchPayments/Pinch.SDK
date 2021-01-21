using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Merchants;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class MerchantsController : BaseController
    {
        public MerchantsController(IOptions<PinchSettings> settings) : base(settings)
        {            
        }

        public async Task<IActionResult> Index()
        {
            var model = new MerchantsVm()
            {
                MyMerchant = await GetApi().Merchant.GetMerchant(),
                ManagedMerchants = await GetApi().Merchant.GetAllManagedMerchants(),
                ImpersonatedMerchantId = ImpersonatedMerchantId
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NewManaged()
        {
            return View(new ManagedMerchant());
        }

        [HttpPost]
        public async Task<IActionResult> NewManaged(ManagedMerchant model)
        {
            var result = await GetApi().Merchant.CreateManagedMerchant(new ManagedMerchantCreateOptions()
            {
                AccountName = model.AccountName,
                AccountNumber = model.AccountNumber,
                Bsb = model.Bsb,
                CompanyName = model.CompanyName,
                ContactEmail = model.ContactEmail,
                Postcode = model.Postcode,
                StreetAddress = model.StreetAddress,
                Suburb = model.Suburb,
                Abn = model.Abn,
                CompanyEmail = model.CompanyEmail,
                CompanyPhone = model.CompanyPhone,
                ContactFirstName = model.ContactFirstName,
                ContactLastName = model.ContactLastName,
                ContactPhone = model.ContactPhone,
                State = model.State,
                Dob = model.Dob,
                GovernmentNumber = model.GovernmentNumber,
                Country = model.Country,
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                UserAgent = Request.Headers["User-Agent"].ToString()
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName ?? "", x.ErrorMessage);
                });

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var merchant = await GetApi().Merchant.GetMerchant();

            return View(merchant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Merchant model)
        {
            var result = await GetApi().Merchant.UpdateMerchant(new MerchantUpdateOptions()
            {
                AccountName = model.AccountName,
                AccountNumber = model.AccountNumber,
                Bsb = model.Bsb,
                CompanyName = model.CompanyName,
                ContactEmail = model.ContactEmail,                
                ContactPhone = model.ContactPhone,
                Postcode = model.Postcode,
                StreetAddress = model.StreetAddress,
                Suburb = model.Suburb,
                State = model.State,
                Abn = model.Abn,
                BankStatementLabel = model.BankStatementLabel,
                DebitMessage = model.DebitMessage,      
                CompanyEmail = model.CompanyEmail,
                CompanyPhone = model.CompanyPhone,
                ContactFirstName = model.ContactFirstName,
                ContactLastName = model.ContactLastName,
                Dob = model.Dob,
                GovernmentNumber = model.GovernmentNumber,
                CompanyWebsiteUrl = model.CompanyWebsiteUrl,
                NatureOfBusiness = model.NatureOfBusiness
            });

            if (!result.Success)
            {
                result.Errors.ForEach(x => { ModelState.AddModelError(x.PropertyName, x.ErrorMessage); });

                return View(model);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Impersonate(string merchantId)
        {
            HttpContext.Session.SetObjectAsJson(SessionConstants.IMPERSONATED_MERCHANT_ID, merchantId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Unimpersonate()
        {
            HttpContext.Session.Remove(SessionConstants.IMPERSONATED_MERCHANT_ID);

            return RedirectToAction(nameof(Index));
        }
    }
}
