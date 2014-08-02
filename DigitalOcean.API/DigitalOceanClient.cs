using System;
using DigitalOcean.API.Clients;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient {
        public static readonly Uri DigitalOceanApiUrl = new Uri("https://api.digitalocean.com/v2/");

        public IActionsClient Actions { get; private set; }

        public DigitalOceanClient(string token) {
            var client = new RestClient(DigitalOceanApiUrl.ToString()) {
                UserAgent = "digitalocean-api-dotnet"
            };
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            Actions = new ActionsClient(client);
        }
    }
}