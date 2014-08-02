using DigitalOcean.API.Clients;
using DigitalOcean.API.Helpers;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient {
        public static readonly string DigitalOceanApiUrl = "https://api.digitalocean.com/v2/";
        private readonly IConnection _connection;

        public IActionsClient Actions { get; private set; }

        public IRateLimit Rates {
            get { return _connection.Rates; }
        }

        public DigitalOceanClient(string token) {
            var client = new RestClient(DigitalOceanApiUrl) {
                UserAgent = "digitalocean-api-dotnet"
            };
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            _connection = new Connection(client);
            Actions = new ActionsClient(_connection);
        }
    }
}