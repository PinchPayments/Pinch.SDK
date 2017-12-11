using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.ViewModels.Payers
{
    public class SourceSaveVm
    {
        public string PayerId { get; set; }
        public string SourceType { get; set; }

        public string BankAccountNumber { get; set; }
        public string BankAccountBsb { get; set; }
        public string BankAccountName { get; set; }

        public string CreditCardToken { get; set; }

    }
}
