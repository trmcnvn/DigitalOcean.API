using DigitalOcean.Clients.Models.Requests;
using DomainRecord = DigitalOcean.Clients.Models.Responses.DomainRecord;

namespace DigitalOcean.Clients.Interfaces;

public interface IDomainRecordsClient {
    /// <summary>
    /// Retrieve all records configured for a domain
    /// </summary>
    Task<IEnumerable<DomainRecord>> GetAllAsync(string domainName, CancellationToken token = default);

    /// <summary>
    /// Create a new record for a domain.
    /// </summary>
    Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record, CancellationToken token = default);

    /// <summary>
    /// Retrieve a specific domain record
    /// </summary>
    Task<DomainRecord> Get(string domainName, long recordId, CancellationToken token = default);

    /// <summary>
    /// Delete a record for a domain
    /// </summary>
    Task Delete(string domainName, long recordId, CancellationToken token = default);

    /// <summary>
    /// Update an existing record for a domain
    /// </summary>
    Task<DomainRecord> Update(string domainName, long recordId, Models.Requests.UpdateDomainRecord updateRecord, CancellationToken token = default);
}
