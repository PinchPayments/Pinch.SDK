using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Agreements
{
    /// <summary>
    /// Create a new agreement
    /// </summary>
    public class AgreementSaveOptions
    {
        /// <summary>
        /// The ID of the payer to create an agreement for
        /// </summary>
        public string PayerId { get; set; }

        /// <summary>
        /// Hidden field for "any_merchant" clients only. (IE. Only the Pinch portal at the moment) 
        /// </summary>
        public string MerchantId { get; set; }
    }
}
