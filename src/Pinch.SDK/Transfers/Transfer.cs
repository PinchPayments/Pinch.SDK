using System;

namespace Pinch.SDK.Transfers
{
    /// <summary>
    /// Represents a financial transfer in the Pinch payment system.
    /// </summary>
    /// <remarks>
    /// This class contains all the essential information about a transfer transaction,
    /// including transfer details, account information, and billing status.
    /// </remarks>
    public class Transfer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transfer.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the statement reference associated with this transfer.
        /// </summary>
        public string StatementReference { get; set; }

        /// <summary>
        /// Gets or sets the date when the transfer was initiated.
        /// </summary>
        public DateTime TransferDate { get; set; }

        /// <summary>
        /// Gets or sets the transfer amount in the smallest currency unit (e.g., cents for AUD).
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the transfer (e.g., "AUD", "USD").
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the name of the account holder receiving the transfer.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account number for the receiving account.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the Bank State Branch (BSB) code for Australian accounts.
        /// </summary>
        public string Bsb { get; set; }

        /// <summary>
        /// Gets or sets the reference text for the transfer transaction.
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the current status of the transfer (e.g., "pending", "completed", "failed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the type of transfer (e.g., "payout", "refund").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the applicable tax rate for the transfer.
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transfer amount is billed gross (inclusive of tax).
        /// </summary>
        public bool IsGrossBilled { get; set; }
    }
}
