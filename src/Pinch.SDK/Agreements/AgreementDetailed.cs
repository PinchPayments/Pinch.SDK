using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Agreements
{
    public class AgreementDetailed
    {
        public string Id { get; set; }
        public string SurnameOrCompanyName { get; set; }
        public string GivenNamesOrAbn { get; set; }
        public string AccountName { get; set; }
        public string AccountBsb { get; set; }
        public string AccountNumber { get; set; }
        public string SignatoryName { get; set; }
        public string SignatoryAddress1 { get; set; }
        public string SignatoryAddress2 { get; set; }
        public string SignatoryEmail { get; set; }

        public DateTime AgreementDateUtc { get; set; }
        public DateTime? ConfirmedDateUtc { get; set; }

        public string AnonymousViewToken { get; set; }

        public Payer Payer { get; set; }
    }
}
