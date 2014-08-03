using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDomainRecordsClient {
        /// <summary>
        /// Retrieve all records configured for a domain
        /// </summary>
        Task<IReadOnlyList<DomainRecord>> GetAll(string domainName);

        /// <summary>
        /// Create a new record for a domain.
        /// </summary>
        Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record);

        /// <summary>
        /// Retrieve a specific domain record
        /// </summary>
        Task<DomainRecord> Get(string domainName, int recordId);

        /// <summary>
        /// Delete a record for a domain
        /// </summary>
        Task Delete(string domainName, int recordId);

        /// <summary>
        /// Update an existing record for a domain
        /// </summary>
        Task<DomainRecord> Update(string domainName, int recordId, Models.Requests.DomainRecord newRecord);
    }
}