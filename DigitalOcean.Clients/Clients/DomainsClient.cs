using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class DomainsClient : IDomainsClient {
    private readonly IConnection _connection;

    public DomainsClient(IConnection connection) {
        _connection = connection;
    }

    #region IDomainsClient Members

    /// <summary>
    /// Retrieve a list of all domains in your account
    /// </summary>
    public Task<IEnumerable<Domain>> GetAllAsync(CancellationToken token = default) {
        return _connection.GetPaginated<Domain>("domains", null, "domains", token);
    }

    /// <summary>
    /// Create a new domain
    /// </summary>
    public Task<Domain> CreateAsync(Models.Requests.Domain domain, CancellationToken token = default) {
        return _connection.ExecuteRequest<Domain>("domains", null, domain, "domain", HttpMethod.Post, token);
    }

    /// <summary>
    /// Retrieve a specific domain
    /// </summary>
    public Task<Domain> GetAsync(string domainName, CancellationToken token = default) {
        return _connection.ExecuteRequest<Domain>($"domains/{domainName}", null, expectedRoot: "domain", token: token);
    }

    /// <summary>
    /// Delete an existing domain
    /// </summary>
    public Task DeleteAsync(string domainName, CancellationToken token = default) {
        return _connection.ExecuteRaw($"domains/{domainName}", null, null, HttpMethod.Delete, token);
    }

    #endregion
}
