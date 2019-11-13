using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Plans;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionClient : BaseClient
    {
        public SubscriptionClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Get all subscriptions for a payer.
        /// </summary>
        /// <param name="payerId">Payer ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Paged<Subscription>>> GetSubscriptionsForPayer(string payerId)
        {
            var response = await GetHttp<Paged<Subscription>>($"subscriptions/payer/{payerId}");            

            return response.ToApiResponse();
        }

        /// <summary>
        /// Fetches detailed properties for a single subscription.
        /// </summary>
        /// <param name="id">Subscription ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Subscription>> Get(string id)
        {
            var response = await GetHttp<Subscription>($"subscriptions/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Create a new subscription to a plan
        /// </summary>
        /// <param name="options">Subscription information. All fields will be used.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Plan>> Create(SubscriptionCreateOptions options)
        {
            var response = await PostHttp<Plan>("subscriptions", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Cancel a subscription
        /// </summary>
        /// <param name="id">The Subscription ID to cancel</param>
        /// <returns></returns>
        public async Task<ApiResponse> Cancel(string id)
        {
            var response = await DeleteHttp($"subscriptions/{id}");

            return response.ToApiResponse();
        }
    }
}
