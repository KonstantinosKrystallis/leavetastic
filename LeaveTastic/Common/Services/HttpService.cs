using Microsoft.Extensions.Configuration;
using Radzen;

namespace LeaveTastic.Common.Services
{
    public class HttpService : HttpBaseService<object>
    {
        public HttpService(HttpClient httpClient, IConfiguration configuration, NotificationService notificationService) : base(httpClient, configuration, notificationService) { }
    }
}
