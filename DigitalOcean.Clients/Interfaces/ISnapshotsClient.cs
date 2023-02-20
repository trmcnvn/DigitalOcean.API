using DigitalOcean.Clients.Models.Requests;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ISnapshotsClient {
    /// <summary>
    /// To list all of the snapshots available on your account.
    /// </summary>
    Task<IEnumerable<Snapshot>> GetAll(SnapshotType type = SnapshotType.All);

    /// <summary>
    /// To retrieve information about a snapshot,
    /// </summary>
    Task<Snapshot> Get(string snapshotId);

    /// <summary>
    /// To delete a snapshot.
    /// </summary>
    Task Delete(string snapshotId);
}
