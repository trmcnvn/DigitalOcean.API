using DigitalOcean.Clients.Models.Requests;
using Firewall = DigitalOcean.Clients.Models.Responses.Firewall;

namespace DigitalOcean.Clients.Clients.Imports;

public class FirewallsClient : IFirewallsClient {
    private readonly IConnection _connection;

    public FirewallsClient(IConnection connection) {
        _connection = connection;
    }

    /// <summary>
    /// Assign a Droplet to a Cloud Firewall
    /// </summary>
    public Task AddDroplets(string firewallId, FirewallDroplets droplets) {
        return _connection.ExecuteRaw($"firewalls/{firewallId}/droplets", null, droplets, HttpMethod.Post);
    }

    /// <summary>
    /// Add additional access rules to a Cloud Firewall
    /// </summary>
    public Task AddRules(string firewallId, FirewallRules rules) {
        return _connection.ExecuteRaw($"firewalls/{firewallId}/droplets", null, rules, HttpMethod.Post);
    }

    /// <summary>
    /// Assign a Tag representing a group of Droplets to a Cloud Firewall
    /// </summary>
    public Task AddTags(string firewallId, FirewallTags tags) {
        return _connection.ExecuteRaw($"firewalls/{firewallId}/tags", null, tags, HttpMethod.Post);
    }

    /// <summary>
    /// Create a new Cloud Firewall
    /// </summary>
    public Task<Firewall> Create(DigitalOcean.Clients.Models.Requests.Firewall firewall) {
        return _connection.ExecuteRequest<Firewall>("firewalls", null, firewall, "firewall", HttpMethod.Post);
    }

    /// <summary>
    /// Delete a Cloud Firewall
    /// </summary>
    public Task Delete(string id) {
        return _connection.ExecuteRaw($"firewalls/{id}", null, null, HttpMethod.Delete);
    }

    /// <summary>
    /// Retreive an individual Cloud Firewall
    /// </summary>
    public Task<Firewall> Get(string id) {
        return _connection.ExecuteRequest<Firewall>($"firewalls/{id}", null, null, "firewall");
    }

    /// <summary>
    /// Retreive all Cloud Firewalls available on your account
    /// </summary>
    public Task<IEnumerable<Firewall>> GetAll() {
        return _connection.GetPaginated<Firewall>("firewalls", null, "firewalls");
    }

    /// <summary>
    /// Remove a Droplet from a Cloud Firewall,
    /// </summary>
    public Task RemoveDroplets(string firewallId, FirewallDroplets droplets) {
        return _connection.ExecuteRaw("firewalls/{id}/droplets", null, droplets, HttpMethod.Delete);
    }

    /// <summary>
    /// Remove access rules from a Cloud Firewall
    /// </summary>
    public Task RemoveRules(string firewallId, FirewallRules rules) {
        return _connection.ExecuteRaw("firewalls/{id}/rules", null, rules, HttpMethod.Delete);
    }

    /// <summary>
    /// Remove a Tag representing a group of Droplets from a Cloud Firewall
    /// </summary>
    public Task RemoveTags(string firewallId, FirewallTags tags) {
        return _connection.ExecuteRaw("firewalls/{id}/tags", null, tags, HttpMethod.Delete);
    }

    /// <summary>
    /// Update the configuration of an existing Cloud Firewall
    /// </summary>
    public Task<Firewall> Update(string firewallId, DigitalOcean.Clients.Models.Requests.Firewall firewall) {
        return _connection.ExecuteRequest<Firewall>("firewalls/{id}", null, firewall, "firewall", HttpMethod.Put);
    }
}
