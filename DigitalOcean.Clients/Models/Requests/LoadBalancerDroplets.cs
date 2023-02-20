using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
	public class LoadBalancerDroplets {
		/// <summary>
		/// An array containing the IDs of the Droplets to be assigned to the Load Balancer instance.
		/// </summary>
		[JsonPropertyName("droplet_ids")]
		public List<long> DropletIds { get; set; }
	}
}
