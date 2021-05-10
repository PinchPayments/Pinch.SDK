using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Payers;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Refunds
{
    public class RefundsClient : BaseClient
    {
        public RefundsClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Create a Refund
        /// </summary>
        /// <param name="options">Refund information.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Refund, RefundSaveOptions>> Save(RefundSaveOptions options)
        {
            var response = await PostHttp<Refund, RefundSaveOptions>("refunds", options);

            return response.ToApiResponse();
        }
    }
}
