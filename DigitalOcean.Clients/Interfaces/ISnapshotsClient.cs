using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface ISnapshotsClient {
        /// <summary>
        /// To list all of the snapshots available on your account.
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAll(SnapshotType type = SnapshotType.All);

        /// <summary>
        /// To retrieve information about a snapshot,
        /// </summary>
        Task<Snapshot> Get(string snapshotId);

        /// <summary>
        /// To delete a snapshot.
        /// </summary>
        Task Delete(string snapshotId);
    }
}
