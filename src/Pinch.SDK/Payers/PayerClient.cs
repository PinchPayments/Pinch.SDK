using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payers
{
    public class PayerClient
    {
        private readonly HttpClient _client;
        private readonly Func<Task<string>> _getAccessToken;

        public PayerClient(string baseUri, Func<Task<string>> getAccessToken)
        {
            _getAccessToken = getAccessToken;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<List<Payer>> GetPayers()
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<List<Payer>>("payers");

            return response.Data;
        }

        public async Task<Payer> Get(string id)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<Payer>($"payers/{id}");

            return response.Data;
        }

        public async Task<ApiResponse<Payer>> Save(PayerSaveOptions options)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Post<Payer>("payers", options);

            return new ApiResponse<Payer>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse> Delete(string id)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Delete($"payers/{id}");

            return new ApiResponse()
            {
                Errors = response.Errors
            };
        }
    }
}
