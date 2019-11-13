using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Func<HttpClient> _httpClientFactory;
        private readonly Func<bool, Task<string>> _getAccessToken;        

        public BaseClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _getAccessToken = getAccessToken;
            Options = options;
        }

        protected async Task<QuickResponse<T>> GetHttp<T>(string url)
        {            
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Get, Options.BaseUri + url));
        }

        protected async Task<QuickFile> GetFile(string url)
        {
            return await SendHttpFile(() => new HttpRequestMessage(HttpMethod.Get, Options.BaseUri + url));
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, Dictionary<string, string> parameters)
        {            
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetPostBody(parameters)
            });            
        }

        protected async Task<QuickResponse<T>> PostHttp<T>(string url, object data)
        {            
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetJsonBody(data)
            });
        }        
        
        protected async Task<QuickResponse<T, TOptions>> PostHttp<T, TOptions>(string url, object data)
        {            
            return await SendHttp<T, TOptions>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetJsonBody(data)
            });
        }

        protected async Task<QuickResponse> DeleteHttp(string url)
        {
            return await SendHttp(() => new HttpRequestMessage(HttpMethod.Delete, Options.BaseUri + url));
        }

        private async Task<QuickResponse> SendHttp(Func<HttpRequestMessage> requestFunc)
        {
            try
            {
                var request = requestFunc();
                await SetAuthHeader(request, false);

                var response = await _httpClientFactory().SendAsync(request);
                
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    request = requestFunc();
                    await SetAuthHeader(request, true);
                    response = await _httpClientFactory().SendAsync(request);
                }                

                return await QuickResponse.FromMessage(response);
            }
            catch (Exception ex)
            {                
                return new QuickResponse()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError() {ErrorMessage = GetRecursiveErrorMessage(ex)}
                    }
                };
            }
        }

        private async Task<QuickResponse<T>> SendHttp<T>(Func<HttpRequestMessage> requestFunc)
        {
            try
            {
                var request = requestFunc();
                await SetAuthHeader(request, false);

                var response = await _httpClientFactory().SendAsync(request);
                
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    request = requestFunc();
                    await SetAuthHeader(request, true);
                    response = await _httpClientFactory().SendAsync(request);
                }                

                return await QuickResponse<T>.FromMessage(response);
            }
            catch (Exception ex)
            {                
                return new QuickResponse<T>()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError() {ErrorMessage = GetRecursiveErrorMessage(ex)}
                    }
                };
            }
        }

        private async Task<QuickResponse<T, TOptions>> SendHttp<T, TOptions>(Func<HttpRequestMessage> requestFunc)
        {
            try
            {
                var request = requestFunc();
                await SetAuthHeader(request, false);

                var response = await _httpClientFactory().SendAsync(request);
                
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    request = requestFunc();
                    await SetAuthHeader(request, true);
                    response = await _httpClientFactory().SendAsync(request);
                }                

                return await QuickResponse<T, TOptions>.FromMessage(response);
            }
            catch (Exception ex)
            {                
                return new QuickResponse<T, TOptions>()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError() {ErrorMessage = GetRecursiveErrorMessage(ex)}
                    }
                };
            }
        }

        private async Task<QuickFile> SendHttpFile(Func<HttpRequestMessage> requestFunc)
        {
            try
            {
                var request = requestFunc();
                await SetAuthHeader(request, false);

                var response = await _httpClientFactory().SendAsync(request);
                
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    request = requestFunc();
                    await SetAuthHeader(request, true);
                    response = await _httpClientFactory().SendAsync(request);
                }                

                return await QuickFile.FromMessage(response);
            }
            catch (Exception ex)
            {                
                return new QuickFile()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError() {ErrorMessage = GetRecursiveErrorMessage(ex)}
                    }
                };
            }
        }

        private async Task SetAuthHeader(HttpRequestMessage message, bool renew)
        {
            var token = await _getAccessToken(renew);

            message.Headers.Authorization = JwtAuthHeader.GetHeader(token);

            if (!string.IsNullOrEmpty(Options.ImpersonateMerchantId) && !message.Headers.Contains("Current-Merchant"))
            {
                message.Headers.Add("Current-Merchant", Options.ImpersonateMerchantId);
            }

            if (!string.IsNullOrEmpty(Options.ApiVersion))
            {
                message.Headers.Add("Pinch-Version", Options.ApiVersion);
            }
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
