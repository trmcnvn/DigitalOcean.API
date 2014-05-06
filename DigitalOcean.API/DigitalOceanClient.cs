using DigitalOcean.API.Requests;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient {
        public IDropletsClient Droplets { get; private set; }
        public IRegionsClient Regions { get; private set; }
        public IImagesClient Images { get; private set; }
        public ISshKeysClient SshKeys { get; private set; }
        public ISizesClient Sizes { get; private set; }
        public IDomainsClient Domains { get; private set; }
        public IEventsClient Events { get; private set; }

        public DigitalOceanClient(string clientId, string apiKey) {
            IRestClient restClient = new RestClient("https://api.digitalocean.com") {
                UserAgent = "digitalocean-api-dotnet"
            };
            restClient.AddDefaultParameter("client_id", clientId);
            restClient.AddDefaultParameter("api_key", apiKey);

            Droplets = new DropletsClient(restClient);
            Regions = new RegionsClient(restClient);
            Images = new ImagesClient(restClient);
            SshKeys = new SshKeysClient(restClient);
            Sizes = new SizesClient(restClient);
            Domains = new DomainsClient(restClient);
            Events = new EventsClient(restClient);
        }
    }
}