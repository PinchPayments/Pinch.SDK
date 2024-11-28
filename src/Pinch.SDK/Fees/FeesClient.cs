using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pinch.SDK.Fees
{
    public class FeesClient : BaseClient
    {
        public FeesClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Get the current active Fee Scheduled for a merchant
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<MerchantFeeSchedule>> GetActiveFees()
        {
            var response = await GetHttp<MerchantFeeSchedule>("fees");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Calculate potential fees for a given set of transaciton options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ApiResponse<FeesCalculation>> Calculate(FeesCalculateOptions options)
        {
            var response = await PostHttp<FeesCalculation>("fees/calculate", options);

            return response.ToApiResponse();
        }
    }
}
