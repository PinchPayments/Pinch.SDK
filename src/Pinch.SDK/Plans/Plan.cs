using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents a subscription plan in the Pinch payment system.
    /// </summary>
    /// <remarks>
    /// A plan defines the structure and terms of a subscription, including any free periods, fixed payments, and recurring charges.
    /// Plans can be configured with metadata and track the number of active subscribers.
    /// </remarks>
    public class Plan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the plan.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the plan.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of free trial or free periods associated with the plan.
        /// </summary>
        /// <remarks>
        /// Defaults to an empty list if no free periods are defined.
        /// </remarks>
        public IEnumerable<PlanFreePeriod> FreePeriods { get; set; } = new List<PlanFreePeriod>();

        /// <summary>
        /// Gets or sets the collection of one-time fixed payments associated with the plan.
        /// </summary>
        /// <remarks>
        /// Defaults to an empty list if no fixed payments are defined.
        /// </remarks>
        public IEnumerable<PlanFixedPayment> FixedPayments { get; set; } = new List<PlanFixedPayment>();

        /// <summary>
        /// Gets or sets the recurring payment configuration for the plan.
        /// </summary>
        /// <remarks>
        /// This defines the recurring billing cycle and amount for ongoing subscription charges.
        /// </remarks>
        public PlanRecurringPayment RecurringPayment { get; set; }

        /// <summary>
        /// Gets or sets optional metadata associated with the plan.
        /// </summary>
        /// <remarks>
        /// Can be used to store additional custom information about the plan in JSON or other formats.
        /// </remarks>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the number of active subscribers currently on this plan.
        /// </summary>
        public int SubscriberCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plan requires a total amount to be specified for billing.
        /// </summary>
        /// <remarks>
        /// When true, a total billing amount must be provided when charging subscribers on this plan.
        /// </remarks>
        public bool RequiresTotalAmount { get; set; }
    }
}
