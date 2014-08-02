using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class Connection {
        public IRestClient Client { get; private set; }

        public Connection(IRestClient client) {
            Client = client;
        }

        public async Task<T> GetRequest<T>(string endpoint, IList<Parameter> parameters, string expectedRoot = null)
            where T : new() {
            var request = new RestRequest(endpoint);
            if (parameters != null) {
                foreach (var parameter in parameters) {
                    request.AddParameter(parameter);
                }
            }
            request.RootElement = expectedRoot;

            return await Client.ExecuteTask<T>(request).ConfigureAwait(false);
        }

        public async Task<IRestResponse> GetRequestRaw(string endpoint, IList<Parameter> parameters) {
            var request = new RestRequest(endpoint);

            if (parameters != null) {
                foreach (var parameter in parameters) {
                    request.AddParameter(parameter);
                }
            }

            return await Client.ExecuteTaskAsync(request).ConfigureAwait(false);
        }
    }
}