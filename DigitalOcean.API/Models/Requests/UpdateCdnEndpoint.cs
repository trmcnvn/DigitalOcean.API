using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateCdnEndpoint {
        /// <summary>
        /// The amount of time the content is cached by the CDN's edge servers in seconds.
        /// </summary>
        [JsonProperty("ttl")]
        public int? TTL { get; set; }

        /// <summary>
        /// The ID of a DigitalOcean managed TLS certificate used for SSL when a custom subdomain is provided.
        /// </summary>
        [JsonProperty("certificate_id")]
        public string CertificateId { get; set; }

        /// <summary>
        /// The fully qualified domain name (FQDN) of the custom subdomain to be used with the CDN Endpoint. When used, a certificate_id
        /// must be provided as well.
        /// </summary>
        [JsonProperty("custom_domain")]
        public string CustomDomain { get; set; }
    }
}
