using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pinch.SDK.Customers
{
    /// <summary>
    /// Client for interacting with the Pinch Payments API customer endpoints.
    /// Provides methods to retrieve customer information and manage customer-related operations.
    /// </summary>
    public class CustomerClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerClient"/> class.
        /// </summary>
        /// <param name="options">The Pinch API configuration options.</param>
        /// <param name="getAccessToken">A delegate that retrieves the access token for API authentication.</param>
        /// <param name="httpClientFactory">A delegate that provides an HttpClient instance for making HTTP requests.</param>
        public CustomerClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Fetches detailed properties for a single customer.
        /// </summary>
        /// <param name="id">The unique customer user ID.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the <see cref="Customer"/> details, or an error response if the customer is not found.</returns>
        public async Task<ApiResponse<Customer>> Get(string id)
        {
            var response = await GetHttp<Customer>($"customers/{id}");

            return response.ToApiResponse();
        }
    }
}
