using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.ViewModels.Payments
{
    public class EditPaymentVm
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string SourceId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
