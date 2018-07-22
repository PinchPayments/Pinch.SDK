using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Merchants
{
    public class MerchantClient : BaseClient
    {
        public MerchantClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory) 
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Gets all information for the current merchant, You!
        /// </summary>
        /// <returns></returns>
        public async Task<Merchant> GetMerchant()
        {
            var response = await GetHttp<Merchant>("merchants");

            return response.Data;
        }

        /// <summary>
        /// Gets the publicly available information for the given Merchant
        /// </summary>
        /// <param name="merchantId">Merchant ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<MerchantPublicInfo>> GetMerchantPublicInfo(string merchantId)
        {
            var response = await GetHttp<MerchantPublicInfo>($"merchants/public/{merchantId}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Gets a list of all of your Managed Merchants.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ManagedMerchant>> GetAllManagedMerchants()
        {
            var response = await GetHttp<IEnumerable<ManagedMerchant>>("merchants/managed");

            return response.Data;
        }

        /// <summary>
        /// Update your merchant information. If you want to update a Managed Merchant's information,
        /// you must use their MerchantID and SecretKey. These can be found by calling <see cref="GetAllManagedMerchants"/>.
        /// </summary>
        /// <param name="options">The updated values to set. All values will be used, so be sure to set all fields.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Merchant>> UpdateMerchant(MerchantUpdateOptions options)
        {
            var response = await PostHttp<Merchant>("merchants/update", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Create a new Managed Merchant. Managed Merchants are identical to regular Merchants, 
        /// except they can be completely controlled by their parent.
        /// </summary>
        /// <param name="options">The new Merchant's information</param>
        /// <returns></returns>
        public async Task<ApiResponse<ManagedMerchant>> CreateManagedMerchant(ManagedMerchantCreateOptions options)
        {
            var response = await PostHttp<ManagedMerchant>("merchants/managed", options);

            return response.ToApiResponse();
        }
    }

}
