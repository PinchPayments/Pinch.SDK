using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pinch.SDK.Converters;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Provides helper methods for creating HTTP content for various request types.
    /// </summary>
    public class HttpClientHelpers
    {
        /// <summary>
        /// Creates HTTP content for a POST request with URL-encoded form data.
        /// </summary>
        /// <param name="parameters">Dictionary of key-value pairs to be encoded as form data.</param>
        /// <returns>An <see cref="HttpContent"/> instance containing the URL-encoded form data.</returns>
        public static HttpContent GetPostBody(Dictionary<string, string> parameters)
        {
            var formatted = parameters.Select(x => x.Key + "=" + x.Value);
            return new StringContent(string.Join("&", formatted), Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        /// <summary>
        /// Creates HTTP content with JSON-serialized body.
        /// </summary>
        /// <param name="value">The object to serialize to JSON.</param>
        /// <returns>An <see cref="HttpContent"/> instance containing the JSON-serialized object.</returns>
        public static HttpContent GetJsonBody(object value)
        {
            return new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Creates multipart/form-data HTTP content for file uploads with additional form fields.
        /// </summary>
        /// <param name="fileData">The stream containing the file data to upload.</param>
        /// <param name="filename">The name of the file being uploaded.</param>
        /// <param name="otherbody">Additional form fields to include in the request. Null values are excluded.</param>
        /// <returns>An <see cref="HttpContent"/> instance containing the multipart form data.</returns>
        public static HttpContent GetMultipartFormBody(Stream fileData, string filename, Dictionary<string, string> otherbody)
        {
            var content = new MultipartFormDataContent();

            // Create form data fields
            foreach (var field in otherbody)
            {
                if (field.Value == null) // just null, let empty through
                {
                    continue;
                }

                var stringContent = new StringContent(field.Value);
                stringContent.Headers.Add("Content-Disposition", $"form-data; name=\"{field.Key}\"");
                content.Add(stringContent);
            }

            // Create file data
            var fileContent = new StreamContent(fileData);
            fileContent.Headers.Add("Content-Type", "application/octet-stream");
            fileContent.Headers.Add("Content-Disposition", $"form-data; name=\"file\"; filename=\"{filename}\"");
            content.Add(fileContent);

            return content;
        }
    }

    /// <summary>
    /// Provides extension methods for <see cref="HttpClient"/> to simplify API calls and response handling.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Performs a GET request and deserializes the response to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response data to.</typeparam>
        /// <param name="client">The HTTP client instance.</param>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the deserialized data or errors.</returns>
        public static async Task<ApiResponse<T>> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        /// <summary>
        /// Performs a GET request to download a file.
        /// </summary>
        /// <param name="client">The HTTP client instance.</param>
        /// <param name="url">The URL to download the file from.</param>
        /// <returns>An <see cref="ApiResponse{FileDto}"/> containing the file data or errors.</returns>
        public static async Task<ApiResponse<FileDto>> GetFile(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var qr = await QuickFileResponse.FromMessage(response);
            return qr.ToApiResponse();
        }

        /// <summary>
        /// Performs a POST request with URL-encoded form data and deserializes the response.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response data to.</typeparam>
        /// <param name="client">The HTTP client instance.</param>
        /// <param name="url">The URL to send the POST request to.</param>
        /// <param name="parameters">Dictionary of form parameters to include in the request body.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the deserialized data or errors.</returns>
        public static async Task<ApiResponse<T>> Post<T>(this HttpClient client, string url, Dictionary<string, string> parameters)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        /// <summary>
        /// Performs a POST request with JSON-serialized body and deserializes the response.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response data to.</typeparam>
        /// <param name="client">The HTTP client instance.</param>
        /// <param name="url">The URL to send the POST request to.</param>
        /// <param name="data">The object to serialize and send as JSON in the request body.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the deserialized data or errors.</returns>
        public static async Task<ApiResponse<T>> Post<T>(this HttpClient client, string url, object data)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetJsonBody(data));
            var qr = await QuickResponse<T>.FromMessage(response);
            return qr.ToApiResponse();
        }

        /// <summary>
        /// Performs a DELETE request.
        /// </summary>
        /// <param name="client">The HTTP client instance.</param>
        /// <param name="url">The URL to send the DELETE request to.</param>
        /// <returns>An <see cref="ApiResponse"/> containing any errors that occurred.</returns>
        public static async Task<ApiResponse> Delete(this HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            var qr = await QuickResponse.FromMessage(response);
            return qr.ToApiResponse();
        }
    }

    /// <summary>
    /// Represents an intermediate response wrapper for processing HTTP responses before converting to API responses.
    /// </summary>
    public class QuickResponse
    {
        /// <summary>
        /// Gets or sets the HTTP response message.
        /// </summary>
        public HttpResponseMessage Message { get; set; }

        /// <summary>
        /// Gets or sets the raw response body as a string.
        /// </summary>
        public string ResponseBody { get; set; }

        /// <summary>
        /// Gets or sets the list of errors from the API response.
        /// </summary>
        public List<ApiError> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this response is from an idempotency key replay.
        /// </summary>
        public bool IsIdempotencyKeyReplay { get; set; }

        /// <summary>
        /// Gets or sets the idempotency key(s) from the response.
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> IdempotencyKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickResponse"/> class.
        /// </summary>
        public QuickResponse()
        {
            Errors = new List<ApiError>();
        }

        /// <summary>
        /// Converts this quick response to an <see cref="ApiResponse"/>.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the errors.</returns>
        public ApiResponse ToApiResponse()
        {
            return new ApiResponse()
            {
                Errors = Errors
            };
        }

        /// <summary>
        /// Creates a <see cref="QuickResponse"/> from an HTTP response message.
        /// </summary>
        /// <param name="message">The HTTP response message to process.</param>
        /// <returns>A <see cref="QuickResponse"/> containing the processed response data.</returns>
        public static async Task<QuickResponse> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
            {
                response.HandleFailedCall();
                response.HandleIdempotencyKeyResponse();
            }

            return response;
        }

        /// <summary>
        /// Handles failed API calls by parsing error information from the response body.
        /// </summary>
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
        
        /// <summary>
        /// Handles idempotency key information from the response body.
        /// </summary>
        protected void HandleIdempotencyKeyResponse()
        {
            try
            {
                var result = JsonConvert.DeserializeObject<IdempotencyKeyResponseDto>(ResponseBody);

                IdempotencyKey = result.IdempotencyKey;
                IsIdempotencyKeyReplay = result.IsIdempotencyKeyReplay;
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }

    /// <summary>
    /// Represents an intermediate response wrapper for processing HTTP responses with typed data.
    /// </summary>
    /// <typeparam name="T">The type of data expected in the response.</typeparam>
    public class QuickResponse<T> : QuickResponse
    {
        /// <summary>
        /// Gets or sets the deserialized response data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Converts this quick response to an <see cref="ApiResponse{T}"/>.
        /// </summary>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the data and errors.</returns>
        public new ApiResponse<T> ToApiResponse()
        {
            return new ApiResponse<T>()
            {
                Errors = Errors,
                Data = Data
            };
        }

        /// <summary>
        /// Converts this quick response to an <see cref="IdempotencyKeyApiResponse{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IdempotencyKeyApiResponse{T}"/> containing the data, errors, and idempotency information.</returns>
        public IdempotencyKeyApiResponse<T> ToIdempotencyKeyResponse()
        {
            return new IdempotencyKeyApiResponse<T>()
            {
                Errors = Errors,
                Data = Data,
                IsIdempotencyKeyReplay = IsIdempotencyKeyReplay,
                IdempotencyKey = IdempotencyKey
            };
        }

        /// <summary>
        /// Creates a <see cref="QuickResponse{T}"/> from an HTTP response message.
        /// </summary>
        /// <param name="message">The HTTP response message to process.</param>
        /// <returns>A <see cref="QuickResponse{T}"/> containing the processed response data.</returns>
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
                response.HandleIdempotencyKeyResponse();
            }

            return response;
        }

        /// <summary>
        /// Handles idempotency key information from the response body for typed responses.
        /// </summary>
        protected void HandleIdempotencyKeyResponse()
        {
            try
            {

                var result = JsonConvert.DeserializeObject<IdempotencyKeyResponseDto<T>>(ResponseBody);

                IdempotencyKey = result.IdempotencyKey;
                IsIdempotencyKeyReplay = result.IsIdempotencyKeyReplay;
                Data = result.Data;
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }

    /// <summary>
    /// Represents an intermediate response wrapper for processing HTTP responses with typed data and inline error options.
    /// </summary>
    /// <typeparam name="T">The type of data expected in the response.</typeparam>
    /// <typeparam name="TOptions">The type of inline error options.</typeparam>
    public class QuickResponse<T, TOptions> : QuickResponse<T>
    {
        /// <summary>
        /// Gets or sets inline error information specific to the request.
        /// </summary>
        public TOptions InlineErrors { get; set; }

        /// <summary>
        /// Converts this quick response to an <see cref="ApiResponse{T, TOptions}"/>.
        /// </summary>
        /// <returns>An <see cref="ApiResponse{T, TOptions}"/> containing the data, errors, and inline errors.</returns>
        public new ApiResponse<T, TOptions> ToApiResponse()
        {
            return new ApiResponse<T, TOptions>()
            {
                InlineErrors = InlineErrors,
                Errors = Errors,
                Data = Data
            };
        }

        /// <summary>
        /// Creates a <see cref="QuickResponse{T, TOptions}"/> from an HTTP response message.
        /// </summary>
        /// <param name="message">The HTTP response message to process.</param>
        /// <returns>A <see cref="QuickResponse{T, TOptions}"/> containing the processed response data.</returns>
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
                response.HandleIdempotencyKeyResponse();
            }

            return response;
        }

        /// <summary>
        /// Handles failed API calls by parsing error and inline error information from the response body.
        /// </summary>
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

    /// <summary>
    /// Represents an intermediate response wrapper for processing file download responses.
    /// </summary>
    public class QuickFileResponse : QuickResponse<FileDto>
    {
        /// <summary>
        /// Creates a <see cref="QuickFileResponse"/> from an HTTP response message containing file data.
        /// </summary>
        /// <param name="message">The HTTP response message to process.</param>
        /// <returns>A <see cref="QuickFileResponse"/> containing the file data, filename, and content type.</returns>
        public new static async Task<QuickFileResponse> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickFileResponse
            {
                Message = message
            };

            if (message.IsSuccessStatusCode)
            {
                response.Data = new FileDto()
                {
                    Stream = await message.Content.ReadAsStreamAsync()
                };

                var header = message.Content.Headers.GetValues("content-disposition")?.ToList();
                if (header != null && header.Any())
                {
                    response.Data.Filename = new ContentDisposition(header.First()).FileName;
                }
                var contentTypeHeader = message.Content.Headers.GetValues("content-type")?.ToList();
                if (contentTypeHeader != null && contentTypeHeader.Any())
                {
                    response.Data.ContentType = contentTypeHeader.First();
                }
            }
            else
            {
                response.HandleFailedCall();
                response.HandleIdempotencyKeyResponse();
            }

            return response;
        }
    }
}
