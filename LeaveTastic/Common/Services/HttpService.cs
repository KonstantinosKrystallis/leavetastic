using Microsoft.Extensions.Configuration;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Common.Services
{
    public class HttpService : HttpBaseService<object>
    {
        public HttpService(HttpClient httpClient, IConfiguration configuration, NotificationService notificationService): base(httpClient, configuration, notificationService) { }
    }
}
