using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        public static async Task<QuickResponse<T>> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            return await QuickResponse<T>.FromMessage(response);
        }

        public static async Task<QuickResponse<T>> Post<T>(this HttpClient client, string url, Dictionary<string, string> parameters)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            return await QuickResponse<T>.FromMessage(response);
        }

        public static async Task<QuickResponse<T>> Post<T>(this HttpClient client, string url, object data)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));
            return await QuickResponse<T>.FromMessage(response);
        }

        public static async Task<QuickResponse> Delete(this HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            return await QuickResponse.FromMessage(response);
        }
    }

    public class QuickResponse
    {
        public HttpResponseMessage Message { get; set; }

        public string ResponseBody { get; set; }

        public List<ApiError> Errors { get; set; }

        public QuickResponse()
        {
            Errors = new List<ApiError>();
        }

        public static async Task<QuickResponse> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
            {
                try
                {
                    response.Errors = JsonConvert.DeserializeObject<List<ApiError>>(response.ResponseBody);
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new ApiError()
                    {
                        ErrorMessage = response.ResponseBody
                    });
                }
            }

            return response;
        }
    }

    public class QuickResponse<T> : QuickResponse
    {
        public T Data { get; set; }

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
                try
                {
                    response.Errors = JsonConvert.DeserializeObject<List<ApiError>>(response.ResponseBody);
                }
                catch (Exception ex)
                {
                    response.Errors.Add(new ApiError()
                    {
                        ErrorMessage = response.ResponseBody
                    });
                }
            }

            return response;
        }
    }
}
