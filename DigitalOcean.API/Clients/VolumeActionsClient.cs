using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class VolumeActionsClient : IVolumeActionsClient {
        private readonly IConnection _connection;

        public VolumeActionsClient(IConnection connection) {
            _connection = connection;
        }

        #region IVolumeActionsClient Members

        /// <summary>
        /// Attach a Block Storage volume to a Droplet
        /// </summary>
        public Task<Action> Attach(string volumeId, long dropletId, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter("id", volumeId, ParameterType.UrlSegment)
            };
            var body = new Models.Requests.VolumeAction {
                Type = "attach",
                DropletId = dropletId,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        /// <summary>
        /// Attach a Block Storage volume to a Droplet by name
        /// </summary>
        public Task<Action> AttachByName(string volumeName, long dropletId, string volumeRegion) {
            var body = new Models.Requests.VolumeAction {
                Type = "attach",
                DropletId = dropletId,
                VolumeName = volumeName,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        /// <summary>
        /// Detach a Block Storage volume to a Droplet
        /// </summary>
        public Task<Action> Detach(string volumeId, long dropletId, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter("id", volumeId, ParameterType.UrlSegment)
            };
            var body = new Models.Requests.VolumeAction {
                Type = "detach",
                DropletId = dropletId,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        /// <summary>
        /// Detach a Block Storage volume to a Droplet by name
        /// </summary>
        public Task<Action> DetachByName(string volumeName, long dropletId, string volumeRegion) {
            var body = new Models.Requests.VolumeAction {
                Type = "detach",
                DropletId = dropletId,
                VolumeName = volumeName,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        /// <summary>
        /// Retreive the status of a volume action
        /// </summary>
        public Task<Action> GetAction(string volumeId, long actionId) {
            var parameters = new List<Parameter> {
                new Parameter("id", volumeId, ParameterType.UrlSegment),
                new Parameter("actionId", actionId.ToString(), ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions/{actionId}", parameters, null, "action");
        }

        /// <summary>
        /// Retreive all actions that have been executed on a volume
        /// </summary>
        public Task<IReadOnlyList<Action>> GetActions(string volumeId) {
            var parameters = new List<Parameter> {
                new Parameter("id", volumeId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Action>("volumes/{id}/actions", parameters, "action");
        }

        /// <summary>
        /// Resize a Block Storage volume
        /// </summary>
        public Task<Action> Resize(string volumeId, int sizeGigabytes, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter("id", volumeId, ParameterType.UrlSegment)
            };
            var body = new Models.Requests.VolumeAction {
                Type = "resize",
                SizeGigabytes = sizeGigabytes,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        #endregion
    }
}
