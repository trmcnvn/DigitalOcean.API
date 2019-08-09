using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalOcean.API.Models.Requests {
	public class LoadBalancer {
		/// <summary>
		/// A human-readable name for a Load Balancer instance.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The load balancing algorithm used to determine which backend Droplet will be selected by a client.
		/// It must be either "round_robin" or "least_connections".The default value is "round_robin".
		/// </summary>
		[JsonProperty("algorithm")]
		public string Algorithm { get; set; }

		/// <summary>
		/// The region where the Load Balancer instance will be located. When setting a region, the value should be the slug
		/// identifier for the region. When you query a Load Balancer, an entire region object will be returned.
		/// </summary>
		[JsonProperty("region")]
		public string Region { get; set; }

		/// <summary>
		/// An array of objects specifying the forwarding rules for a Load Balancer.
		/// At least one forwarding rule is required when creating a new Load Balancer instance.
		/// </summary>
		[JsonProperty("forwarding_rules")]
		public List<ForwardingRule> ForwardingRules { get; set; }

		/// <summary>
		/// An object specifying health check settings for the Load Balancer. If omitted, default values will be provided .
		/// </summary>
		[JsonProperty("health_check")]
		public HealthCheck HealthCheck { get; set; }

		/// <summary>
		/// An object specifying sticky sessions settings for the Load Balancer.
		/// </summary>
		[JsonProperty("sticky_sessions")]
		public StickySessions StickySessions { get; set; }

		/// <summary>
		/// A boolean value indicating whether HTTP requests to the Load Balancer on port 80
		/// will be redirected to HTTPS on port 443. Default value is false.
		/// </summary>
		[JsonProperty("redirect_http_to_https")]
		public bool? RedirectHttpToHttps { get; set; }

		/// <summary>
		/// A boolean value indicating whether PROXY Protocol should be used to pass information from connecting client
		/// requests to the backend service. (This may require additional configuration on the target Droplets.)
		/// </summary>
		[JsonProperty("enable_proxy_protocol")]
		public bool? EnableProxyProtocol { get; set; }

		/// <summary>
		/// An array containing the IDs of the Droplets to be assigned to the Load Balancer.
		/// This attribute and the "tag" attribute are mutually exclusive.
		/// </summary>
		[JsonProperty("droplet_ids")]
		public List<int> DropletIds { get; set; }

		/// <summary>
		/// The name of a Droplet tag corresponding to Droplets to be assigned to the Load Balancer.
		/// This attribute and the "droplet_ids" attribute are mutually exclusive.
		/// </summary>
		[JsonProperty("tag")]
		public string Tag { get; set; }
	}
}
