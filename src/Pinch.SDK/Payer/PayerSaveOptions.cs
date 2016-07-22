using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Payer
{
    public class PayerSaveOptions
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
    }
}
