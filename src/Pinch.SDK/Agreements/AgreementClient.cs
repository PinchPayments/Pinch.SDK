using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Agreements
{
    public class AgreementClient : BaseClient
    {
        public AgreementClient(string baseUri, Func<bool, Task<string>> getAccessToken)
            : base(baseUri, getAccessToken)
        {
        }

        /// <summary>
        /// Get the full details for an Agreement
        /// </summary>
        /// <param name="agreementId">Agreement ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<AgreementDetailed>> Get(string agreementId)
        {
            var response = await GetHttp<AgreementDetailed>($"agreements/{agreementId}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Gets the full details for an Agreement, using the temporary public access token.
        /// This lets the user access the details of an agreement without being authenticated 
        /// for a short period of time. Currently used internally and shouldn't be needed by 
        /// non-Pinch integrators.
        /// </summary>
        /// <param name="token">Anonymous DDR Token</param>
        /// <returns></returns>
        public async Task<ApiResponse<AgreementDetailed>> GetByAnonymousToken(string token)
        {
            var response = await GetHttp<AgreementDetailed>($"agreements/token/{token}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Get the Direct Debit Request PDF. This is the contract between the Payer and Pinch Payments.
        /// </summary>
        /// <param name="agreementId">Agreement ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Stream>> GetDdr(string agreementId)
        {
            var response = await GetFile($"agreements/ddr/{agreementId}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Create a new Agreement. Uses the current Payer details.
        /// </summary>
        /// <param name="options">Agreement options</param>
        /// <returns></returns>
        public async Task<ApiResponse<AgreementDetailed>> Create(AgreementSaveOptions options)
        {
            var response = await PostHttp<AgreementDetailed>("agreements", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Authorise an Agreement. This action implies the Payer has read the Direct Debit Request and 
        /// Service Agreement, and is clicking confirm. This will also trigger an email to the Payer
        /// containing PDF copies of these agreements.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ApiResponse<AgreementDetailed>> Authorise(AgreementAuthoriseOptions options)
        {
            var response = await PostHttp<AgreementDetailed>("agreements/authorise", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Cancel an Agreement. The attached payer will no longer be able to make payments.
        /// </summary>
        /// <param name="options">Agreement options</param>
        /// <returns></returns>
        public async Task<ApiResponse> Cancel(AgreementCancelOptions options)
        {
            var response = await PostHttp<string>("agreements/cancel", options);

            return response.ToApiResponse();
        }
    }
}
