using System;
using System.Collections.Generic;
using System.Net;

namespace DigitalOcean.API.Exceptions {
    public class ApiException : Exception {
        private readonly IDictionary<int, string> _errors = new Dictionary<int, string> {
            { 401, "Access Denied" },
            { 404, "Not Found" },
            { 429, "Rate Limit Exceeded" }
        };

        public HttpStatusCode StatusCode { get; private set; }

        public override string Message {
            get { return _errors.ContainsKey((int)StatusCode) ? _errors[(int)StatusCode] : "Unknown API error"; }
        }

        public ApiException(HttpStatusCode statusCode) {
            StatusCode = statusCode;
        }
    }
}