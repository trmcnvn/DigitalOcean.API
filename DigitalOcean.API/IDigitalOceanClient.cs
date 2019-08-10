using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;

namespace DigitalOcean.API {
    public interface IDigitalOceanClient {
        IAccountClient Account { get; }
        IActionsClient Actions { get; }
        ICdnEndpointsClient CdnEndpoints { get; }
        ICertificatesClient Certificates { get; }
        IDomainRecordsClient DomainRecords { get; }
        IDomainsClient Domains { get; }
        IDropletActionsClient DropletActions { get; }
        IDropletsClient Droplets { get; }
        IFloatingIpActionsClient FloatingIpActions { get; }
        IFloatingIpsClient FloatingIps { get; }
        IImageActionsClient ImageActions { get; }
        IImagesClient Images { get; }
        IKeysClient Keys { get; }
        ILoadBalancerClient LoadBalancers { get; }
        IProjectsClient Projects { get; }
        IProjectResourcesClient ProjectResources { get; }
        IRegionsClient Regions { get; }
        ISizesClient Sizes { get; }
        ISnapshotsClient Snapshots { get; }
        ITagsClient Tags { get; }
        IVolumesClient Volumes { get; }
        IVolumeActionsClient VolumeActions { get; }

        IRateLimit Rates { get; }
    }
}
