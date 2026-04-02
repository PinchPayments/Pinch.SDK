using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents the options for creating or updating a subscription plan.
    /// </summary>
    /// <remarks>
    /// This class encapsulates all configuration options for a plan, including its identification,
    /// payment schedules (fixed, recurring, and free periods), and validation errors. Use this class
    /// to define or modify plan details when working with the Pinch SDK.
    /// </remarks>
    public class PlanSaveOptions
    {
        /// <summary>
        /// Gets or sets the unique identifier for the plan.
        /// </summary>
        /// <remarks>
        /// When creating a new plan, this can be left empty to have an ID auto-generated.
        /// When updating an existing plan, this should contain the plan's existing ID.
        /// </remarks>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the plan.
        /// </summary>
        /// <remarks>
        /// This name is typically displayed to users and should be descriptive of the plan's purpose.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of free period configurations for the plan.
        /// </summary>
        /// <remarks>
        /// Free periods allow subscribers to access the plan without charges for specified durations.
        /// Multiple free periods can be configured for a single plan.
        /// </remarks>
        public List<PlanFreePeriodSaveOptions> FreePeriods { get; set; } = new List<PlanFreePeriodSaveOptions>();

        /// <summary>
        /// Gets or sets the list of fixed payment configurations for the plan.
        /// </summary>
        /// <remarks>
        /// Fixed payments are one-time or scheduled payments with specific amounts or percentages.
        /// Multiple fixed payments can be configured for a single plan.
        /// </remarks>
        public List<PlanFixedPaymentSaveOptions> FixedPayments { get; set; } = new List<PlanFixedPaymentSaveOptions>();

        /// <summary>
        /// Gets or sets the recurring payment configuration for the plan.
        /// </summary>
        /// <remarks>
        /// Defines the ongoing, repeating payment schedule for the subscription.
        /// A plan can have one recurring payment configuration.
        /// </remarks>
        public PlanRecurringPaymentSaveOptions RecurringPayment { get; set; }

        /// <summary>
        /// Gets or sets custom metadata associated with the plan.
        /// </summary>
        /// <remarks>
        /// This field can be used to store additional information in JSON or string format
        /// for application-specific purposes.
        /// </remarks>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the list of validation or API errors encountered during save operations.
        /// </summary>
        /// <remarks>
        /// This property is populated by the API when validation fails or other errors occur
        /// during plan creation or update operations.
        /// </remarks>
        public List<ApiError> Errors { get; set; }
    }
}
