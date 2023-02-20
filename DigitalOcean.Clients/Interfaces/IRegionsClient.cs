using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IRegionsClient {
    /// <summary>
    /// Retrieve all DigitalOcean regions
    /// </summary>
    Task<IEnumerable<Region>> GetAll();
}
