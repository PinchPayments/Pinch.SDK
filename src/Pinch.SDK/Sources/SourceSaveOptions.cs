﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Sources
{
    public class SourceSaveOptions
    {
        /// <summary>
        /// The type of payment source to use. Can be either "bank-account" or "credit-card".
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// The Token generated by the Pinch Capture javascript library.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The Payer's Bank Account Number. Currently must be between 3 and 10 digits long (inclusive). Everything except numbers will be stripped.
        /// </summary>
        [Obsolete("Legacy. Bank Accounts should be tokenized and sent via the Token field.")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The Payer's BSB (Bank State Branch number). Must be 6 digits. Everything except numbers will be stripped.
        /// </summary>
        [Obsolete("Legacy. Bank Accounts should be tokenized and sent via the Token field.")]
        public string BankAccountBsb { get; set; }

        /// <summary>
        /// The Payer's Bank Account Name. If left blank, it will be set to the Payer's name.
        /// </summary>
        [Obsolete("Legacy. Bank Accounts should be tokenized and sent via the Token field.")]
        public string BankAccountName { get; set; }

        /// <summary>
        /// The Token generated by the Pinch Capture javascript library.
        /// </summary>
        [Obsolete("Use Token instead.")]
        public string CreditCardToken { get; set; }

        /// <summary>
        /// Used for in-house data entry and phone orders; It excludes the card-entering device from being linked to the cards being entered.
        /// This is necessary to avoid our fraud monitoring from marking the device as using too many unique cards.
        /// You must contact support to gain permission to use this flag. Transactions will fail otherwise.
        /// </summary>
        public bool IsTrustedDevice { get; set; }
    }
}
