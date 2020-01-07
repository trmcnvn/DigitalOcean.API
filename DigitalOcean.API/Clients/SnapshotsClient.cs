using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
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
        public Task<IReadOnlyList<Snapshot>> GetAll(Models.Requests.SnapshotType type = SnapshotType.All) {
            var endpoint = "snapshots";
            switch (type) {
                case SnapshotType.All:
                    break;
                case SnapshotType.Droplet:
                    endpoint += "?resource_type=droplet";
                    break;
                case SnapshotType.Volume:
                    endpoint += "?resource_type=volume";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
            return _connection.GetPaginated<Snapshot>(endpoint, null, "snapshots");
        }

        /// <summary>
        /// To retrieve information about a snapshot,
        /// </summary>
        public Task<Snapshot> Get(string snapshotId) {
            var parameters = new List<Parameter> {
                new Parameter("snapshot_id", snapshotId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Snapshot>("snapshots/{snapshot_id}", parameters, null, "snapshot");
        }

        /// <summary>
        /// To delete a snapshot.
        /// </summary>
        public Task Delete(string snapshotId) {
            var parameters = new List<Parameter> {
                new Parameter("snapshot_id", snapshotId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("snapshots/{snapshot_id}", parameters, null, Method.DELETE);
        }
    }
}
