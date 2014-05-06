using DigitalOcean.API.Requests;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient {
        public IDropletsClient Droplets { get; private set; }

        public DigitalOceanClient(string clientId, string apiKey) {
            IRestClient restClient = new RestClient("https://api.digitalocean.com") {
                UserAgent = "digitalocean-api-dotnet"
            };
            restClient.AddDefaultParameter("client_id", clientId);
            restClient.AddDefaultParameter("api_key", apiKey);

            Droplets = new DropletsClientClient(restClient);
        }
    }
}