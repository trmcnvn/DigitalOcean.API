using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface ISnapshotsClient {
        /// <summary>
        /// To list all of the snapshots available on your account.
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAll();

        /// <summary>
        /// To retrieve only snapshots based on Droplets.
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllDroplet();

        /// <summary>
        /// To retrieve only snapshots based on volumes.
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllVolume();

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
