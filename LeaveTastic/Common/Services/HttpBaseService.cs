using Microsoft.Extensions.Configuration;
using Radzen;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeaveTastic.Common.Services
{
    public class HttpBaseService<Type> where Type : notnull, new()
    {
        protected readonly HttpClient _httpClient;
        protected readonly NotificationService _notificationService;

        public const string successActionMessage = "success";

        public string BaseUrl { get; protected set; }

        public HttpBaseService(HttpClient httpClient, IConfiguration configuration, NotificationService notificationService)
        {
            _httpClient = httpClient;
            BaseUrl = _httpClient.BaseAddress.ToString();
            _notificationService = notificationService;
        }

        public virtual async Task<T> Get<T>(string uri, Dictionary<string, string> headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl + uri);
            return await Send<T>(request, headers, showSuccessNotfication, notificationMessage);
        }

        public virtual async Task<T> Post<T>(string uri, object body = null, Dictionary<string, string> headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + uri);
            if (body != null)
            {
                request.Content = JsonContent.Create(body);
            }
            return await Send<T>(request, headers, showSuccessNotfication, notificationMessage);
        }

        public virtual async Task<T> Put<T>(string uri, object? body = null, Dictionary<string, string>? headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + uri);
            if (body != null)
            {
                request.Content = JsonContent.Create(body);
            }
            return await Send<T>(request, headers, showSuccessNotfication, notificationMessage);
        }

        public virtual async Task<T> Patch<T>(string uri, object? body = null, Dictionary<string, string> headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, BaseUrl + uri);
            if (body != null)
            {
                request.Content = JsonContent.Create(body);
            }
            return await Send<T>(request, headers, showSuccessNotfication, notificationMessage);
        }

        public virtual async Task<T> Delete<T>(string uri, Dictionary<string, string> headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, BaseUrl + uri);
            return await Send<T>(request, headers, showSuccessNotfication, notificationMessage);
        }

        private async Task<T> Send<T>(HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers = null, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            if (headers?.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
            return await BaseSend<T>(httpRequestMessage, showSuccessNotfication, notificationMessage);
        }

        private async Task<T> BaseSend<T>(HttpRequestMessage httpRequestMessage, bool showSuccessNotfication = false, string notificationMessage = successActionMessage) where T : notnull, new()
        {
            T response = new();
            try
            {
                //httpRequestMessage.SetBrowserRequestMode();
                using var httpResponse = await _httpClient.SendAsync(httpRequestMessage);
                response = await httpResponse.Content.ReadFromJsonAsync<T>();
                if (response != null)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        if (showSuccessNotfication)
                        {
                            await ShowNotification(new() { Severity = NotificationSeverity.Success, Summary = "Success", Detail = notificationMessage, Duration = 6000 });
                        }
                    }
                    else
                    {
                        await ShowNotification(new() { Severity = NotificationSeverity.Error, Summary = "Server Error", Detail = httpResponse.ReasonPhrase, Duration = 10000 });
                    }
                }
                return response;
            }
            catch (Exception e)
            {
                await ShowNotification(new() { Severity = NotificationSeverity.Error, Summary = "Client Error", Detail = e.Message, Duration = 10000 });
                return response;
            }
        }

        async Task ShowNotification(NotificationMessage notificationMessage)
        {
            var task = Task.Run(() => _notificationService.Notify(notificationMessage));
            await task;
        }
    }
}
