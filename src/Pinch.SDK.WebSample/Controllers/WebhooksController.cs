using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.Webhooks;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;

namespace Pinch.SDK.WebSample.Controllers
{
    public class WebhooksController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public WebhooksController(IOptions<PinchSettings> settings, ApplicationDbContext context) : base(settings)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(WebhookSaveOptions model)
        {
            var result = await GetApi().Webhook.Save(model);

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

        public async Task<IActionResult> Index()
        {
            var model = await GetApi().Webhook.GetWebhooks();

            if (!model.Success)
            {
                throw new Exception(string.Join(" - ", model.Errors.Select(x => x.ErrorMessage)));
            }

            return View(model.Data);
        }

        public async Task<IActionResult> ReceiveWebhook()
        {
            using (var sr = new StreamReader(Request.Body))
            {                
                var body = await sr.ReadToEndAsync();
                var headers = Request.Headers.ToDictionary(x => x.Key, x => x.Value);

                var headerDic = new Dictionary<string, string[]>();
                foreach (var h in headers)
                {
                    headerDic.Add(h.Key, h.Value.ToArray());
                }

                var isValid = GetApi().Webhook.VerifyWebhook("whsec_MucZPgWo3vkNorvRzNTaQQsHkOMyqiYy", body, headerDic);

                var delivery = new WebhookDelivery()
                {
                    Json = body
                };
                _context.WebhookDeliveries.Add(delivery);
                await _context.SaveChangesAsync();

                // A response message is optional, but will be saved.
                return Ok($"Webhook recieved. IsValid: {isValid}");
            }
        }
    }
}