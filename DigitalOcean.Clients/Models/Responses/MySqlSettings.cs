namespace DigitalOcean.Clients.Models.Responses;

public class MySqlSettings {
    /// <summary>
    /// A string specifying the authentication method in use for connections to the MySQL user account.
    /// The valid values are "mysql_native_password" or "caching_sha2_password".
    /// </summary>
    [JsonPropertyName("auth_plugin")]
    public string AuthPlugin { get; set; }
}
