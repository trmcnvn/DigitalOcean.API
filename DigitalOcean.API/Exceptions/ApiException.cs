using System;
using System.Collections.Generic;
using System.Net;

namespace DigitalOcean.API.Exceptions {
    public class ApiException : Exception {
        private readonly IDictionary<HttpStatusCode, string> _errors = new Dictionary<HttpStatusCode, string> {
            { HttpStatusCode.Unauthorized, "Access Denied" },
            { HttpStatusCode.NotFound, "Not Found" }
        };

        public HttpStatusCode StatusCode { get; private set; }

        public override string Message {
            get { return _errors.ContainsKey(StatusCode) ? _errors[StatusCode] : "Unknown API error"; }
        }

        public ApiException(HttpStatusCode statusCode) {
            StatusCode = statusCode;
        }
    }
}