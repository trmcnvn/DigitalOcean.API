using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using RestSharp;

namespace DigitalOcean.API.Helpers {
    public class Connection : IConnection {
        public IRestClient Client { get; private set; }
        public IRateLimit Rates { get; private set; }

        public Connection(IRestClient client) {
            Client = client;
        }

        public async Task<T> GetRequest<T>(string endpoint, IList<Parameter> parameters, string expectedRoot = null)
            where T : new() {
            var request = BuildRequest(endpoint, parameters);
            request.RootElement = expectedRoot;

            return await Client.ExecuteTask<T>(request).ConfigureAwait(false);
        }

        public async Task<IRestResponse> GetRequestRaw(string endpoint, IList<Parameter> parameters) {
            var request = BuildRequest(endpoint, parameters);
            return await Client.ExecuteTaskRaw(request).ConfigureAwait(false);
        }

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