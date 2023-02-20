using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IVolumesClient {
    /// <summary>
    /// Retreive all Block Storage volumes on your account
    /// </summary>
    Task<IEnumerable<Volume>> GetAll();

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
    Task<IEnumerable<Volume>> GetByName(string name, string region);

    /// <summary>
    /// Retreive all snapshots created from a Block Storage volume
    /// </summary>
    Task<IEnumerable<Snapshot>> GetSnapshots(string volumeId);

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
