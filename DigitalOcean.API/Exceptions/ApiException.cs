using System;
using System.Collections.Generic;
using System.Net;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Exceptions {
    public class ApiException : Exception {
        private readonly IDictionary<int, string> _errors = new Dictionary<int, string> {
            { 401, "Access Denied" },
            { 404, "Not Found" },
            { 429, "Rate Limit Exceeded" }
        };

        public HttpStatusCode StatusCode { get; private set; }

        public override string Message {
            get {
                return (_errors.ContainsKey((int)StatusCode)
                          ? _errors[(int)StatusCode]
                          : (_internalErrorResponse != null
                             ? $"{_internalErrorResponse.Id} : {_internalErrorResponse.Message}"
                             : ""));
            }
        }

        private readonly Error _internalErrorResponse;
        private Func<IRestResponse, Error> p;

        public ApiException(HttpStatusCode statusCode, Error errorResponse) {
            StatusCode = statusCode;
            _internalErrorResponse = errorResponse;
        }

        public ApiException(HttpStatusCode statusCode, Func<IRestResponse, Error> p) {
            StatusCode = statusCode;
            this.p = p;
        }
    }
}
