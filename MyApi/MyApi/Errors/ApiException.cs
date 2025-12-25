using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Errors
{
    public class ApiException(int StatusCode, string ErrorMessage, string details)
    {

        public string ErrorMessage { get; set; } = ErrorMessage;
        public int StatusCode { get; set; } = StatusCode;
        public string? details { get; set; } = details;
    }
}