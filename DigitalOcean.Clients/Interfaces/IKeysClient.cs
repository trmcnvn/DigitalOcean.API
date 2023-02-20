using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IKeysClient {
    /// <summary>
    /// Retrieve all keys in your account
    /// </summary>
    Task<IEnumerable<Key>> GetAll();

    /// <summary>
    /// Create a new key entry
    /// </summary>
    Task<Key> Create(Models.Requests.Key key);

    /// <summary>
    /// Retrieve an existing key in your account
    /// </summary>
    Task<Key> Get(object keyIdOrFingerprint);

    /// <summary>
    /// To update the name of an SSH key.
    /// </summary>
    Task<Key> Update(object keyIdOrFingerprint, Models.Requests.UpdateKey updateKey);

    /// <summary>
    /// Delete an existing key in your account
    /// </summary>
    Task Delete(object keyIdOrFingerprint);
}
