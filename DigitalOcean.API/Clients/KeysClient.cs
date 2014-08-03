using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class KeysClient : IKeysClient {
        private readonly IConnection _connection;

        public KeysClient(IConnection connection) {
            _connection = connection;
        }

        #region IKeysClient Members

        /// <summary>
        /// Retrieve all keys in your account
        /// </summary>
        public Task<IReadOnlyList<Key>> GetAll() {
            return _connection.GetPaginated<Key>("keys", null, "ssh_keys");
        }

        /// <summary>
        /// Create a new key entry
        /// </summary>
        public Task<Key> Create(Models.Requests.Key key) {
            return _connection.ExecuteRequest<Key>("keys", null, key, "ssh_key", Method.POST);
        }

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        public Task<Key> Get(object keyIdOrFingerprint) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Key>("keys/{id}", parameters, null, "ssh_key");
        }

        /// <summary>
        /// Update an existing key in your account
        /// </summary>
        public Task<Key> Update(object keyIdOrFingerprint, Models.Requests.Key key) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Key>("keys/{id}", parameters, key, "ssh_key", Method.PUT);
        }

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        public Task Delete(object keyIdOrFingerprint) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("keys/{id}", parameters, Method.DELETE);
        }

        #endregion
    }
}