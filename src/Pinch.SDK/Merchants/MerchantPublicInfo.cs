using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// The information about a Merchant that is publicly available.
    /// It is intended to be displayed to new Payers signing up to direct debit.
    /// </summary>
    public class MerchantPublicInfo
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company Email Address
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// ABN (Australian Business Number)
        /// </summary>
        public string Abn { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// Suburb
        /// </summary>
        public string Suburb { get; set; }
        /// <summary>
        /// Postcode
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// <para>A description of why this Merchant takes payments via direct debit.
        /// This message will be displayed to payers signing up for direct debit via the hosted sign up page.
        /// Use a generic message rather than specifying amounts or details.</para>
        /// 
        /// Eg. "Ben's Gym uses direct debit to settle all gym fees. You can even purchase products in store 
        /// and have them taken from your account at the end of the month."
        /// </summary>
        public string DebitMessage { get; set; }
        /// <summary>
        /// This is the text that appears on the payers bank statement for payments taken by this merchant.
        /// </summary>
        public string BankStatementLabel { get; set; }
    }
}
