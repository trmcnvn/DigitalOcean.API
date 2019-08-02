using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface ICertificatesClient {
        /// <summary>
        /// To list all of the certificates available on your account.
        /// </summary>
        Task<IReadOnlyList<Certificate>> GetAll();

        /// <summary>
        /// To show information about an existing certificate.
        /// </summary>
        Task<Certificate> Get(string certificateId);

        /// <summary>
        /// Create a new Let's Encrypt Certificate:
        /// When using Let's Encrypt to create a certificate, the dns_names attribute must be provided,
        /// and the type must be set to "lets_encrypt".
        ///
        /// Create a new custom Certificate:
        /// When uploading a user-generated certificate, the private_key, leaf_certificate, and optionally the certificate_chain
        /// attributes should be provided. The type must be set to "custom".
        /// </summary>
        Task<Certificate> Create(Models.Requests.Certificate certificate);

        /// <summary>
        /// To delete a specific certificate.
        /// </summary>
        Task Delete(string certificateId);
    }
}
