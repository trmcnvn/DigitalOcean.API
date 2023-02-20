using Firewall = DigitalOcean.Clients.Models.Responses.Firewall;
namespace DigitalOcean.Clients.Interfaces;

public interface IFirewallsClient {
    /// <summary>
    /// Create a new Cloud Firewall
    /// </summary>
    Task<Firewall> Create(Models.Requests.Firewall firewall);

    /// <summary>
    /// Retreive an individual Cloud Firewall
    /// </summary>
    Task<Firewall> Get(string id);

    /// <summary>
    /// Retreive all Cloud Firewalls available on your account
    /// </summary>
    Task<IEnumerable<Firewall>> GetAll();

    /// <summary>
    /// Update the configuration of an existing Cloud Firewall
    /// </summary>
    Task<Firewall> Update(string id, Models.Requests.Firewall firewall);

    /// <summary>
    /// Delete a Cloud Firewall
    /// </summary>
    Task Delete(string id);

    /// <summary>
    /// Assign a Droplet to a Cloud Firewall
    /// </summary>
    Task AddDroplets(string id, Models.Requests.FirewallDroplets droplets);

    /// <summary>
    /// Remove a Droplet from a Cloud Firewall,
    /// </summary>
    Task RemoveDroplets(string id, Models.Requests.FirewallDroplets droplets);

    /// <summary>
    /// Assign a Tag representing a group of Droplets to a Cloud Firewall
    /// </summary>
    Task AddTags(string id, Models.Requests.FirewallTags tags);

    /// <summary>
    /// Remove a Tag representing a group of Droplets from a Cloud Firewall
    /// </summary>
    Task RemoveTags(string id, Models.Requests.FirewallTags tags);

    /// <summary>
    /// Add additional access rules to a Cloud Firewall
    /// </summary>
    Task AddRules(string id, Models.Requests.FirewallRules rules);

    /// <summary>
    /// Remove access rules from a Cloud Firewall
    /// </summary>
    Task RemoveRules(string id, Models.Requests.FirewallRules rules);
}
