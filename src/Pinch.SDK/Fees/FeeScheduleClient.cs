using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pinch.SDK.Fees
{
    public class FeeScheduleClient : BaseClient
    {
        public FeeScheduleClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        public async Task<ApiResponse<FeeSchedule>> GetCurrentFeeSchedule(string merchantId)
        {
            var response = await GetHttp<FeeSchedule>($"merchant-admin/active-fee-schedule/{merchantId}");

            return response.ToApiResponse();
        }

        public async Task<ApiResponse<FeeSchedule>> Create(FeeScheduleSaveOptions options)
        {
            var response = await PostHttp<FeeSchedule>("merchant-admin/fee-schedules", options);

            return response.ToApiResponse();
        }
    }
}
