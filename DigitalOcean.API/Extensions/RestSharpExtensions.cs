using System;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using DigitalOcean.API.Models.Responses;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace DigitalOcean.API.Extensions {
    public static class RestSharpExtensions {
        public static async Task<T> ExecuteTask<T>(this IRestClient client, IRestRequest request)
            where T : new() {
            var ret = await GetResponseContentAsync(client, request);
            return ret.ThrowIfException().Deserialize<T>();
        }

        public static async Task<IRestResponse> ExecuteTaskRaw(this IRestClient client, IRestRequest request) {
            var ret = await GetResponseContentAsync(client, request);
            request.OnBeforeDeserialization(ret);
            return ret.ThrowIfException();
        }

        public static Task<IReadOnlyList<byte>> ToByteArrayAsync(this Task<IRestResponse> task) {
            return task.ContinueWith(t => (IReadOnlyList<byte>)new ReadOnlyCollection<byte>(t.Result?.RawBytes ?? new byte[] { }));
        }

        private static IRestResponse ThrowIfException(this IRestResponse response) {
            if (response.ErrorException != null) {
                throw new Exception("There was an an exception thrown during the request.",
                    response.ErrorException);
            }

            if (response.ResponseStatus != ResponseStatus.Completed) {
                throw response.ResponseStatus.ToWebException();
            }

            if ((int)response.StatusCode >= 400) {
                throw new ApiException(response.StatusCode, response.Deserialize<Error>());
            }

            return response;
        }

        private static Task<IRestResponse> GetResponseContentAsync(IRestClient theClient, IRestRequest theRequest) {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static T Deserialize<T>(this IRestResponse response) {
            response.Request.OnBeforeDeserialization(response);
            var deserialize = new JsonDeserializer {
                RootElement = response.Request.RootElement,
                DateFormat = response.Request.DateFormat
            };
            return deserialize.Deserialize<T>(response);
        }
    }
}
