namespace DigitalOcean.Clients.Models.Responses; 

public class Certificate {
    /// <summary>
    /// A unique ID that can be used to identify and reference a certificate.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// A unique human-readable name referring to a certificate.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents the certificate's expiration date.
    /// </summary>
    public DateTime NotAfter { get; set; }

    /// <summary>
    /// A unique identifier generated from the SHA-1 fingerprint of the certificate.
    /// </summary>
    public string Sha1Fingerprint { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the certificate was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// An array of fully qualified domain names (FQDNs) for which the certificate was issued.
    /// </summary>
    public List<string> DnsNames { get; set; }

    /// <summary>
    /// A string representing the current state of the certificate. It may be "pending", "verified", or "error".
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// A string representing the type of the certificate. The value will be "custom" for a user-uploaded certificate or
    /// "lets_encrypt" for one automatically generated with Let's Encrypt.
    /// </summary>
    public string Type { get; set; }
}