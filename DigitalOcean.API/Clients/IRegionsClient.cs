using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IRegionsClient {
        /// <summary>
        /// Retrieve all DigitalOcean regions
        /// </summary>
        Task<IReadOnlyList<Region>> GetAll();
    }
}