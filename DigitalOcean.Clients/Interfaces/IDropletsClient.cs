using DigitalOcean.Clients.Models.Responses;
using Action = DigitalOcean.Clients.Models.Responses.Action;


namespace DigitalOcean.Clients.Interfaces;

public interface IDropletsClient {
    /// <summary>
    /// Retrieve all Droplets in your account.
    /// </summary>
    Task<IEnumerable<Droplet>> GetAll();

    /// <summary>
    /// Retrieve all Droplets in your account.
    /// </summary>
    Task<IEnumerable<Droplet>> GetAllByTag(string tagName);

    /// <summary>
    /// To retrieve a list of Droplets that are running on the same physical server.
    /// </summary>
    Task<IEnumerable<Droplet>> GetAllNeighbors(long dropletId);

    /// <summary>
    /// Retrieve all kernels available to a Droplet.
    /// </summary>
    Task<IEnumerable<Kernel>> GetKernels(long dropletId);

    /// <summary>
    /// Retrieve all snapshots that have been created for a Droplet.
    /// </summary>
    Task<IEnumerable<Image>> GetSnapshots(long dropletId);

    /// <summary>
    /// Retrieve all backups that have been created for a Droplet.
    /// </summary>
    Task<IEnumerable<Image>> GetBackups(long dropletId);

    /// <summary>
    /// Retrieve all actions that have been executed on a Droplet.
    /// </summary>
    Task<IEnumerable<Action>> GetActions(long dropletId);

    /// <summary>
    /// Create a new Droplet
    /// </summary>
    Task<Droplet> Create(Models.Requests.Droplet droplet);

    /// <summary>
    /// To create multiple Droplets.
    /// A Droplet will be created for each name you send using the associated information.
    /// Up to ten Droplets may be created at a time.
    /// </summary>
    Task<IEnumerable<Droplet>> Create(Models.Requests.Droplets droplets);

    /// <summary>
    /// Retrieve an existing Droplet
    /// </summary>
    Task<Droplet> Get(long dropletId);

    /// <summary>
    /// Delete an existing Droplet
    /// </summary>
    Task Delete(long dropletId);

    /// <summary>
    /// Delete existing droplets by tag
    /// </summary>
    Task DeleteByTag(string tagName);

    /// <summary>
    /// To retrieve a list of all Droplets that are co-located on the same physical hardware.
    /// This will be set to an array of arrays. Each array will contain a set of Droplet IDs for Droplets that share a physical server.
    /// An empty array indicates that all Droplets associated with your account are located on separate physical hardware.
    /// </summary>
    Task<IEnumerable<List<long>>> ListDropletNeighborIds();
}
