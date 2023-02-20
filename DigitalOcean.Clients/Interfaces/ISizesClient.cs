using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ISizesClient {
    /// <summary>
    /// Retrieve all DigitalOcean Droplet Sizes
    /// </summary>
    Task<IEnumerable<Size>> GetAll();
}
