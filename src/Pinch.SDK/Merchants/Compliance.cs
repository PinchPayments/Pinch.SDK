using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class Compliance
    {
        public string MerchantNotes { get; set; }
        public string PropertyErrors { get; set; }
        public string ComplianceOfficerNotes { get; set; }
        public string Status { get; set; }
        private DateTimeOffset SubmissionDate { get; set; }
        private DateTimeOffset? DecisionDate { get; set; }

        public bool LiveEnabled { get; set; }
        public bool TransactionsEnabled { get; set; }
        public bool SettlementsEnabled { get; set; }

        public string DocumentVerificationStatus { get; set; }
        public string BankAccountVerificationStatus { get; set; }
        public IList<ContactCompliance> ContactCompliances { get; set; } = new List<ContactCompliance>();

        public IList<Document> Documents { get; set; } = new List<Document>();
    }
}
