using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class CdnEndpointsClient : ICdnEndpointsClient {
        private readonly IConnection _connection;

        public CdnEndpointsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To list all of the CDN endpoints available on your account.
        /// </summary>
        public Task<IReadOnlyList<CdnEndpoint>> GetAll() {
            return _connection.GetPaginated<CdnEndpoint>("cdn/endpoints", null, "endpoints");
        }

        /// <summary>
        /// To show information about an existing CDN endpoint.
        /// </summary>
        public Task<CdnEndpoint> Get(string endpointId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("endpoint_id", endpointId)
            };
            return _connection.ExecuteRequest<CdnEndpoint>("cdn/endpoints/{endpoint_id}", parameters, null, "endpoint");
        }

        /// <summary>
        /// To create a new CDN endpoint.
        /// The Origin attribute must be set to the fully qualified domain name (FQDN) of a DigitalOcean Space.
        /// </summary>
        public Task<CdnEndpoint> Create(Models.Requests.CdnEndpoint endpoint) {
            return _connection.ExecuteRequest<CdnEndpoint>("cdn/endpoints", null, endpoint, "endpoint", Method.Post);
        }

        /// <summary>
        /// To update the TTL, certificate ID, or the FQDN of the custom subdomain for an existing CDN endpoint.
        /// </summary>
        public Task<CdnEndpoint> Update(string endpointId, Models.Requests.UpdateCdnEndpoint updateEndpoint) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("endpoint_id", endpointId)
            };
            return _connection.ExecuteRequest<CdnEndpoint>("cdn/endpoints/{endpoint_id}", parameters, updateEndpoint, "endpoint", Method.Put);
        }

        /// <summary>
        /// To delete a specific CDN endpoint.
        /// </summary>
        public Task Delete(string endpointId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("endpoint_id", endpointId)
            };
            return _connection.ExecuteRaw("cdn/endpoints/{endpoint_id}", parameters, null, Method.Delete);
        }

        /// <summary>
        /// To purge cached content from a CDN endpoint.
        /// A path may be for a single file or may contain a wildcard (*) to recursively purge all files under a directory.
        /// When only a wildcard is provided, all cached files will be purged.
        /// </summary>
        public Task PurgeCache(string endpointId, Models.Requests.PurgeCdnFiles purgeFiles) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("endpoint_id", endpointId)
            };
            return _connection.ExecuteRaw("cdn/endpoints/{endpoint_id}/cache", parameters, purgeFiles, Method.Delete);
        }
    }
}
