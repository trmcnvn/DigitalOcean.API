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
            return _connection.GetPaginated<Key>("account/keys", null, "ssh_keys");
        }

        /// <summary>
        /// Create a new key entry
        /// </summary>
        public Task<Key> Create(Models.Requests.Key key) {
            return _connection.ExecuteRequest<Key>("account/keys", null, key, "ssh_key", Method.Post);
        }

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        public Task<Key> Get(object keyIdOrFingerprint) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("id", keyIdOrFingerprint.ToString())
            };
            return _connection.ExecuteRequest<Key>("account/keys/{id}", parameters, null, "ssh_key");
        }

        /// <summary>
        /// To update the name of an SSH key.
        /// </summary>
        public Task<Key> Update(object keyIdOrFingerprint, Models.Requests.UpdateKey updateKey) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("id", keyIdOrFingerprint.ToString())
            };
            return _connection.ExecuteRequest<Key>("account/keys/{id}", parameters, updateKey, "ssh_key", Method.Put);
        }

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        public Task Delete(object keyIdOrFingerprint) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("id",keyIdOrFingerprint.ToString())
            };
            return _connection.ExecuteRaw("account/keys/{id}", parameters, null, Method.Delete);
        }

        #endregion
    }
}
