using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class CertificatesClient : ICertificatesClient {
        private readonly IConnection _connection;

        public CertificatesClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To list all of the certificates available on your account.
        /// </summary>
        public Task<IReadOnlyList<Certificate>> GetAll() {
            return _connection.GetPaginated<Certificate>("certificates", null, "certificates");
        }

        /// <summary>
        /// To show information about an existing certificate.
        /// </summary>
        public Task<Certificate> Get(string certificateId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "certificate_id", Value = certificateId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Certificate>("certificates/{certificate_id}", parameters, null, "certificate");
        }

        /// <summary>
        /// Create a new Let's Encrypt Certificate:
        /// When using Let's Encrypt to create a certificate, the dns_names attribute must be provided,
        /// and the type must be set to "lets_encrypt".
        ///
        /// Create a new custom Certificate:
        /// When uploading a user-generated certificate, the private_key, leaf_certificate, and optionally the certificate_chain
        /// attributes should be provided. The type must be set to "custom".
        /// </summary>
        public Task<Certificate> Create(Models.Requests.Certificate certificate) {
            return _connection.ExecuteRequest<Certificate>("certificates", null, certificate, "certificate", Method.POST);
        }

        /// <summary>
        /// To delete a specific certificate.
        /// </summary>
        public Task Delete(string certificateId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "certificate_id", Value = certificateId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("certificates/{certificate_id}", parameters, null, Method.DELETE);
        }
    }
}
