using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDropletsClient {
        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAll();

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName);

        /// <summary>
        /// To retrieve a list of Droplets that are running on the same physical server.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAllNeighbors(int dropletId);

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        Task<IReadOnlyList<Kernel>> GetKernels(int dropletId);

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetSnapshots(int dropletId);

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetBackups(int dropletId);

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        Task<IReadOnlyList<Action>> GetActions(int dropletId);

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        Task<Droplet> Create(Models.Requests.Droplet droplet);

        /// <summary>
        /// To create multiple Droplets.
        /// A Droplet will be created for each name you send using the associated information.
        /// Up to ten Droplets may be created at a time.
        /// </summary>
        Task<IReadOnlyList<Droplet>> Create(Models.Requests.Droplets droplets);

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        Task<Droplet> Get(int dropletId);

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        Task Delete(int dropletId);

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        Task DeleteByTag(string tagName);

        /// <summary>
        /// To retrieve a list of any Droplets that are running on the same physical hardware.
        /// </summary>
        Task<IReadOnlyList<Droplet>> ListDropletNeighbors();
    }
}
