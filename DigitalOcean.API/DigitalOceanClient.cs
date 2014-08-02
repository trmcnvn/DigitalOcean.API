using DigitalOcean.API.Clients;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient {
        public static readonly string DigitalOceanApiUrl = "https://api.digitalocean.com/v2/";

        public IActionsClient Actions { get; private set; }

        public DigitalOceanClient(string token) {
            var client = new RestClient(DigitalOceanApiUrl) {
                UserAgent = "digitalocean-api-dotnet"
            };
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            var connection = new Connection(client);
            Actions = new ActionsClient(connection);
        }
    }
}