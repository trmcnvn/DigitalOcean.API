using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using RestSharp;

namespace DigitalOcean.API {
    public class DigitalOceanClient : IDigitalOceanClient {
        public static readonly string DigitalOceanApiUrl = "https://api.digitalocean.com/v2/";
        private readonly IConnection _connection;

        public DigitalOceanClient(string token) {
            var client = new RestClient(DigitalOceanApiUrl) {
                UserAgent = "digitalocean-api-dotnet"
            };
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            _connection = new Connection(client);

            Account = new AccountClient(_connection);
            Actions = new ActionsClient(_connection);
            DomainRecords = new DomainRecordsClient(_connection);
            Domains = new DomainsClient(_connection);
            DropletActions = new DropletActionsClient(_connection);
            Droplets = new DropletsClient(_connection);
            ImageActions = new ImageActionsClient(_connection);
            Images = new ImagesClient(_connection);
			LoadBalancers = new LoadBalancerClient(_connection);
            Projects = new ProjectsClient(_connection);
			ProjectResources = new ProjectResourcesClient(_connection);
			Keys = new KeysClient(_connection);
            Regions = new RegionsClient(_connection);
            Sizes = new SizesClient(_connection);
            Snapshots = new SnapshotsClient(_connection);
            Tags = new TagsClient(_connection);
        }

        #region IDigitalOceanClient Members

        public IRateLimit Rates {
            get { return _connection.Rates; }
        }

        public IAccountClient Account { get; private set; }
        public IActionsClient Actions { get; private set; }
        public IDomainRecordsClient DomainRecords { get; private set; }
        public IDomainsClient Domains { get; private set; }
        public IDropletActionsClient DropletActions { get; private set; }
        public IDropletsClient Droplets { get; private set; }
        public IImageActionsClient ImageActions { get; private set; }
        public IImagesClient Images { get; private set; }
        public IKeysClient Keys { get; private set; }
		public ILoadBalancerClient LoadBalancers { get; private set; }
        public IProjectsClient Projects { get; private set; }
        public IProjectResourcesClient ProjectResources { get; private set; }
		public IRegionsClient Regions { get; private set; }
        public ISizesClient Sizes { get; private set; }
        public ISnapshotsClient Snapshots { get; private set; }
        public ITagsClient Tags { get; private set; }

		#endregion
	}
}
