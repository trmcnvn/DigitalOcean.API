using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;

namespace DigitalOcean.API {
    public interface IDigitalOceanClient {
        IActionsClient Actions { get; }
        IDomainRecordsClient DomainRecords { get; }
        IDomainsClient Domains { get; }
        IDropletActionsClient DropletActions { get; }
        IDropletsClient Droplets { get; }
        IImageActionsClient ImageActions { get; }
        IImagesClient Images { get; }

        IRateLimit Rates { get; }
    }
}