﻿namespace DigitalOcean.Clients.Models.Requests; 

public class CdnEndpoint {
    /// <summary>
    /// The fully qualified domain name (FQDN) for the origin server which the provides the content for the CDN. This is currently
    /// restricted to a Space.
    /// </summary>
    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    /// <summary>
    /// The amount of time the content is cached by the CDN's edge servers in seconds. Defaults to 3600 (one hour) when excluded.
    /// </summary>
    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }

    /// <summary>
    /// The ID of a DigitalOcean managed TLS certificate used for SSL when a custom subdomain is provided.
    /// </summary>
    [JsonPropertyName("certificate_id")]
    public string CertificateId { get; set; }

    /// <summary>
    /// The fully qualified domain name (FQDN) of the custom subdomain to be used with the CDN Endpoint. When used, a certificate_id
    /// must be provided as well.
    /// </summary>
    [JsonPropertyName("custom_domain")]
    public string CustomDomain { get; set; }
}