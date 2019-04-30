using System.IO;
using System.Threading.Tasks;

namespace Pinch.SDK.Agreements
{
    public interface IAgreementClient
    {
        /// <summary>
        /// Get the full details for an Agreement
        /// </summary>
        /// <param name="agreementId">Agreement ID</param>
        /// <returns></returns>
        Task<ApiResponse<AgreementDetailed>> Get(string agreementId);

        /// <summary>
        /// Gets the full details for an Agreement, using the temporary public access token.
        /// This lets the user access the details of an agreement without being authenticated 
        /// for a short period of time. Currently used internally and shouldn't be needed by 
        /// non-Pinch integrators.
        /// </summary>
        /// <param name="token">Anonymous DDR Token</param>
        /// <returns></returns>
        Task<ApiResponse<AgreementDetailed>> GetByAnonymousToken(string token);

        /// <summary>
        /// Get the Direct Debit Request PDF. This is the contract between the Payer and Pinch Payments.
        /// </summary>
        /// <param name="agreementId">Agreement ID</param>
        /// <returns></returns>
        Task<ApiResponse<Stream>> GetDdr(string agreementId);

        /// <summary>
        /// Create a new Agreement. Uses the current Payer details.
        /// </summary>
        /// <param name="options">Agreement options</param>
        /// <returns></returns>
        Task<ApiResponse<AgreementDetailed>> Create(AgreementSaveOptions options);

        /// <summary>
        /// Authorise an Agreement. This action implies the Payer has read the Direct Debit Request and 
        /// Service Agreement, and is clicking confirm. This will also trigger an email to the Payer
        /// containing PDF copies of these agreements.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResponse<AgreementDetailed>> Authorise(AgreementAuthoriseOptions options);

        /// <summary>
        /// Cancel an Agreement. The attached payer will no longer be able to make payments.
        /// </summary>
        /// <param name="options">Agreement options</param>
        /// <returns></returns>
        Task<ApiResponse> Cancel(AgreementCancelOptions options);
    }
}