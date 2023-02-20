namespace DigitalOcean.Clients.Models.Requests; 

public class UpdateCdnEndpoint {
    /// <summary>
    /// The amount of time the content is cached by the CDN's edge servers in seconds.
    /// </summary>
    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }

    /// <summary>
    /// The ID of a DigitalOcean managed TLS certificate used for SSL when a custom subdomain is provided.
    /// In order to remove value, set to empty string.
    /// </summary>
    [JsonPropertyName("certificate_id")]
    public string CertificateId { get; set; }

    /// <summary>
    /// The fully qualified domain name (FQDN) of the custom subdomain to be used with the CDN Endpoint. When used, a certificate_id
    /// must be provided as well.
    /// In order to remove value, set to empty string.
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string CustomDomain { get; set; }
}