using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Merchants
{
    public class MerchantClient : BaseClient
    {
        public MerchantClient(string baseUri, Func<bool, Task<string>> getAccessToken) 
            : base(baseUri, getAccessToken)
        {
        }

        public async Task<Merchant> GetMerchant()
        {
            var response = await GetHttp<Merchant>("merchants");

            return response.Data;
        }

        public async Task<IEnumerable<ManagedMerchant>> GetAllManagedMerchants()
        {
            var response = await GetHttp<IEnumerable<ManagedMerchant>>("merchants/managed");

            return response.Data;
        }

        public async Task<ApiResponse<Merchant>> UpdateMerchant(MerchantUpdateOptions options)
        {
            var response = await PostHttp<Merchant>("merchants", options);

            return new ApiResponse<Merchant>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse<ManagedMerchant>> CreateManagedMerchant(ManagedMerchantCreateOptions options)
        {
            var response = await PostHttp<ManagedMerchant>("merchants/managed", options);

            return new ApiResponse<ManagedMerchant>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }
    }

}
