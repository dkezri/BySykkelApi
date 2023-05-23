using System;
using System.Net;

namespace OsloBySykkelApi.Extensions
{
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public CustomHttpResponseException(HttpStatusCode statusCode, string content) : base(content)
        {
            StatusCode = statusCode;
        }
    }
}
