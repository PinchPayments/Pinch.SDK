using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.ViewModels.Realtime
{
    public class CreateRealtimePaymentVm
    {
        public string PublishableKey { get; set; }
        public string CreditCardToken { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public string BaseApiUrl { get; set; }
        public string Nonce { get; set; }
    }
}
