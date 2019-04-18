using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses
{
	public class HealthCheck
	{
		/// <summary>
		/// The protocol used for health checks sent to the backend Droplets. The possible values are "http" or "tcp".
		/// </summary>
		[JsonProperty("protocol")]
		public string Protocol { get; set; }

		/// <summary>
		/// An integer representing the port on the backend Droplets on which the health check will attempt a connection.
		/// </summary>
		[JsonProperty("port")]
		public int Port { get; set; }

		/// <summary>
		/// The path on the backend Droplets to which the Load Balancer instance will send a request.
		/// </summary>
		[JsonProperty("path")]
		public string Path { get; set; }

		/// <summary>
		/// The number of seconds between between two consecutive health checks.
		/// </summary>
		[JsonProperty("check_interval_seconds")]
		public int CheckIntervalInSeconds { get; set; }

		/// <summary>
		/// The number of seconds the Load Balancer instance will wait for a response until marking a health check as failed.
		/// </summary>
		[JsonProperty("response_timeout_seconds")]
		public int ResponseTimeoutInSeconds { get; set; }

		/// <summary>
		/// The number of times a health check must fail for a backend Droplet to be marked "unhealthy" and be removed from the pool.
		/// </summary>
		[JsonProperty("unhealthy_threshold")]
		public int UnhealthyThreshold { get; set; }

		/// <summary>
		/// The number of times a health check must pass for a backend Droplet to be marked "healthy" and be re-added to the pool.
		/// </summary>
		[JsonProperty("healthy_threshold")]
		public int HealthyThreshold { get; set; }
	}
}
