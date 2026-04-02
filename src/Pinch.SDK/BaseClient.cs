using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK
{
    /// <summary>
    /// Base HTTP client for the Pinch API SDK that handles HTTP communication, authentication, and token management.
    /// </summary>
    /// <remarks>
    /// This class provides core HTTP functionality for all API client operations, including:
    /// - Making GET, POST, and DELETE requests to the Pinch API
    /// - Managing JWT authentication tokens with automatic renewal on 401 Unauthorized responses
    /// - Handling request content serialization (JSON, form data, multipart form data)
    /// - Centralizing error handling and exception formatting
    /// </remarks>
    public class BaseClient
    {
        /// <summary>
        /// Gets the API configuration options including base URI and merchant impersonation settings.
        /// </summary>
        protected readonly PinchApiOptions Options;

        /// <summary>
        /// Factory function for creating HttpClient instances.
        /// </summary>
        private readonly Func<HttpClient> _httpClientFactory;

        /// <summary>
        /// Async function for retrieving the JWT access token, with an optional parameter to force token renewal.
        /// </summary>
        private readonly Func<bool, Task<string>> _getAccessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClient"/> class.
        /// </summary>
        /// <param name="options">The API configuration options.</param>
        /// <param name="getAccessToken">An async function that retrieves the access token. When passed <c>true</c>, forces token renewal.</param>
        /// <param name="httpClientFactory">A factory function for creating HttpClient instances.</param>
        public BaseClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _getAccessToken = getAccessToken;
            Options = options;
        }

        /// <summary>
        /// Sends an HTTP GET request and returns a deserialized response of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content into.</typeparam>
        /// <param name="url">The relative URL endpoint to GET.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        protected async Task<QuickResponse<T>> GetHttp<T>(string url)
        {
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Get, Options.BaseUri + url));
        }

        /// <summary>
        /// Sends an HTTP GET request and returns the response content as a file.
        /// </summary>
        /// <param name="url">The relative URL endpoint to GET.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the file response.</returns>
        protected async Task<QuickFileResponse> GetFile(string url)
        {
            return await SendHttpFile(() => new HttpRequestMessage(HttpMethod.Get, Options.BaseUri + url));
        }

        /// <summary>
        /// Sends an HTTP POST request with form-encoded parameters and returns a deserialized response of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content into.</typeparam>
        /// <param name="url">The relative URL endpoint to POST to.</param>
        /// <param name="parameters">The form parameters to include in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        protected async Task<QuickResponse<T>> PostHttp<T>(string url, Dictionary<string, string> parameters)
        {
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetPostBody(parameters)
            });
        }

        /// <summary>
        /// Sends an HTTP POST request with JSON-serialized data and returns a deserialized response of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content into.</typeparam>
        /// <param name="url">The relative URL endpoint to POST to.</param>
        /// <param name="data">The object to serialize as JSON in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        protected async Task<QuickResponse<T>> PostHttp<T>(string url, object data)
        {
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetJsonBody(data)
            });
        }

        /// <summary>
        /// Sends an HTTP POST request with multipart form data (file and additional parameters) and returns a deserialized response of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content into.</typeparam>
        /// <param name="url">The relative URL endpoint to POST to.</param>
        /// <param name="fileStream">The file stream to upload.</param>
        /// <param name="filename">The name of the file being uploaded.</param>
        /// <param name="otherData">Additional form parameters to include with the file.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        protected async Task<QuickResponse<T>> PostHttp<T>(string url, Stream fileStream, string filename, Dictionary<string, string> otherData)
        {
            return await SendHttp<T>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetMultipartFormBody(fileStream, filename, otherData)
            });
        }

        /// <summary>
        /// Sends an HTTP POST request with JSON-serialized data and returns a deserialized response with additional options of types <typeparamref name="T"/> and <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the primary response content into.</typeparam>
        /// <typeparam name="TOptions">The type to deserialize additional response options into.</typeparam>
        /// <param name="url">The relative URL endpoint to POST to.</param>
        /// <param name="data">The object to serialize as JSON in the request body.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response with options.</returns>
        protected async Task<QuickResponse<T, TOptions>> PostHttp<T, TOptions>(string url, object data)
        {
            return await SendHttp<T, TOptions>(() => new HttpRequestMessage(HttpMethod.Post, Options.BaseUri + url)
            {
                Content = HttpClientHelpers.GetJsonBody(data)
            });
        }

        /// <summary>
        /// Sends an HTTP DELETE request to the specified URL.
        /// </summary>
        /// <param name="url">The relative URL endpoint to DELETE.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        protected async Task<QuickResponse> DeleteHttp(string url)
        {
            return await SendHttp(() => new HttpRequestMessage(HttpMethod.Delete, Options.BaseUri + url));
        }

        /// <summary>
        /// Internal method that sends an HTTP request and returns a response.
        /// Handles authentication and automatic token refresh on 401 Unauthorized.
        /// </summary>
        /// <param name="requestFunc">A function that creates the HttpRequestMessage to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        /// <remarks>
        /// If the initial request receives a 401 Unauthorized response, the method automatically:
        /// 1. Requests a new token with the renew flag set to true
        /// 2. Recreates the request with the new token
        /// 3. Retries the request
        /// </remarks>
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

        /// <summary>
        /// Internal method that sends an HTTP request and returns a deserialized response of type <typeparamref name="T"/>.
        /// Handles authentication and automatic token refresh on 401 Unauthorized.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content into.</typeparam>
        /// <param name="requestFunc">A function that creates the HttpRequestMessage to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized API response.</returns>
        /// <remarks>
        /// If the initial request receives a 401 Unauthorized response, the method automatically:
        /// 1. Requests a new token with the renew flag set to true
        /// 2. Recreates the request with the new token
        /// 3. Retries the request
        /// </remarks>
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

        /// <summary>
        /// Internal method that sends an HTTP request and returns a deserialized response with additional options of types <typeparamref name="T"/> and <typeparamref name="TOptions"/>.
        /// Handles authentication and automatic token refresh on 401 Unauthorized.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the primary response content into.</typeparam>
        /// <typeparam name="TOptions">The type to deserialize additional response options into.</typeparam>
        /// <param name="requestFunc">A function that creates the HttpRequestMessage to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized API response with options.</returns>
        /// <remarks>
        /// If the initial request receives a 401 Unauthorized response, the method automatically:
        /// 1. Requests a new token with the renew flag set to true
        /// 2. Recreates the request with the new token
        /// 3. Retries the request
        /// </remarks>
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

        /// <summary>
        /// Internal method that sends an HTTP request and returns the response content as a file.
        /// Handles authentication and automatic token refresh on 401 Unauthorized.
        /// </summary>
        /// <param name="requestFunc">A function that creates the HttpRequestMessage to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the file response.</returns>
        /// <remarks>
        /// If the initial request receives a 401 Unauthorized response, the method automatically:
        /// 1. Requests a new token with the renew flag set to true
        /// 2. Recreates the request with the new token
        /// 3. Retries the request
        /// </remarks>
        private async Task<QuickFileResponse> SendHttpFile(Func<HttpRequestMessage> requestFunc)
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

                return await QuickFileResponse.FromMessage(response);
            }
            catch (Exception ex)
            {
                return new QuickFileResponse()
                {
                    Errors = new List<ApiError>()
                    {
                        new ApiError() {ErrorMessage = GetRecursiveErrorMessage(ex)}
                    }
                };
            }
        }

        /// <summary>
        /// Sets the authorization and other required headers on an HTTP request.
        /// </summary>
        /// <param name="message">The HTTP request message to add headers to.</param>
        /// <param name="renew">If <c>true</c>, forces retrieval of a new authentication token. If <c>false</c>, uses the current token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>
        /// This method adds the following headers:
        /// - Authorization: JWT bearer token from <see cref="_getAccessToken"/>
        /// - Current-Merchant: Merchant ID for impersonation (if configured in <see cref="Options"/>)
        /// - Pinch-Version: API version identifier
        /// </remarks>
        private async Task SetAuthHeader(HttpRequestMessage message, bool renew)
        {
            var token = await _getAccessToken(renew);

            message.Headers.Authorization = JwtAuthHeader.GetHeader(token);

            if (!string.IsNullOrEmpty(Options.ImpersonateMerchantId) && !message.Headers.Contains("Current-Merchant"))
            {
                message.Headers.Add("Current-Merchant", Options.ImpersonateMerchantId);
            }

            message.Headers.Add("Pinch-Version", "2026.1");
        }

        /// <summary>
        /// Recursively concatenates exception messages from an exception and all inner exceptions.
        /// </summary>
        /// <param name="ex">The exception to extract messages from.</param>
        /// <param name="delimeter">The string to use to separate multiple exception messages. Defaults to " --- ".</param>
        /// <returns>A concatenated string of all exception messages in the exception hierarchy.</returns>
        /// <remarks>
        /// This method traverses the entire exception chain via <see cref="Exception.InnerException"/>
        /// and formats the messages for API error responses.
        /// </remarks>
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
