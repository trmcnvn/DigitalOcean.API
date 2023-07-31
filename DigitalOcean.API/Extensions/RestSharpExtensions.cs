using System;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using DigitalOcean.API.Models.Responses;
using RestSharp;
// using RestSharp.Serialization.Json;
using RestSharp.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json;
using DigitalOcean.API.Helpers;
using System.Net;

namespace DigitalOcean.API.Extensions {
    public static class RestSharpExtensions {
        public static async Task<T> ExecuteTask<T>(this IRestClient client, RestRequest request)
            where T : new() {
            var ret = await GetResponseContentAsync(client, request);
            return ret.ThrowIfException().Deserialize<T>();
        }

        public static async Task<RestResponse> ExecuteTaskRaw(this IRestClient client, RestRequest request) {
            var ret = await GetResponseContentAsync(client, request);
            request.OnBeforeDeserialization(ret);
            return ret.ThrowIfException();
        }

        public static Task<IReadOnlyList<byte>> ToByteArrayAsync(this Task<RestResponse> task) {
            return task.ContinueWith(t => (IReadOnlyList<byte>)new ReadOnlyCollection<byte>(t.Result?.RawBytes ?? new byte[] { }));
        }

        private static RestResponse ThrowIfException(this RestResponse response) {
            if (response.ErrorException != null) {
                throw new Exception("There was an an exception thrown during the request.",
                    response.ErrorException);
            }

            if (response.ResponseStatus != ResponseStatus.Completed) {
                throw new WebException(response.ErrorException.Message);
            }

            if ((int)response.StatusCode >= 400) {
                throw new ApiException(response.StatusCode, response.Deserialize<Error>());
            }

            return response;
        }

        private static Task<RestResponse> GetResponseContentAsync(IRestClient theClient, RestRequest theRequest) {
            return theClient.ExecuteAsync(theRequest);
        }

        public static T Deserialize<T>(this RestResponse response) {
            response.Request.OnBeforeDeserialization(response);
            return JsonDeserializationHelper.DeserializeWithRootElementName<T>(response.Content, response.Request.RootElement);
        }
    }
}
