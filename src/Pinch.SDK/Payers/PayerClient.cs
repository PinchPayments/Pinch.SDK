using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payers
{
    public class PayerClient : BaseClient
    {
        public PayerClient(string baseUri, Func<bool, Task<string>> getAccessToken)
            : base(baseUri, getAccessToken)
        {
        }

        public async Task<List<Payer>> GetPayers()
        {
            var response = await GetHttp<List<Payer>>("payers");

            return response.Data;
        }

        public async Task<Payer> Get(string id)
        {
            var response = await GetHttp<Payer>($"payers/{id}");

            return response.Data;
        }

        public async Task<ApiResponse<Payer>> Save(PayerSaveOptions options)
        {
            var response = await PostHttp<Payer>("payers", options);

            return new ApiResponse<Payer>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"payers/{id}");

            return new ApiResponse()
            {
                Errors = response.Errors
            };
        }
    }
}
