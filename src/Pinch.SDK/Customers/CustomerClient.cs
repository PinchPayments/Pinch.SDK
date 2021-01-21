using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Customers
{
    public class CustomerClient : BaseClient
    {
        public CustomerClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Fetches detailed properties for a single Customer.
        /// </summary>
        /// <param name="id">Customer User ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Customer>> Get(string id)
        {
            var response = await GetHttp<Customer>($"customers/{id}");

            return response.ToApiResponse();
        }
    }
}
