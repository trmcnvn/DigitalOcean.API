using DigitalOcean.Clients.Models.Requests;
using DomainRecord = DigitalOcean.Clients.Models.Responses.DomainRecord;

namespace DigitalOcean.Clients.Clients;

public class DomainRecordsClient : IDomainRecordsClient {
    private readonly IConnection _connection;

    public DomainRecordsClient(IConnection connection) {
        _connection = connection;
    }

    #region IDomainRecordsClient Members

    /// <summary>
    /// Retrieve all records configured for a domain
    /// </summary>
    public Task<IEnumerable<DomainRecord>> GetAllAsync(string domainName, CancellationToken token = default) {
        // docs don't say this is paginated? but it could be so run it thru that anyway
        return _connection.GetPaginated<DomainRecord>($"domains/{domainName}/records", null, "domain_records", token);
    }

    /// <summary>
    /// Create a new record for a domain.
    /// </summary>
    public Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record, CancellationToken token = default) {
        return _connection.ExecuteRequest<DomainRecord>($"domains/{domainName}/records", null, record,
            "domain_record", HttpMethod.Post, token);
    }

    /// <summary>
    /// Retrieve a specific domain record
    /// </summary>
    public Task<DomainRecord> Get(string domainName, long recordId, CancellationToken token) {
        return _connection.ExecuteRequest<DomainRecord>($"domains/{domainName}/records/{recordId}", null, null, "domain_record", token: token);
    }

    /// <summary>
    /// Delete a record for a domain
    /// </summary>
    public Task Delete(string domainName, long recordId, CancellationToken token) {
        return _connection.ExecuteRaw($"domains/{domainName}/records/{recordId}", null, null, HttpMethod.Delete, token);
    }

    /// <summary>
    /// Update an existing record for a domain
    /// </summary>
    public Task<DomainRecord> Update(string domainName, long recordId, UpdateDomainRecord updateRecord, CancellationToken token) {
        return _connection.ExecuteRequest<DomainRecord>($"domains/{domainName}/records/{recordId}", null, updateRecord,
            "domain_record", HttpMethod.Put, token);
    }

    #endregion
}
