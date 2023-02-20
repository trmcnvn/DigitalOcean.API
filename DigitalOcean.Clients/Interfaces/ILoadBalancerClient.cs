using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ILoadBalancerClient {
    /// <summary>
    /// Retrieve all LoadBalancers in your account.
    /// </summary>
    Task<IEnumerable<LoadBalancer>> GetAll();

    /// <summary>
    /// Create a new LoadBalancer
    /// </summary>
    Task<LoadBalancer> Create(Models.Requests.LoadBalancer loadBalancer);

    /// <summary>
    /// Retrieve an existing LoadBalancer
    /// </summary>
    Task<LoadBalancer> Get(string loadBalancerId);

    /// <summary>
    /// Delete an existing LoadBalancer
    /// </summary>
    Task Delete(string loadBalancerId);

    /// <summary>
    /// Update an existing LoadBalancer
    /// </summary>
    Task Update(string loadBalancerId, Models.Requests.LoadBalancer loadBalancer);

    /// <summary>
    /// Add Droplets to an LoadBalancer
    /// </summary>
    Task AddDroplets(string loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds);

    /// <summary>
    /// Remove exsisting Droplets from an LoadBalancer
    /// </summary>
    Task RemoveDroplets(string loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds);

    /// <summary>
    /// Add new Forwarding Rule to an LoadBalancer
    /// </summary>
    Task AddForwardingRules(string loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules);

    /// <summary>
    /// Remove exsisting Forwarding Rule from an LoadBalancer
    /// </summary>
    Task RemoveForwardingRules(string loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules);
}
