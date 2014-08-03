using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using RestSharp;

namespace DigitalOcean.API.Helpers {
    public class Connection : IConnection {
        public Connection(IRestClient client) {
            Client = client;
        }

        #region IConnection Members

        public IRestClient Client { get; private set; }
        public IRateLimit Rates { get; private set; }

        public async Task<T> GetRequest<T>(string endpoint, IList<Parameter> parameters, string expectedRoot = null)
            where T : new() {
            var request = BuildRequest(endpoint, parameters);
            request.RootElement = expectedRoot;

            return await Client.ExecuteTask<T>(request).ConfigureAwait(false);
        }

        public async Task<IRestResponse> ExecuteRaw(string endpoint, IList<Parameter> parameters,
            Method method = Method.GET) {
            var request = BuildRequest(endpoint, parameters);
            request.Method = method;
            return await Client.ExecuteTaskRaw(request).ConfigureAwait(false);
        }

        public async Task<T> PostRequest<T>(string endpoint, IList<Parameter> parameters, object data,
            string expectedRoot = null, Method method = Method.POST) where T : new() {
            var request = BuildRequest(endpoint, parameters);
            request.RootElement = expectedRoot;
            request.Method = method;
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new JsonNetSerializer();
            request.AddBody(data);
            return await Client.ExecuteTask<T>(request).ConfigureAwait(false);
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