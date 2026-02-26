using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Client for managing fee schedules in the Pinch API.
    /// </summary>
    /// <remarks>
    /// This class provides methods to retrieve active fee schedules and create new fee schedules for merchants.
    /// It inherits from <see cref="BaseClient"/> to leverage common HTTP communication functionality.
    /// </remarks>
    public class FeeScheduleClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeeScheduleClient"/> class.
        /// </summary>
        /// <param name="options">The Pinch API configuration options.</param>
        /// <param name="getAccessToken">A factory function that retrieves an access token for API authentication.</param>
        /// <param name="httpClientFactory">A factory function that provides configured HTTP client instances.</param>
        public FeeScheduleClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Retrieves the currently active fee schedule for the specified merchant.
        /// </summary>
        /// <param name="merchantId">The unique identifier of the merchant.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="ApiResponse{T}"/> 
        /// with the active <see cref="FeeSchedule"/> for the merchant, or an error response if the operation fails.
        /// </returns>
        public async Task<ApiResponse<FeeSchedule>> GetCurrentFeeSchedule(string merchantId)
        {
            var response = await GetHttp<FeeSchedule>($"fees-admin/active-fee-schedule/{merchantId}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Creates a new fee schedule with the specified configuration options.
        /// </summary>
        /// <param name="options">The fee schedule configuration options containing the schedule details.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="ApiResponse{T}"/> 
        /// with the newly created <see cref="FeeSchedule"/>, or an error response if the operation fails.
        /// </returns>
        public async Task<ApiResponse<FeeSchedule>> Create(FeeScheduleSaveOptions options)
        {
            var response = await PostHttp<FeeSchedule>("fees-admin/fee-schedules", options);

            return response.ToApiResponse();
        }
    }
}
