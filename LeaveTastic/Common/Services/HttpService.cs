using LeaveTastic.Shared.Models;
using Microsoft.Extensions.Configuration;
using Radzen;

namespace LeaveTastic.Common.Services
{
    public class HttpService : HttpBaseService<BaseResponse>
    {
        public HttpService(HttpClient httpClient, IConfiguration configuration, NotificationService notificationService) : base(httpClient, configuration, notificationService) { }
    }
}
