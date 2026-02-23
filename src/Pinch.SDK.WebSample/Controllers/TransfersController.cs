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
        public TransfersController(IOptions<PinchSettings> settings) : base(settings)
        {
        }

        public async Task<IActionResult> Index()
        {
            var transfers = await GetApi().Transfer.GetTransfers();

            return View(transfers.Data.ToList());
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
