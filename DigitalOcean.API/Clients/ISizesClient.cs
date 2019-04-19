using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface ISizesClient {
        /// <summary>
        /// Retrieve all DigitalOcean Droplet Sizes
        /// </summary>
        Task<IReadOnlyList<Size>> GetAll();
    }
}
