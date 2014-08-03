using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DomainRecordsClient : Paginated, IDomainRecordsClient {
        private readonly IConnection _connection;

        public DomainRecordsClient(IConnection connection) : base(connection) {
            _connection = connection;
        }

        #region IDomainRecords Members

        /// <summary>
        /// Retrieve all records configured for a domain
        /// </summary>
        public Task<IReadOnlyList<DomainRecord>> GetAll(string domainName) {
            // docs don't say this is paginated? but it could be so run it thru that anyway
            var parameters = new List<Parameter> {
                new Parameter { Name = "name", Value = domainName, Type = ParameterType.UrlSegment }
            };
            return GetPaginated<DomainRecord>("domains/{name}/records", parameters, "domain_records");
        }

        /// <summary>
        /// Create a new record for a domain.
        /// </summary>
        public Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "name", Value = domainName, Type = ParameterType.UrlSegment }
            };
            return _connection.PostRequest<DomainRecord>("domains/{name}/records", parameters, record, "domain_record");
        }

        /// <summary>
        /// Retrieve a specific domain record
        /// </summary>
        public Task<DomainRecord> Get(string domainName, int recordId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "name", Value = domainName, Type = ParameterType.UrlSegment },
                new Parameter { Name = "id", Value = recordId, Type = ParameterType.UrlSegment }
            };
            return _connection.GetRequest<DomainRecord>("domains/{name}/records/{id}", parameters, "domain_record");
        }

        /// <summary>
        /// Delete a record for a domain
        /// </summary>
        public Task Delete(string domainName, int recordId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "name", Value = domainName, Type = ParameterType.UrlSegment },
                new Parameter { Name = "id", Value = recordId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("domains/{name}/records/{id}", parameters, Method.DELETE);
        }

        /// <summary>
        /// Update an existing record for a domain
        /// </summary>
        public Task<DomainRecord> Update(string domainName, int recordId, Models.Requests.DomainRecord newRecord) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "name", Value = domainName, Type = ParameterType.UrlSegment },
                new Parameter { Name = "id", Value = recordId, Type = ParameterType.UrlSegment }
            };
            return _connection.PostRequest<DomainRecord>("domains/{name}/records/{id}", parameters, newRecord,
                "domain_record", Method.PUT);
        }

        #endregion
    }
}