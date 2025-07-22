using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            return View(new ManagedMerchantCreateOptions()
            {
                Contacts = new List<ContactSaveOptions>()
                {
                    new ContactSaveOptions() {
                        IsPrimaryContact = true
                    }
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> NewManaged(ManagedMerchantCreateOptions model)
        {
            model.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserAgent = Request.Headers["User-Agent"].ToString();
            model.OrganisationType = "company";
            model.Contacts[0].IsPrimaryContact = true;
            model.Contacts[0].ContactType = "owner";

            var result = await GetApi().Merchant.CreateManagedMerchant(model);

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

            var model = new MerchantUpdateOptions()
            {
                BankAccountName = merchant.BankAccountName,
                BankAccountNumber = merchant.BankAccountNumber,
                BankAccountRoutingNumber = merchant.BankAccountRoutingNumber,
                CompanyName = merchant.CompanyName,
                LegalPostcode = merchant.LegalPostcode,
                LegalStreetAddress = merchant.LegalStreetAddress,
                LegalSuburb = merchant.LegalSuburb,
                LegalState = merchant.LegalState,
                TradingPostcode = merchant.TradingPostcode,
                TradingStreetAddress = merchant.TradingStreetAddress,
                TradingSuburb = merchant.TradingSuburb,
                TradingState = merchant.TradingState,
                TradingCountry = merchant.TradingCountry,
                CompanyRegistrationNumber = merchant.CompanyRegistrationNumber,
                BankStatementLabel = merchant.BankStatementLabel,
                CompanyEmail = merchant.CompanyEmail,
                CompanyPhone = merchant.CompanyPhone,
                CompanyWebsiteUrl = merchant.CompanyWebsiteUrl,
                NatureOfBusiness = merchant.NatureOfBusiness,
                Contacts = merchant.Contacts.Select(x => new ContactSaveOptions()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    ContactType = x.ContactType
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MerchantUpdateOptions model)
        {
            var result = await GetApi().Merchant.UpdateMerchant(model);

            if (!result.Success)
            {
                result.Errors.ForEach(x => { ModelState.AddModelError(x.PropertyName, x.ErrorMessage); });

                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Documents()
        {
            var merchant = await GetApi().Merchant.GetMerchant();

            var model = new MerchantDocumentsVm()
            {
                Merchant = merchant,
                Documents = merchant.Compliance.Documents.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Documents([FromForm] MerchantDocumentsVm model)
        {
            var result = await GetApi().Merchant.UploadDocument(new DocumentUploadOptions()
            {
                DocumentType = model.DocumentType,
                ContactId = model.ContactId,
                File = model.File?.OpenReadStream(),
                Filename = model.File?.FileName
            });

            if (!result.Success)
            {
                var merchant = await GetApi().Merchant.GetMerchant();

                model.Merchant = merchant;
                model.Documents = merchant.Compliance.Documents.ToList();

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.PropertyName ?? "", err.ErrorMessage);
                }

                return View(model);
            }

            return RedirectToAction("Documents");
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
