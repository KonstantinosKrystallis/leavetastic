using Microsoft.Extensions.Configuration;
using Radzen;

namespace LeaveTastic.Common.Services
{
    public class HttpService : HttpBaseService<object>
    {
        public HttpService(IHttpClientFactory httpClientFactory, IConfiguration configuration, NotificationService notificationService) : base(httpClientFactory, configuration, notificationService) { }
    }
}
