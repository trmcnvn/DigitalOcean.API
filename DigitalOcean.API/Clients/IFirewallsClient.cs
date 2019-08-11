using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IFirewallsClient {
        /// <summary>
        /// Create a new Cloud Firewall
        /// </summary>
        Task<Firewall> Create(Models.Requests.Firewall firewall);

        /// <summary>
        /// Retreive an individual Cloud Firewall
        /// </summary>
        Task<Firewall> Get(string firewallId);

        /// <summary>
        /// Retreive all Cloud Firewalls available on your account
        /// </summary>
        Task<IReadOnlyList<Firewall>> GetAll();

        /// <summary>
        /// Update the configuration of an existing Cloud Firewall
        /// </summary>
        Task<Firewall> Update(string firewallId, Models.Requests.Firewall firewall);

        /// <summary>
        /// Delete a Cloud Firewall
        /// </summary>
        Task Delete(string firewallId);

        /// <summary>
        /// Assign a Droplet to a Cloud Firewall
        /// </summary>
        Task AddDroplets(string firewallId, Models.Requests.FirewallDroplets droplets);

        /// <summary>
        /// Remove a Droplet from a Cloud Firewall,
        /// </summary>
        Task RemoveDroplets(string firewallId, Models.Requests.FirewallDroplets droplets);

        /// <summary>
        /// Assign a Tag representing a group of Droplets to a Cloud Firewall
        /// </summary>
        Task AddTags(string firewallId, Models.Requests.FirewallTags tags);

        /// <summary>
        /// Remove a Tag representing a group of Droplets from a Cloud Firewall
        /// </summary>
        Task RemoveTags(string firewallId, Models.Requests.FirewallTags tags);

        /// <summary>
        /// Add additional access rules to a Cloud Firewall
        /// </summary>
        Task AddRules(string firewallId, Models.Requests.FirewallRules rules);

        /// <summary>
        /// Remove access rules from a Cloud Firewall
        /// </summary>
        Task RemoveRules(string firewallId, Models.Requests.FirewallRules rules);
    }
}
