using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IReservedIpsClient {
    /// <summary>
    /// Retreive all Floating IPs available on your account
    /// </summary>
    Task<IEnumerable<FloatingIp>> GetAll();

    /// <summary>
    /// A Floating IP must be either assigned to a Droplet or reserved to a region
    /// </summary>
    Task<FloatingIp> Create(Models.Requests.FloatingIp floatingIp);

    /// <summary>
    /// Retreive a individual Floating IP
    /// </summary>
    Task<FloatingIp> Get(string ipAddress);

    /// <summary>
    /// Delete a Floating IP
    /// </summary>
    Task Delete(string ipAddress);
}
