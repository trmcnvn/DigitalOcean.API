using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IDomainsClient {
    /// <summary>
    /// Retrieve a list of all domains in your account
    /// </summary>
    Task<IEnumerable<Domain>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new domain
    /// </summary>
    Task<Domain> CreateAsync(DigitalOcean.Clients.Models.Requests.Domain domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve a specific domain
    /// </summary>
    Task<Domain> GetAsync(string domainName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete an existing domain
    /// </summary>
    Task DeleteAsync(string domainName, CancellationToken cancellationToken = default);
}
