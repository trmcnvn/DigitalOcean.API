using DigitalOcean.API.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalOcean.API.Clients {
	public interface ILoadBalancerClient {
		/// <summary>
	    /// Retrieve all LoadBalancers in your account.
	    /// </summary>
		Task<IReadOnlyList<LoadBalancer>> GetAll();

		/// <summary>
		/// Create a new LoadBalancer
		/// </summary>
		Task<LoadBalancer> Create(Models.Requests.LoadBalancer loadBalancer);

		/// <summary>
		/// Retrieve an existing LoadBalancer
		/// </summary>
		Task<LoadBalancer> Get(int loadBalancerId);

		/// <summary>
		/// Delete an existing LoadBalancer
		/// </summary>
		Task Delete(int loadBalancerId);

		/// <summary>
		/// Update an existing LoadBalancer
		/// </summary>
		Task Update(int loadBalancerId, Models.Requests.LoadBalancer loadBalancer);

		/// <summary>
		/// Add Droplets to an LoadBalancer
		/// </summary>
		Task AddDroplets(int loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds);

		/// <summary>
		/// Remove exsisting Droplets from an LoadBalancer
		/// </summary>
		Task RemoveDroplets(int loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds);

		/// <summary>
		/// Add new Forwarding Rule to an LoadBalancer
		/// </summary>
		Task AddForwardingRules(int loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules);

		/// <summary>
		/// Remove exsisting Forwarding Rule from an LoadBalancer
		/// </summary>
		Task RemoveForwardingRules(int loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules);
	}
}
