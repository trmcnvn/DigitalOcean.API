using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
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
        public Task<Action> Reboot(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "reboot" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        public Task<Action> PowerCycle(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "power_cycle" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        public Task<Action> Shutdown(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "shutdown" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        public Task<Action> PowerOff(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "power_off" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        public Task<Action> PowerOn(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "power_on" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        public Task<Action> ResetPassword(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "password_reset" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Resize a droplet
        /// </summary>
        public Task<Action> Resize(long dropletId, string sizeSlug, bool resizeDisk) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "resize",
                Size = sizeSlug,
                Disk = resizeDisk
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        public Task<Action> Restore(long dropletId, object imageIdOrSlug) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "restore",
                Image = imageIdOrSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        public Task<Action> Rebuild(long dropletId, object imageIdOrSlug) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "rebuild",
                Image = imageIdOrSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        public Task<Action> Rename(long dropletId, string name) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "rename",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        public Task<Action> ChangeKernel(long dropletId, long kernelId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "change_kernel",
                KernelId = kernelId
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        public Task<Action> EnableIpv6(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "enable_ipv6" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Enable backups on a droplet
        /// </summary>
        public Task<Action> EnableBackups(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "enable_backups" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        public Task<Action> DisableBackups(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "disable_backups" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        public Task<Action> EnablePrivateNetworking(long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction { Type = "enable_private_networking" };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        public Task<Action> Snapshot(long dropletId, string name) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString())
            };
            var body = new Models.Requests.DropletAction {
                Type = "snapshot",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.Post);
        }

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        public Task<Action> GetDropletAction(long dropletId, long actionId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("dropletId", dropletId.ToString()),
                new UrlSegmentParameter ("actionId", actionId.ToString())
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
        public Task<IReadOnlyList<Action>> ActionOnTag(string tag, string actionType) {
            var parameters = new List<Parameter> {
                new QueryParameter("tag_name", tag)
            };
            var body = new Models.Requests.DropletAction { Type = actionType };
            return _connection.ExecuteRequest<List<Action>>("droplets/actions", parameters, body,
                "actions", Method.Post)
                .ToReadOnlyListAsync();
        }

        #endregion
    }
}
