using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK
{
    public class BaseClient
    {
        protected readonly PinchApiOptions Options;
        protected readonly HttpClient Client;
        private readonly Func<bool, Task<string>> _getAccessToken;
        private string _accessToken;

        public BaseClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken)
        {
            Options = options;
            Client = new HttpClient()
            {
                BaseAddress = new Uri(options.BaseUri)
            };
            _getAccessToken = getAccessToken;

            if (!string.IsNullOrEmpty(options.ImpersonateMerchantId))
            {
                Client.DefaultRequestHeaders.Add("Current-Merchant", options.ImpersonateMerchantId);
            }
        }

        protected async Task<QuickResponse<T>> GetHttp<T>(string url)
        {
            try
            {
                await SetInitialToken();

                var response = await Client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await GetToken();
                    response = await Client.GetAsync(url);
                }

                return await QuickResponse<T>.FromMessage(response);
            }
            catch (Exception ex)
            {
                return new QuickResponse<T>()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError()
                        {
                            ErrorMessage = GetRecursiveErrorMessage(ex)
                        }
                    }
                };
            }
        }

        protected async Task<QuickFile> GetFile(string url)
        {
            await SetInitialToken();

            var response = await Client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await Client.GetAsync(url);
            }
            
            return await QuickFile.FromMessage(response);
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, Dictionary<string, string> parameters)
        {
            await SetInitialToken();

            var response = await Client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await Client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            }

            return await QuickResponse<T>.FromMessage(response);
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, object data)
        {
            await SetInitialToken();

            var response = await Client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await Client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));
            }

            return await QuickResponse<T>.FromMessage(response);
        }

        protected async Task<QuickResponse> DeleteHttp(string url)
        {
            await SetInitialToken();

            var response = await Client.DeleteAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await Client.DeleteAsync(url);
            }

            return await QuickResponse.FromMessage(response);
        }

        private async Task SetInitialToken()
        {
            if (!string.IsNullOrEmpty(_accessToken))
            {
                Client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(_accessToken);
                return;
            }

            await GetToken(false);
        }

        private async Task GetToken(bool renew = true)
        {
            _accessToken = await _getAccessToken(renew);

            Client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(_accessToken);
        }

        private string GetRecursiveErrorMessage(Exception ex, string delimeter = " --- ")
        {
            var sb = new StringBuilder();
            var currentException = ex;
            while (currentException != null)
            {
                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    sb.Append(delimeter);
                }
                sb.Append(currentException.Message);

                currentException = currentException.InnerException;
            }

            return sb.ToString();
        }
    }
}
