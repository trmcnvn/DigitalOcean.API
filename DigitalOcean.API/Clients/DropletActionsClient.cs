using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DropletActionsClient : IDropletActionsClient {
        private readonly IConnection _connection;

        public DropletActionsClient(IConnection connection) {
            _connection = connection;
        }

        #region IDropletActions Members

        /// <summary>
        /// Reboot a droplet
        /// </summary>
        public Task<Action> Reboot(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "reboot" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        public Task<Action> PowerCycle(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "power_cycle" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        public Task<Action> Shutdown(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "shutdown" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        public Task<Action> PowerOff(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "power_off" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        public Task<Action> PowerOn(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "power_on" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        public Task<Action> ResetPassword(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "password_reset" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Resize a droplet
        /// </summary>
        public Task<Action> Resize(int dropletId, string sizeSlug, bool resizeDisk) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "resize",
                SizeSlug = sizeSlug,
                Disk = resizeDisk
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        public Task<Action> Restore(int dropletId, object imageIdOrSlug) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "restore",
                ImageIdOrSlug = imageIdOrSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        public Task<Action> Rebuild(int dropletId, object imageIdOrSlug) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "rebuild",
                ImageIdOrSlug = imageIdOrSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        public Task<Action> Rename(int dropletId, string name) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "rename",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        public Task<Action> ChangeKernel(int dropletId, int kernelId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "change_kernel",
                KernelId = kernelId
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        public Task<Action> EnableIpv6(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "enable_ipv6" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Enable backups on a droplet
        /// </summary>
        public Task<Action> EnableBackups(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "enable_backups" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        public Task<Action> DisableBackups(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "disable_backups" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        public Task<Action> EnablePrivateNetworking(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = "enable_private_networking" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        public Task<Action> Snapshot(int dropletId, string name) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction {
                Type = "snapshot",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST);
        }

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        public Task<Action> GetDropletAction(int dropletId, int actionId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "actionId", Value = actionId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions/{actionId}", parameters,
                null, "action");
        }

        /// <summary>
        /// Some actions can be performed in bulk on tagged Droplets.
        /// The list of supported action types are:
        /// * power_cycle
        /// * power_on
        /// * power_off
        /// * shutdown
        /// * enable_private_networking
        /// * enable_ipv6
        /// * enable_backups
        /// * disable_backups
        /// * snapshot
        /// </summary>
        public Task<Action> ActionOnTag(string tag, string actionType) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "tag", Value = tag, Type = ParameterType.UrlSegment }
            };
            var body = new Models.Requests.DropletAction { Type = actionType };
            return _connection.ExecuteRequest<Action>("droplets/actions?tag_name={tag}", parameters, body,
                "action", Method.POST);
        }

        #endregion
    }
}
