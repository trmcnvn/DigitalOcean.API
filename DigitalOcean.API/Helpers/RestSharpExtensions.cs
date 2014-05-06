using System;
using System.Net;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using RestSharp;
using RestSharp.Extensions;

namespace DigitalOcean.API.Helpers {
    public static class RestSharpExtensions {
        public static Task<IRestResponse<T>> ExecuteTask<T>(this IRestClient client, IRestRequest request)
            where T : new() {
            var ret = client.ExecuteTaskAsync<T>(request);
            return ret.ThrowIfException();
        }

        private static Task<T> ThrowIfException<T>(this Task<T> task) where T : IRestResponse {
            return task.ContinueWith(x => {
                var res = x.Result;

                if (res.ErrorException != null) {
                    throw new ApplicationException("Unknown retrieving response", res.ErrorException);
                }

                if (res.ResponseStatus != ResponseStatus.Completed) {
                    throw res.ResponseStatus.ToWebException();
                }

                if (res.StatusCode != HttpStatusCode.OK) {
                    throw new ApiException(res.StatusCode);
                }

                return res;
            });
        }
    }
}