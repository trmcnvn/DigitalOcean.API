using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IKeysClient {
        /// <summary>
        /// Retrieve all keys in your account
        /// </summary>
        Task<IReadOnlyList<Key>> GetAll();

        /// <summary>
        /// Create a new key entry
        /// </summary>
        Task<Key> Create(Models.Requests.Key key);

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        Task<Key> Get(object keyIdOrFingerprint);

        /// <summary>
        /// Update an existing key in your account
        /// </summary>
        Task<Key> Update(object keyIdOrFingerprint, Models.Requests.Key key);

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        Task Delete(object keyIdOrFingerprint);
    }
}
