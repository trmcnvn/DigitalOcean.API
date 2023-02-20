using DigitalOcean.Clients.Models.Responses;
using Action = DigitalOcean.Clients.Models.Responses.Action;

namespace DigitalOcean.Clients.Clients;

public class DropletsClient : IDropletsClient {
    private readonly IConnection _connection;

    public DropletsClient(IConnection connection) {
        _connection = connection;
    }

    #region IDropletsClient Members

    /// <summary>
    /// Retrieve all Droplets in your account.
    /// </summary>
    public Task<IEnumerable<Droplet>> GetAll() {
        return _connection.GetPaginated<Droplet>("droplets", null, "droplets");
    }

    /// <summary>
    /// Retrieve all Droplets in your account.
    /// </summary>
    public Task<IEnumerable<Droplet>> GetAllByTag(string tagName) {

        return _connection.GetPaginated<Droplet>("droplets", null, "droplets");
    }

    /// <summary>
    /// To retrieve a list of Droplets that are running on the same physical server.
    /// </summary>
    public Task<IEnumerable<Droplet>> GetAllNeighbors(long dropletId) {

        return _connection.GetPaginated<Droplet>("droplets/{id}/neighbors", null, "droplets");
    }

    /// <summary>
    /// Retrieve all kernels available to a Droplet.
    /// </summary>
    public Task<IEnumerable<Kernel>> GetKernels(long dropletId) {

        return _connection.GetPaginated<Kernel>("droplets/{id}/kernels", null, "kernels");
    }

    /// <summary>
    /// Retrieve all snapshots that have been created for a Droplet.
    /// </summary>
    public Task<IEnumerable<Image>> GetSnapshots(long dropletId) {
        return _connection.GetPaginated<Image>("droplets/{id}/snapshots", null, "snapshots");
    }

    /// <summary>
    /// Retrieve all backups that have been created for a Droplet.
    /// </summary>
    public Task<IEnumerable<Image>> GetBackups(long dropletId) {
        return _connection.GetPaginated<Image>("droplets/{id}/backups", null, "backups");
    }

    /// <summary>
    /// Retrieve all actions that have been executed on a Droplet.
    /// </summary>
    public Task<IEnumerable<Action>> GetActions(long dropletId) {
        return _connection.GetPaginated<Action>("droplets/{id}/actions", null, "actions");
    }

    /// <summary>
    /// Create a new Droplet
    /// </summary>
    public Task<Droplet> Create(DigitalOcean.Clients.Models.Requests.Droplet droplet) {
        return _connection.ExecuteRequest<Droplet>("droplets", null, droplet, "droplet", HttpMethod.Post);
    }

    /// <summary>
    /// To create multiple Droplets.
    /// A Droplet will be created for each name you send using the associated information.
    /// Up to ten Droplets may be created at a time.
    /// </summary>
    public async Task<IEnumerable<Droplet>> Create(DigitalOcean.Clients.Models.Requests.Droplets droplets) {
        return await _connection.ExecuteRequest<List<Droplet>>("droplets", null, droplets, "droplets", HttpMethod.Post);
    }

    /// <summary>
    /// Retrieve an existing Droplet
    /// </summary>
    public Task<Droplet> Get(long dropletId) {
        return _connection.ExecuteRequest<Droplet>("droplets/{id}", null, null, "droplet");
    }

    /// <summary>
    /// Delete an existing Droplet
    /// </summary>
    public Task Delete(long dropletId) {
        return _connection.ExecuteRaw("droplets/{id}", null, null, HttpMethod.Delete);
    }

    /// <summary>
    /// Delete existing droplets by tag
    /// </summary>
    public Task DeleteByTag(string tagName) {
        return _connection.ExecuteRaw("droplets", null, null, HttpMethod.Delete);
    }

    /// <summary>
    /// To retrieve a list of all Droplets that are co-located on the same physical hardware.
    /// This will be set to an array of arrays. Each array will contain a set of Droplet IDs for Droplets that share a physical server.
    /// An empty array indicates that all Droplets associated with your account are located on separate physical hardware.
    /// </summary>
    public Task<IEnumerable<List<long>>> ListDropletNeighborIds() {
        return _connection.GetPaginated<List<long>>("reports/droplet_neighbors_ids", null, "neighbor_ids");
    }

    #endregion
}
