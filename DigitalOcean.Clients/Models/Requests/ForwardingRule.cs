namespace DigitalOcean.API.Models.Requests {
	public class ForwardingRule {
		/// <summary>
		/// The protocol used for traffic to the Load Balancer. The possible values are: "http", "https", "http2", or "tcp".
		/// </summary>
		[JsonPropertyName("entry_protocol")]
		public string EntryProtocol { get; set; }

		/// <summary>
		/// An integer representing the port on which the Load Balancer instance will listen.
		/// </summary>
		[JsonPropertyName("entry_port")]
		public int EntryPort { get; set; }

		/// <summary>
		/// The protocol used for traffic from the Load Balancer to the backend Droplets.
		/// The possible values are: "http", "https", "http2", or "tcp".
		/// </summary>
		[JsonPropertyName("target_protocol")]
		public string TargetProtocol { get; set; }

		/// <summary>
		/// An integer representing the port on the backend Droplets to which the Load Balancer will send traffic.
		/// </summary>
		[JsonPropertyName("target_port")]
		public int TargetPort { get; set; }

		/// <summary>
		/// The ID of the TLS certificate used for SSL termination if enabled.
		/// </summary>
		[JsonPropertyName("certificate_id")]
		public string CertificateId { get; set; }

		/// <summary>
		/// A boolean value indicating whether SSL encrypted traffic will be passed through to the backend Droplets.
		/// </summary>
		[JsonPropertyName("tls_passthrough")]
		public bool? TlsPassthrough { get; set; }
	}
}
