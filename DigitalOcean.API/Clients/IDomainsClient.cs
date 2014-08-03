using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDomainsClient {
        /// <summary>
        /// Retrieve a list of all domains in your account
        /// </summary>
        Task<IReadOnlyList<Domain>> GetAll();

        /// <summary>
        /// Create a new domain
        /// </summary>
        Task<Domain> Create(Models.Requests.Domain domain);

        /// <summary>
        /// Retrieve a specific domain
        /// </summary>
        Task<Domain> Get(string domainName);

        /// <summary>
        /// Delete an existing domain
        /// </summary>
        Task Delete(string domainName);
    }
}