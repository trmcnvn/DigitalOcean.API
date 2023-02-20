using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class KeysClient : IKeysClient {
    private readonly IConnection _connection;

    public KeysClient(IConnection connection) {
        _connection = connection;
    }

    #region IKeysClient Members

    /// <summary>
    /// Retrieve all keys in your account
    /// </summary>
    public Task<IEnumerable<Key>> GetAll() {
        return _connection.GetPaginated<Key>("account/keys", null, "ssh_keys");
    }

    /// <summary>
    /// Create a new key entry
    /// </summary>
    public Task<Key> Create(Models.Requests.Key key) {
        return _connection.ExecuteRequest<Key>("account/keys", null, key, "ssh_key", HttpMethod.Post);
    }

    /// <summary>
    /// Retrieve an existing key in your account
    /// </summary>
    public Task<Key> Get(object keyIdOrFingerprint) {
        return _connection.ExecuteRequest<Key>($"account/keys/{keyIdOrFingerprint}", null, null, "ssh_key");
    }

    /// <summary>
    /// To update the name of an SSH key.
    /// </summary>
    public Task<Key> Update(object keyIdOrFingerprint, Models.Requests.UpdateKey updateKey) {
        return _connection.ExecuteRequest<Key>($"account/keys/{keyIdOrFingerprint}", null, updateKey, "ssh_key", HttpMethod.Put);
    }

    /// <summary>
    /// Delete an existing key in your account
    /// </summary>
    public Task Delete(object keyIdOrFingerprint) {
        return _connection.ExecuteRaw($"account/keys/{keyIdOrFingerprint}", null, null, HttpMethod.Delete);
    }

    #endregion
}
