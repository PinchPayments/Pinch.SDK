using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Statements
{
    public class MerchantInvoice
    {
        /// <summary>
        /// The Daily Statement ID
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Invoice generation date. 
        /// </summary>
        public string StatementDateLocal { get; set; }

        /// <summary>
        /// Start Date of the merchant invoice
        /// </summary>
        public string PeriodStartDateLocal { get; set; }


        /// <summary>
        /// End Date of the merchant invoice
        /// </summary>
        public string PeriodEndDateLocal { get; set; }
    }
}
