using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IVolumesClient {
        /// <summary>
        /// Retreive all Block Storage volumes on your account
        /// </summary>
        Task<IReadOnlyList<Volume>> GetAll();

        /// <summary>
        /// Create a new Block Storage volume
        /// </summary>
        Task<Volume> Create(Models.Requests.Volume volume);

        /// <summary>
        /// Retreive an individual Block Storage volume
        /// </summary>
        Task<Volume> Get(string volumeId);

        /// <summary>
        /// Retreive an individual Block Storage volume by name and region
        /// </summary>
        Task<IReadOnlyList<Volume>> GetByName(string name, string region);

        /// <summary>
        /// Retreive all snapshots created from a Block Storage volume
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetSnapshots(string volumeId);

        /// <summary>
        /// Create a new Snapshot from this Block Storage volume
        /// </summary>
        Task<Snapshot> CreateSnapshot(string volumeId, Models.Requests.VolumeSnapshot snapshot);

        /// <summary>
        /// Delete a Block Storage volume
        /// </summary>
        Task Delete(string volumeId);

        /// <summary>
        /// Delete a Block Storage volume by name and region
        /// </summary>
        Task DeleteByName(string name, string region);
    }
}
