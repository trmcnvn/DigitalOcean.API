using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class FirewallsClient : IFirewallsClient {
        private readonly IConnection _connection;

        public FirewallsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// Assign a Droplet to a Cloud Firewall
        /// </summary>
        public Task AddDroplets(string firewallId, Models.Requests.FirewallDroplets droplets) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/droplets", parameters, droplets, Method.POST);
        }

        /// <summary>
        /// Add additional access rules to a Cloud Firewall
        /// </summary>
        public Task AddRules(string firewallId, Models.Requests.FirewallRules rules) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/rules", parameters, rules, Method.POST);
        }

        /// <summary>
        /// Assign a Tag representing a group of Droplets to a Cloud Firewall
        /// </summary>
        public Task AddTags(string firewallId, Models.Requests.FirewallTags tags) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/tags", parameters, tags, Method.POST);
        }

        /// <summary>
        /// Create a new Cloud Firewall
        /// </summary>
        public Task<Firewall> Create(Models.Requests.Firewall firewall) {
            return _connection.ExecuteRequest<Firewall>("firewalls", null, firewall, "firewall", Method.POST);
        }

        /// <summary>
        /// Delete a Cloud Firewall
        /// </summary>
        public Task Delete(string firewallId) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Retreive an individual Cloud Firewall
        /// </summary>
        public Task<Firewall> Get(string firewallId) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Firewall>("firewalls/{id}", parameters, null, "firewall");
        }

        /// <summary>
        /// Retreive all Cloud Firewalls available on your account
        /// </summary>
        public Task<IReadOnlyList<Firewall>> GetAll() {
            return _connection.GetPaginated<Firewall>("firewalls", null, "firewalls");
        }

        /// <summary>
        /// Remove a Droplet from a Cloud Firewall,
        /// </summary>
        public Task RemoveDroplets(string firewallId, Models.Requests.FirewallDroplets droplets) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/droplets", parameters, droplets, Method.DELETE);
        }

        /// <summary>
        /// Remove access rules from a Cloud Firewall
        /// </summary>
        public Task RemoveRules(string firewallId, Models.Requests.FirewallRules rules) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/rules", parameters, rules, Method.DELETE);
        }

        /// <summary>
        /// Remove a Tag representing a group of Droplets from a Cloud Firewall
        /// </summary>
        public Task RemoveTags(string firewallId, Models.Requests.FirewallTags tags) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("firewalls/{id}/tags", parameters, tags, Method.DELETE);
        }

        /// <summary>
        /// Update the configuration of an existing Cloud Firewall
        /// </summary>
        public Task<Firewall> Update(string firewallId, Models.Requests.Firewall firewall) {
            var parameters = new List<Parameter> {
                new Parameter("id", firewallId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Firewall>("firewalls/{id}", parameters, firewall, "firewall", Method.PUT);
        }
    }
}
