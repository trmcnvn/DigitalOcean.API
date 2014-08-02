using System;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Extensions;

namespace DigitalOcean.API.Extensions {
    public static class RestSharpExtensions {
        public static async Task<T> ExecuteTask<T>(this IRestClient client, IRestRequest request)
            where T : new() {
            var ret = await client.ExecuteTaskAsync(request).ConfigureAwait(false);
            return ret.ThrowIfException<T>();
        }

        private static T ThrowIfException<T>(this IRestResponse response) where T : new() {
            if (response.ErrorException != null) {
                throw new ApplicationException("There was an an exception thrown during the request.",
                    response.ErrorException);
            }

            if (response.ResponseStatus != ResponseStatus.Completed) {
                throw response.ResponseStatus.ToWebException();
            }

            if ((int)response.StatusCode >= 400) {
                throw new ApiException(response.StatusCode);
            }

            var deserialize = new JsonDeserializer {
                RootElement = response.Request.RootElement,
                DateFormat = response.Request.DateFormat
            };
            return deserialize.Deserialize<T>(response);
        }
    }
}