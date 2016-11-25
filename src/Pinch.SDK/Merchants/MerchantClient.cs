using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Merchants
{
    public class MerchantClient
    {
        private readonly HttpClient _client;
        private readonly Func<Task<string>> _getAccessToken;

        public MerchantClient(string baseUri, Func<Task<string>> getAccessToken)
        {
            _getAccessToken = getAccessToken;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<Merchant> GetMerchant()
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<Merchant>("merchants");

            return response.Data;
        }

        public async Task<IEnumerable<ManagedMerchant>> GetAllManagedMerchants()
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<IEnumerable<ManagedMerchant>>("merchants/managed");

            return response.Data;
        }

        public async Task<ApiResponse<Merchant>> UpdateMerchant(MerchantUpdateOptions options)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Post<Merchant>("merchants", options);

            return new ApiResponse<Merchant>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse<ManagedMerchant>> CreateManagedMerchant(ManagedMerchantCreateOptions options)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Post<ManagedMerchant>("merchants/managed", options);

            return new ApiResponse<ManagedMerchant>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }
    }

}
