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

        public Task<Action> Attach(string volumeId, int dropletId, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = volumeId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.VolumeAction {
                Type = "attach",
                DropletId = dropletId,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        public Task<Action> AttachByName(string volumeName, int dropletId, string volumeRegion) {
            var body = new Models.Requests.VolumeAction {
                Type = "attach",
                DropletId = dropletId,
                VolumeName = volumeName,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        public Task<Action> Detach(string volumeId, int dropletId, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = volumeId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.VolumeAction {
                Type = "detach",
                DropletId = dropletId,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        public Task<Action> DetachByName(string volumeName, int dropletId, string volumeRegion) {
            var body = new Models.Requests.VolumeAction {
                Type = "detach",
                DropletId = dropletId,
                VolumeName = volumeName,
                Region = volumeRegion
            };
            return _connection.ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        public Task<Action> GetAction(string volumeId, int actionId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = volumeId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "actionId", Value = actionId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Action>("volumes/{id}/actions/{actionId}", parameters, null, "action");
        }

        public Task<IReadOnlyList<Action>> GetActions(string volumeId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = volumeId, Type = ParameterType.UrlSegment }
            };
            return _connection.GetPaginated<Action>("volumes/{id}/actions", parameters, "action");
        }

        public Task<Action> Resize(string volumeId, int sizeGigabytes, string volumeRegion) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = volumeId, Type = ParameterType.UrlSegment }
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
