using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Sources
{
    public class SourceSaveOptions
    {
        public string SourceType { get; set; }

        public string BankAccountNumber { get; set; }
        public string BankAccountBsb { get; set; }
        public string BankAccountName { get; set; }

        public string CreditCardToken { get; set; }
    }
}
