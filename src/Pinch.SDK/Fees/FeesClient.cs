using System;
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

        public async Task<ApiResponse<FeesCalculation>> Calculate(FeesCalculateOptions options)
        {
            var response = await PostHttp<FeesCalculation>("fees/calculate", options);

            return response.ToApiResponse();
        }
    }
}
