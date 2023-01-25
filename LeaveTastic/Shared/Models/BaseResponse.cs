using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTastic.Shared.Models
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode = HttpStatusCode.OK;

        public string Message { get; set; } = "Action completed sucessfully";
        public bool HasError { get; set; } = false;
        
        public Exception Exception { get; set; } = null;
    }
}
