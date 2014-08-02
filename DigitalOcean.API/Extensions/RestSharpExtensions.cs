using System;
using System.Net;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using RestSharp;
using RestSharp.Extensions;

namespace DigitalOcean.API.Extensions {
    public static class RestSharpExtensions {
        public static async Task<IRestResponse<T>> ExecuteTask<T>(this IRestClient client, IRestRequest request)
            where T : new() {
            var ret = await client.ExecuteTaskAsync<T>(request).ConfigureAwait(false);
            return ret.ThrowIfException();
        }

        private static IRestResponse<T> ThrowIfException<T>(this IRestResponse<T> response) where T : new() {
            if (response.ErrorException != null) {
                throw new ApplicationException("There was an an exception thrown during the request.",
                    response.ErrorException);
            }

            if (response.ResponseStatus != ResponseStatus.Completed) {
                throw response.ResponseStatus.ToWebException();
            }

            if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode <= HttpStatusCode.PartialContent) {
                throw new ApiException(response.StatusCode);
            }

            return response;
        }
    }
}