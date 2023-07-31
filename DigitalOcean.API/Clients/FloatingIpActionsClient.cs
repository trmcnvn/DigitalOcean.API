using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class FloatingIpActionsClient : IFloatingIpActionsClient {
        private readonly IConnection _connection;

        public FloatingIpActionsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// Assign a Floating IP to a Droplet
        /// </summary>
        public Task<Action> Assign(string ipAddress, long dropletId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("ip", ipAddress)
            };
            var body = new Models.Requests.FloatingIpAction {
                Type = "assign",
                DropletId = dropletId
            };
            return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions", parameters, body, "action", Method.Post);
        }

        /// <summary>
        /// Retreive the status of a Floating IP action
        /// </summary>
        public Task<Action> GetAction(string ipAddress, long actionId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("ip", ipAddress),
                new UrlSegmentParameter ("actionId", actionId.ToString())
            };
            return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions/{actionId}", parameters, null, "action");
        }

        /// <summary>
        /// Retrieve all actions that have been executed on a Floating IP
        /// </summary>
        public Task<IReadOnlyList<Action>> GetActions(string ipAddress) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("ip", ipAddress)
            };
            return _connection.GetPaginated<Action>("floating_ips/{ip}/actions", parameters, "actions");
        }

        /// <summary>
        /// Unassign a Floating IP
        /// </summary>
        public Task<Action> Unassign(string ipAddress) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("ip", ipAddress)
            };
            var body = new Models.Requests.FloatingIpAction {
                Type = "unassign"
            };
            return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions", parameters, body, "action", Method.Post);
        }
    }
}
