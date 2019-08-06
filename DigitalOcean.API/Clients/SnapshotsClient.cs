using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class SnapshotsClient : ISnapshotsClient {
        private readonly IConnection _connection;

        public SnapshotsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To list all of the snapshots available on your account.
        /// </summary>
        public Task<IReadOnlyList<Snapshot>> GetAll() {
            return _connection.GetPaginated<Snapshot>("snapshots", null, "snapshots");
        }

        /// <summary>
        /// To retrieve only snapshots based on Droplets.
        /// </summary>
        public Task<IReadOnlyList<Snapshot>> GetAllDroplet() {
            return _connection.GetPaginated<Snapshot>("snapshots?resource_type=droplet", null, "snapshots");
        }

        /// <summary>
        /// To retrieve only snapshots based on volumes.
        /// </summary>
        public Task<IReadOnlyList<Snapshot>> GetAllVolume() {
            return _connection.GetPaginated<Snapshot>("snapshots?resource_type=volume", null, "snapshots");
        }

        /// <summary>
        /// To retrieve information about a snapshot,
        /// </summary>
        public Task<Snapshot> Get(string snapshotId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "snapshot_id", Value = snapshotId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Snapshot>("snapshots/{snapshot_id}", parameters, null, "snapshot");
        }

        /// <summary>
        /// To delete a snapshot.
        /// </summary>
        public Task Delete(string snapshotId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "snapshot_id", Value = snapshotId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("snapshots/{snapshot_id}", parameters, null, Method.DELETE);
        }
    }
}
