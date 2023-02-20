using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ICdnEndpointsClient {
    /// <summary>
    /// To list all of the CDN endpoints available on your account.
    /// </summary>
    Task<IEnumerable<CdnEndpoint>> GetAll();

    /// <summary>
    /// To show information about an existing CDN endpoint.
    /// </summary>
    Task<CdnEndpoint> Get(string endpointId);

    /// <summary>
    /// To create a new CDN endpoint.
    /// The Origin attribute must be set to the fully qualified domain name (FQDN) of a DigitalOcean Space.
    /// </summary>
    Task<CdnEndpoint> Create(Models.Requests.CdnEndpoint endpoint);

    /// <summary>
    /// To update the TTL, certificate ID, or the FQDN of the custom subdomain for an existing CDN endpoint.
    /// </summary>
    Task<CdnEndpoint> Update(string endpointId, Models.Requests.UpdateCdnEndpoint updateEndpoint);

    /// <summary>
    /// To delete a specific CDN endpoint.
    /// </summary>
    Task Delete(string endpointId);

    /// <summary>
    /// To purge cached content from a CDN endpoint.
    /// A path may be for a single file or may contain a wildcard (*) to recursively purge all files under a directory.
    /// When only a wildcard is provided, all cached files will be purged.
    /// </summary>
    Task PurgeCache(string endpointId, Models.Requests.PurgeCdnFiles purgeFiles);
}
