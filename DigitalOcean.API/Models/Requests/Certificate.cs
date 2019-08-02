using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Certificate {
        /// <summary>
        /// A unique human-readable name referring to a certificate.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A string representing the type of the certificate. The value should be "custom" for a user-uploaded certificate or
        /// "lets_encrypt" for one automatically generated with Let's Encrypt.
        /// If not provided, "custom" will be assumed by default.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// An array of fully qualified domain names (FQDNs) for which the certificate will be issued.
        /// The domains must be managed using DigitalOcean's DNS.
        /// </summary>
        [JsonProperty("dns_names")]
        public List<string> DnsNames { get; set; }

        /// <summary>
        /// The contents of a PEM-formatted private-key corresponding to the SSL certificate.
        /// </summary>
        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        /// <summary>
        /// The contents of a PEM-formatted public SSL certificate.
        /// </summary>
        [JsonProperty("leaf_certificate")]
        public string LeafCertificate { get; set; }

        /// <summary>
        /// The full PEM-formatted trust chain between the certificate authority's certificate and your domain's SSL certificate.
        /// </summary>
        [JsonProperty("certificate_chain")]
        public string CertificateChain { get; set; }
    }
}
