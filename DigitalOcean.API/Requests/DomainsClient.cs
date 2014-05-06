using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface IDomainsClient {
        /// <summary>
        /// This method returns all of your current domains
        /// </summary>
        Task<Domains> GetDomains();

        /// <summary>
        /// This method creates a new domain name with an A record
        /// </summary>
        /// <param name="name">name of the domain</param>
        /// <param name="ipAddress">ip address for the domains initial A record</param>
        Task<NewDomain> AddDomain(string name, string ipAddress);

        /// <summary>
        /// This method returns the specified domain
        /// </summary>
        /// <param name="domainId">id of the domain to return</param>
        Task<Domain> GetDomain(int domainId);

        /// <summary>
        /// This method deletes the specified domain
        /// </summary>
        /// <param name="domainId">id of the domain to destroy</param>
        Task<Status> DestroyDomain(int domainId);

        /// <summary>
        /// This method returns all of your current domain records
        /// </summary>
        /// <param name="domainId">id of the domain to get records for</param>
        Task<DomainRecords> GetDomainRecords(int domainId);

        /// <summary>
        /// This method creates a new domain record for a domain
        /// </summary>
        /// <param name="domainId">id of the domain to create the record for</param>
        /// <param name="recordType">type of record you want to create. 'A', 'CNAME', 'NS', 'TXT', 'MX', or 'SRV'</param>
        /// <param name="data">value of the record</param>
        /// <param name="name">required for 'A', 'CNAME', 'TXT', and 'SRV' records</param>
        /// <param name="priority">required for 'SRV', and 'MX' records</param>
        /// <param name="port">required for 'SRV' records</param>
        /// <param name="weight">required for 'SRV' records</param>
        Task<NewDomainRecord> AddDomainRecord(int domainId, string recordType, string data, string name = "",
            int priority = 0, int port = 0, int weight = 0);

        /// <summary>
        /// This method returns the specified domain record.
        /// </summary>
        /// <param name="domainId">id of the domain for this record</param>
        /// <param name="recordId">id of the record to return</param>
        Task<DomainRecord> GetDomainRecord(int domainId, int recordId);

        /// <summary>
        /// This method edits an existing domain record
        /// </summary>
        /// <param name="domainId">id of the domain to create the record for</param>
        /// <param name="recordId">id of the record to update</param>
        /// <param name="recordType">type of record you want to create. 'A', 'CNAME', 'NS', 'TXT', 'MX', or 'SRV'</param>
        /// <param name="data">value of the record</param>
        /// <param name="name">required for 'A', 'CNAME', 'TXT', and 'SRV' records</param>
        /// <param name="priority">required for 'SRV', and 'MX' records</param>
        /// <param name="port">required for 'SRV' records</param>
        /// <param name="weight">required for 'SRV' records</param>
        Task<DomainRecord> EditDomainRecord(int domainId, int recordId, string recordType, string data, string name = "",
            int priority = 0, int port = 0, int weight = 0);

        /// <summary>
        /// This method deletes the specified domain record
        /// </summary>
        /// <param name="domainId">id of the domain this record belongs to</param>
        /// <param name="recordId">id of the record to destroy</param>
        Task<Status> DestroyDomainRecord(int domainId, int recordId);
    }

    public class DomainsClient : Request, IDomainsClient {
        public DomainsClient(IRestClient restClient) : base(restClient) {}

        #region IDomainsClient Members

        public async Task<Domains> GetDomains() {
            var req = new RestRequest("domains");
            var ret = await RestClient.ExecuteTask<Domains>(req);
            return ret.Data;
        }

        public async Task<NewDomain> AddDomain(string name, string ipAddress) {
            var req = new RestRequest("domains/new");
            req.AddParameter("name", name);
            req.AddParameter("ip_address", ipAddress);
            var ret = await RestClient.ExecuteTask<NewDomain>(req);
            return ret.Data;
        }

        public async Task<Domain> GetDomain(int domainId) {
            var req = new RestRequest("domains/{id}");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Domain>(req);
            return ret.Data;
        }

        public async Task<Status> DestroyDomain(int domainId) {
            var req = new RestRequest("domains/{id}/destroy");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Status>(req);
            return ret.Data;
        }

        public async Task<DomainRecords> GetDomainRecords(int domainId) {
            var req = new RestRequest("domains/{id}/records");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<DomainRecords>(req);
            return ret.Data;
        }

        public async Task<NewDomainRecord> AddDomainRecord(int domainId, string recordType, string data,
            string name = "", int priority = 0, int port = 0,
            int weight = 0) {
            var req = new RestRequest("domains/{id}/records/new");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<NewDomainRecord>(req);
            return ret.Data;
        }

        public async Task<DomainRecord> GetDomainRecord(int domainId, int recordId) {
            var req = new RestRequest("domains/{id}/records/{recId}");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            req.AddParameter("recId", recordId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<DomainRecord>(req);
            return ret.Data;
        }

        public async Task<DomainRecord> EditDomainRecord(int domainId, int recordId, string recordType, string data,
            string name = "", int priority = 0,
            int port = 0, int weight = 0) {
            var req = new RestRequest("domains/{id}/records/{recId}/edit");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            req.AddParameter("recId", recordId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<DomainRecord>(req);
            return ret.Data;
        }

        public async Task<Status> DestroyDomainRecord(int domainId, int recordId) {
            var req = new RestRequest("domains/{id}/records/{recId}/destroy");
            req.AddParameter("id", domainId, ParameterType.UrlSegment);
            req.AddParameter("recId", recordId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Status>(req);
            return ret.Data;
        }

        #endregion
    }
}