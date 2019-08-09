using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
	public class LoadBalancer {
		/// <summary>
		/// A unique ID that can be used to identify and reference a Load Balancer.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// A human-readable name for a Load Balancer instance.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// An attribute containing the public-facing IP address of the Load Balancer.
		/// </summary>
		[JsonProperty("ip")]
		public string IpAddress { get; set; }

		/// <summary>
		/// The load balancing algorithm used to determine which backend Droplet will be selected by a client.
        /// It must be either "round_robin" or "least_connections".
		/// </summary>
		public string Algorithm { get; set; }

		/// <summary>
		/// A status string indicating the current state of the Load Balancer. This can be "new", "active", or "errored".
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// A time value given in ISO8601 combined date and time format that represents when the Load Balancer was created.
		/// </summary>
		public string CreatedAt { get; set; }

		/// <summary>
		/// An object specifying the forwarding rules for a Load Balancer.
		/// </summary>
		public List<ForwardingRule> ForwardingRules { get; set; }

		/// <summary>
		/// An object specifying health check settings for the Load Balancer.
		/// </summary>
		public HealthCheck HealthCheck { get; set; }

		/// <summary>
		/// An object specifying health check settings for the Load Balancer.
		/// </summary>
		public StickySessions StickySessions { get; set; }

		/// <summary>
		/// The region where the Load Balancer instance is located. When setting a region,
        /// the value should be the slug identifier for the region. When you query a Load Balancer, an entire region object will be returned.
		/// </summary>
		public Region Region { get; set; }

		/// <summary>
		/// The name of a Droplet tag corresponding to Droplets assigned to the Load Balancer.
		/// </summary>
		public string Tag { get; set; }

		/// <summary>
		/// An array containing the IDs of the Droplets assigned to the Load Balancer.
		/// </summary>
		public List<int> DropletIds { get; set; }

		/// <summary>
		/// A boolean value indicating whether HTTP requests to the Load Balancer on port 80 will be redirected to HTTPS on port 443.
		/// </summary>
		public bool RedirectHttpToHttps { get; set; }

		/// <summary>
		///A boolean value indicating whether PROXY Protocol is in use.
		/// </summary>
		public bool EnableProxyProtocol { get; set; }
	}
}
