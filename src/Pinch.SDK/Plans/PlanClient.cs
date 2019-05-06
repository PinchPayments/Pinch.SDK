using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Payers;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Plans
{
    public class PlanClient : BaseClient
    {
        public PlanClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Fetches detailed properties for a single Plan.
        /// </summary>
        /// <param name="id">Plan ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Plan>> Get(string id)
        {
            var response = await GetHttp<Plan>($"plans/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Add or Update a Plan
        /// </summary>
        /// <param name="options">Plan information. All fields will be used.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Plan>> Save(PlanSaveOptions options)
        {
            var response = await PostHttp<Plan>("plans", options);

            return response.ToApiResponse();
        }
    }
}
