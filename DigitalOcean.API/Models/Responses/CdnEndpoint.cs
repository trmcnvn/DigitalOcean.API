using System;

namespace DigitalOcean.API.Models.Responses {
    public class CdnEndpoint {
        /// <summary>
        /// A unique ID that can be used to identify and reference a CDN endpoint.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The fully qualified domain name (FQDN) for the origin server which the provides the content for the CDN.
        /// This is currently restricted to a Space.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// The fully qualified domain name (FQDN) from which the CDN-backed content is served.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the CDN endpoint was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The amount of time the content is cached by the CDN's edge servers in seconds.
        /// </summary>
        public int TTL { get; set; }

        /// <summary>
        /// The ID of a DigitalOcean managed TLS certificate used for SSL when a custom subdomain is provided.
        /// </summary>
        public string CertificateId { get; set; }

        /// <summary>
        /// The fully qualified domain name (FQDN) of the custom subdomain used with the CDN Endpoint.
        /// </summary>
        public string CustomDomain { get; set; }
    }
}
