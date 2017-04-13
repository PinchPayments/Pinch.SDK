using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Agreements
{
    /// <summary>
    /// An Agreement between the Payer and the Bank. This is created when a new payer is created.
    /// This is a summarised version designed to be returned in lists. Use <see cref="AgreementClient.Get"/>
    /// to get the full details.
    /// </summary>
    public class Agreement
    {
        /// <summary>
        /// Agreement ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A temporary public access token that let's you fetch this agreement without being authenticated.
        /// The token is only valid for a short period of time, and isn't really needed by non-Pinch integrators.
        /// </summary>
        public string AnonymousViewToken { get; set; }

        /// <summary>
        /// When the agreement was created
        /// </summary>
        public DateTime AgreementDateUtc { get; set; }
        /// <summary>
        /// When the agreement was confirmed by the Payer
        /// </summary>
        public DateTime? ConfirmedDateUtc { get; set; }
    }
}
