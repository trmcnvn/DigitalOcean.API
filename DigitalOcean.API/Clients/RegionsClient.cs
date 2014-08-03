using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public class RegionsClient : IRegionsClient {
        private readonly IConnection _connection;

        public RegionsClient(IConnection connection) {
            _connection = connection;
        }

        #region IRegionsClient Members

        /// <summary>
        /// Retrieve all DigitalOcean regions
        /// </summary>
        public Task<IReadOnlyList<Region>> GetAll() {
            return _connection.GetPaginated<Region>("regions", null, "regions");
        }

        #endregion
    }
}