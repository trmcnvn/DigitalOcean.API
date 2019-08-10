using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Models.Responses;
using RestSharp;
using RestSharp.Serialization.Json;

namespace DigitalOcean.API.Http {
    public class Connection : IConnection {
        public Connection(IRestClient client) {
            Client = client;
        }

        #region IConnection Members

        public IRestClient Client { get; private set; }
        public IRateLimit Rates { get; private set; }

        public async Task<IRestResponse> ExecuteRaw(string endpoint, IList<Parameter> parameters,
            object data = null, Method method = Method.GET) {
            var request = BuildRequest(endpoint, parameters);
            request.Method = method;

            if (data != null && method != Method.GET) {
                request.RequestFormat = DataFormat.Json;
                request.JsonSerializer = new JsonNetSerializer();
                request.AddBody(data);
            }

            return await Client.ExecuteTaskRaw(request).ConfigureAwait(false);
        }

        public async Task<T> ExecuteRequest<T>(string endpoint, IList<Parameter> parameters,
            object data = null, string expectedRoot = null, Method method = Method.GET)
            where T : new() {
            var request = BuildRequest(endpoint, parameters);
            request.RootElement = expectedRoot;
            request.Method = method;

            if (data != null && method != Method.GET) {
                request.RequestFormat = DataFormat.Json;
                request.JsonSerializer = new JsonNetSerializer();
                request.AddBody(data);
            }

            return await Client.ExecuteTask<T>(request).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetPaginated<T>(string endpoint, IList<Parameter> parameters,
            string expectedRoot = null) where T : new() {
            var first = await ExecuteRaw(endpoint, parameters).ConfigureAwait(false);

            // get page information
            var deserialize = new JsonDeserializer {
                RootElement = "links",
                DateFormat = first.Request.DateFormat
            };
            var page = deserialize.Deserialize<Pagination>(first);

            // get initial data
            deserialize.RootElement = expectedRoot;
            var data = deserialize.Deserialize<List<T>>(first);

            // loop until we are finished
            var allItems = new List<T>(data);
            while (page != null && page.Pages != null && !String.IsNullOrWhiteSpace(page.Pages.Next)) {
                endpoint = page.Pages.Next.Replace(DigitalOceanClient.DigitalOceanApiUrl, "");
                var iter = await ExecuteRaw(endpoint, null).ConfigureAwait(false);

                deserialize.RootElement = expectedRoot;
                allItems.AddRange(deserialize.Deserialize<List<T>>(iter));

                deserialize.RootElement = "links";
                page = deserialize.Deserialize<Pagination>(iter);
            }
            return new ReadOnlyCollection<T>(allItems);
        }

        #endregion

        private IRestRequest BuildRequest(string endpoint, IEnumerable<Parameter> parameters) {
            var request = new RestRequest(endpoint) {
                OnBeforeDeserialization = r => { Rates = new RateLimit(r.Headers); }
            };

            if (parameters == null) {
                return request;
            }
            foreach (var parameter in parameters) {
                request.AddParameter(parameter);
            }

            return request;
        }
    }
}
