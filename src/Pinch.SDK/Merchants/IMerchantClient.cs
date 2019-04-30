using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public interface IMerchantClient
    {
        /// <summary>
        /// Gets all information for the current merchant, You!
        /// </summary>
        /// <returns></returns>
        Task<Merchant> GetMerchant();

        /// <summary>
        /// Gets the publicly available information for the given Merchant
        /// </summary>
        /// <param name="merchantId">Merchant ID</param>
        /// <returns></returns>
        Task<ApiResponse<MerchantPublicInfo>> GetMerchantPublicInfo(string merchantId);

        /// <summary>
        /// Gets a list of all of your Managed Merchants.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ManagedMerchant>> GetAllManagedMerchants();

        /// <summary>
        /// Update your merchant information. If you want to update a Managed Merchant's information,
        /// you must use their MerchantID and SecretKey. These can be found by calling <see cref="MerchantClient.GetAllManagedMerchants"/>.
        /// </summary>
        /// <param name="options">The updated values to set. All values will be used, so be sure to set all fields.</param>
        /// <returns></returns>
        Task<ApiResponse<Merchant>> UpdateMerchant(MerchantUpdateOptions options);

        /// <summary>
        /// Create a new Managed Merchant. Managed Merchants are identical to regular Merchants, 
        /// except they can be completely controlled by their parent.
        /// </summary>
        /// <param name="options">The new Merchant's information</param>
        /// <returns></returns>
        Task<ApiResponse<ManagedMerchant>> CreateManagedMerchant(ManagedMerchantCreateOptions options);
    }
}