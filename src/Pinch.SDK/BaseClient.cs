using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK
{
    public class BaseClient
    {
        protected readonly HttpClient _client;
        private readonly Func<bool, Task<string>> _getAccessToken;
        private string _accessToken;

        public BaseClient(string baseUri, Func<bool, Task<string>> getAccessToken)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUri)
            };
            _getAccessToken = getAccessToken;            
        }

        protected async Task<QuickResponse<T>> GetHttp<T>(string url)
        {
            await SetInitialToken();

            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await _client.GetAsync(url);
            }

            return await QuickResponse<T>.FromMessage(response);
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, Dictionary<string, string> parameters)
        {
            await SetInitialToken();

            var response = await _client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await _client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            }

            return await QuickResponse<T>.FromMessage(response);
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, object data)
        {
            await SetInitialToken();

            var response = await _client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await _client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));
            }

            return await QuickResponse<T>.FromMessage(response);
        }

        protected async Task<QuickResponse> DeleteHttp(string url)
        {
            await SetInitialToken();

            var response = await _client.DeleteAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await GetToken();
                response = await _client.DeleteAsync(url);
            }

            return await QuickResponse.FromMessage(response);
        }

        private async Task SetInitialToken()
        {
            if (!string.IsNullOrEmpty(_accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(_accessToken);
                return;
            }

            await GetToken(false);
        }

        private async Task GetToken(bool renew = true)
        {
            _accessToken = await _getAccessToken(renew);

            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(_accessToken);
        }
    }
}
