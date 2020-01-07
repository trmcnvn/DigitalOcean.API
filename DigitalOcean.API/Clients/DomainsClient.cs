using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DomainsClient : IDomainsClient {
        private readonly IConnection _connection;

        public DomainsClient(IConnection connection) {
            _connection = connection;
        }

        #region IDomainsClient Members

        /// <summary>
        /// Retrieve a list of all domains in your account
        /// </summary>
        public Task<IReadOnlyList<Domain>> GetAll() {
            return _connection.GetPaginated<Domain>("domains", null, "domains");
        }

        /// <summary>
        /// Create a new domain
        /// </summary>
        public Task<Domain> Create(Models.Requests.Domain domain) {
            return _connection.ExecuteRequest<Domain>("domains", null, domain, "domain", Method.POST);
        }

        /// <summary>
        /// Retrieve a specific domain
        /// </summary>
        public Task<Domain> Get(string domainName) {
            var parameters = new List<Parameter> {
                new Parameter("name", domainName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Domain>("domains/{name}", parameters, null, "domain");
        }

        /// <summary>
        /// Delete an existing domain
        /// </summary>
        public Task Delete(string domainName) {
            var parameters = new List<Parameter> {
                new Parameter("name", domainName, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("domains/{name}", parameters, null, Method.DELETE);
        }

        #endregion
    }
}
