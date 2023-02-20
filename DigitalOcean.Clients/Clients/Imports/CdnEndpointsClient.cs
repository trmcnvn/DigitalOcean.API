using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients.Imports;

public class CdnEndpointsClient : ICdnEndpointsClient {
    private readonly IConnection _connection;

    public CdnEndpointsClient(IConnection connection) {
        _connection = connection;
    }

    /// <summary>
    /// To list all of the CDN endpoints available on your account.
    /// </summary>
    public Task<IEnumerable<CdnEndpoint>> GetAll() {
        return _connection.GetPaginated<CdnEndpoint>("cdn/endpoints", null, "endpoints");
    }

    /// <summary>
    /// To show information about an existing CDN endpoint.
    /// </summary>
    public Task<CdnEndpoint> Get(string endpointId) {
        string? parameters = null;  // {
        return _connection.ExecuteRequest<CdnEndpoint>("cdn/endpoints/{endpoint_id}", null, null, "endpoint");
    }

    /// <summary>
    /// To create a new CDN endpoint.
    /// The Origin attribute must be set to the fully qualified domain name (FQDN) of a DigitalOcean Space.
    /// </summary>
    public Task<CdnEndpoint> Create(DigitalOcean.Clients.Models.Requests.CdnEndpoint endpoint) {
        return _connection.ExecuteRequest<CdnEndpoint>("cdn/endpoints", null, endpoint, "endpoint", HttpMethod.Post);
    }

    /// <summary>
    /// To update the TTL, certificate ID, or the FQDN of the custom subdomain for an existing CDN endpoint.
    /// </summary>
    public Task<CdnEndpoint> Update(string endpointId, DigitalOcean.Clients.Models.Requests.UpdateCdnEndpoint updateEndpoint) {
        return _connection.ExecuteRequest<CdnEndpoint>($"cdn/endpoints/{endpointId}", null, updateEndpoint, "endpoint", HttpMethod.Put);
    }

    /// <summary>
    /// To delete a specific CDN endpoint.
    /// </summary>
    public Task Delete(string endpointId) {
        return _connection.ExecuteRaw("cdn/endpoints/{endpointId}", null, null, HttpMethod.Delete);
    }

    /// <summary>
    /// To purge cached content from a CDN endpoint.
    /// A path may be for a single file or may contain a wildcard (*) to recursively purge all files under a directory.
    /// When only a wildcard is provided, all cached files will be purged.
    /// </summary>
    public Task PurgeCache(string endpointId, DigitalOcean.Clients.Models.Requests.PurgeCdnFiles purgeFiles) {
        return _connection.ExecuteRaw("cdn/endpoints/{endpointId}/cache", null, purgeFiles, HttpMethod.Delete);
    }
}
