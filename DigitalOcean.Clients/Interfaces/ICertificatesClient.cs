using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ICertificatesClient {
    /// <summary>
    /// To list all of the certificates available on your account.
    /// </summary>
    Task<IEnumerable<Certificate>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// To show information about an existing certificate.
    /// </summary>
    Task<Certificate> GetAsync(string certificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new Let's Encrypt Certificate:
    /// When using Let's Encrypt to create a certificate, the dns_names attribute must be provided,
    /// and the type must be set to "lets_encrypt".
    ///
    /// Create a new custom Certificate:
    /// When uploading a user-generated certificate, the private_key, leaf_certificate, and optionally the certificate_chain
    /// attributes should be provided. The type must be set to "custom".
    /// </summary>
    Task<Certificate> CreateAsync(Models.Requests.Certificate certificate, CancellationToken cancellationToken = default);

    /// <summary>
    /// To delete a specific certificate.
    /// </summary>
    Task DeleteAsync(string certificateId, CancellationToken cancellationToken = default);
}
