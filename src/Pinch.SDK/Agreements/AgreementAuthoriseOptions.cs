using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Agreements
{
    /// <summary>
    /// Cancel an agreement
    /// </summary>
    public class AgreementAuthoriseOptions
    {
        /// <summary>
        /// The ID of the agreement to cancel
        /// </summary>
        public string AgreementId { get; set; }

        /// <summary>
        /// Hidden field for "any_merchant" clients only. (IE. Only the Pinch portal at the moment) 
        /// </summary>
        public string MerchantId { get; set; }
    }
}
