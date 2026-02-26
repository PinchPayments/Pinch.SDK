using System;

namespace Pinch.SDK.Sources
{
    /// <summary>
    /// Represents a payment source, which can be either a bank account or a credit card.
    /// </summary>
    public class Source
    {
        /// <summary>
        /// Gets or sets the unique identifier for the payment source.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the type of payment source (e.g., "bank_account" or "credit_card").
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the bank account number. Only applicable when the source type is a bank account.
        /// </summary>
        public string BankAccountNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the bank account BSB (Bank-State-Branch) number. Only applicable when the source type is a bank account.
        /// </summary>
        public string BankAccountBsb { get; set; }
        
        /// <summary>
        /// Gets or sets the bank account holder's name. Only applicable when the source type is a bank account.
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// Gets or sets the tokenized credit card value. Only applicable when the source type is a credit card.
        /// </summary>
        public string CreditCardToken { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the credit card holder. Only applicable when the source type is a credit card.
        /// </summary>
        public string CardHolderName { get; set; }
        
        /// <summary>
        /// Gets or sets the credit card expiry date. Only applicable when the source type is a credit card.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }
        
        /// <summary>
        /// Gets or sets the masked card number for display purposes (e.g., "****1234"). Only applicable when the source type is a credit card.
        /// </summary>
        public string DisplayCardNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the credit card scheme (e.g., "Visa", "Mastercard"). Only applicable when the source type is a credit card.
        /// </summary>
        public string CardScheme { get; set; }
        
        /// <summary>
        /// Gets or sets the origin or source of where this payment source was created or obtained.
        /// </summary>
        public string Origin { get; set; }
    }
}
