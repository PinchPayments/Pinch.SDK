using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pinch.SDK.Helpers
{
    public class HttpClientHelpers
    {
        public static HttpContent GetPostBody(Dictionary<string, string> parameters)
        {
            var formatted = parameters.Select(x => x.Key + "=" + x.Value);
            return new StringContent(string.Join("&", formatted), Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        public static HttpContent GetJsonBody(object value)
        {
            return new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
        }
    }

    public static class HttpClientExtensions
    {
        public static async Task<ApiResponse<T>> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        public static async Task<ApiResponse> GetFile(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var qr = await QuickFile.FromMessage(response);
            return qr.ToApiResponse();
        }

        public static async Task<ApiResponse<T>> Post<T>(this HttpClient client, string url, Dictionary<string, string> parameters)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        public static async Task<ApiResponse<T>> Post<T>(this HttpClient client, string url, object data)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        public static async Task<ApiResponse> Delete(this HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            var qr = await QuickResponse.FromMessage(response);
            return qr.ToApiResponse();
        }
    }

    public class QuickResponse
    {
        public HttpResponseMessage Message { get; set; }

        public string ResponseBody { get; set; }

        public List<ApiError> Errors { get; set; }

        public bool IsNonceReplay { get; set; }
        public string Nonce { get; set; }

        public QuickResponse()
        {
            Errors = new List<ApiError>();
        }

        public ApiResponse ToApiResponse()
        {
            return new ApiResponse()
            {
                Errors = Errors
            };
        }

        public static async Task<QuickResponse> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
            {
                response.HandleFailedCall();
                response.HandleNonceResponse();
            }

            return response;
        }

        protected void HandleFailedCall()
        {
            try
            {
                Errors = JsonConvert.DeserializeObject<List<ApiError>>(ResponseBody) ?? new List<ApiError>();

                if (!Errors.Any())
                {
                    Errors.Add(new ApiError()
                    {
                        ErrorMessage = !string.IsNullOrEmpty(ResponseBody) ? ResponseBody : Message.StatusCode.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Errors.Add(new ApiError()
                {
                    ErrorMessage = !string.IsNullOrEmpty(ResponseBody) ? ResponseBody : Message.StatusCode.ToString()
                });
            }
        }
        
        protected void HandleNonceResponse()
        {
            try
            {
                var result = JsonConvert.DeserializeObject<NonceResponse>(ResponseBody);

                Nonce = result.Nonce;
                IsNonceReplay = result.IsNonceReplay;
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }

    public class QuickResponse<T> : QuickResponse
    {
        public T Data { get; set; }

        public new ApiResponse<T> ToApiResponse()
        {
            return new ApiResponse<T>()
            {
                Errors = Errors,
                Data = Data
            };
        }

        public new static async Task<QuickResponse<T>> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse<T>();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (message.IsSuccessStatusCode)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.ResponseBody);
            }
            else
            {
                response.HandleFailedCall();
                response.HandleNonceResponse();
            }

            return response;
        }

        protected void HandleNonceResponse()
        {
            try
            {

                var result = JsonConvert.DeserializeObject<NonceResponse<T>>(ResponseBody);

                Nonce = result.Nonce;
                IsNonceReplay = result.IsNonceReplay;
                Data = result.Data;
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }

    public class QuickResponse<T, TOptions> : QuickResponse<T>
    {
        public TOptions InlineErrors { get; set; }

        public new ApiResponse<T, TOptions> ToApiResponse()
        {
            return new ApiResponse<T, TOptions>()
            {
                InlineErrors = InlineErrors,
                Errors = Errors,
                Data = Data
            };
        }

        public new static async Task<QuickResponse<T, TOptions>> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse<T, TOptions>();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (message.IsSuccessStatusCode)
            {
                response.Data = JsonConvert.DeserializeObject<T>(response.ResponseBody);
            }
            else
            {
                response.HandleFailedCall();
                response.HandleNonceResponse();
            }

            return response;
        }

        protected new void HandleFailedCall()
        {
            try
            {
                var tempResponse = JsonConvert.DeserializeObject<ApiResponse<T, TOptions>>(ResponseBody);

                if (tempResponse != null)
                {
                    InlineErrors = tempResponse.InlineErrors;
                    Errors = tempResponse.Errors;
                    return;
                }

                Errors = JsonConvert.DeserializeObject<List<ApiError>>(ResponseBody) ?? new List<ApiError>();

                if (!Errors.Any())
                {
                    Errors.Add(new ApiError()
                    {
                        ErrorMessage = !string.IsNullOrEmpty(ResponseBody) ? ResponseBody : Message.StatusCode.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Errors.Add(new ApiError()
                {
                    ErrorMessage = !string.IsNullOrEmpty(ResponseBody) ? ResponseBody : Message.StatusCode.ToString()
                });
            }
        }
    }

    public class QuickFile : QuickResponse<Stream>
    {
        public new static async Task<QuickFile> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickFile();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (message.IsSuccessStatusCode)
            {
                response.Data = await message.Content.ReadAsStreamAsync();
            }
            else
            {
                response.HandleFailedCall();
                response.HandleNonceResponse();
            }

            return response;
        }
    }
}
