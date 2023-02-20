namespace DigitalOcean.API.Models.Responses; 

public class Key {
    /// <summary>
    /// This is a unique identification number for the key. This can be used to reference a specific SSH key when you wish to
    /// embed a key into a Droplet.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// This is the human-readable display name for the given SSH key. This is used to easily identify the SSH keys when they
    /// are displayed.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// This attribute contains the fingerprint value that is generated from the public key. This is a unique identifier that
    /// will differentiate it from other keys using a format that SSH recognizes.
    /// </summary>
    public string Fingerprint { get; set; }

    /// <summary>
    /// This attribute contains the entire public key string that was uploaded. This is what is embedded into the root user's
    /// authorized_keys file if you choose to include this SSH key during Droplet creation.
    /// </summary>
    public string PublicKey { get; set; }
}