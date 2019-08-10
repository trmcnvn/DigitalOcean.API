using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
	public class LoadBalancerDroplets {
		/// <summary>
		/// An array containing the IDs of the Droplets to be assigned to the Load Balancer instance.
		/// </summary>
		[JsonProperty("droplet_ids")]
		public List<int> DropletIds { get; set; }
	}
}
