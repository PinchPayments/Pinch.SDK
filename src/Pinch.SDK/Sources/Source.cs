using System;

namespace Pinch.SDK.Sources
{
    public class Source
    {
        public string Id { get; set; }
        public string SourceType { get; set; }

        public string BankAccountNumber { get; set; }
        public string BankAccountBsb { get; set; }
        public string BankAccountName { get; set; }

        public string CreditCardToken { get; set; }
        public string CardHolderName { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DisplayCardNumber { get; set; }
        public string CardScheme { get; set; }
        public string Origin { get; set; }
    }
}
