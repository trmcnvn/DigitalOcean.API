namespace DigitalOcean.Clients.Models.Requests; 

public class StickySessions {
    /// <summary>
    /// An attribute indicating how and if requests from a client will be persistently served
    /// by the same backend Droplet. The possible values are "cookies" or "none".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The name of the cookie sent to the client. This attribute is only returned when using "cookies" for the sticky sessions type.
    /// </summary>
    [JsonPropertyName("cookie_name")]
    public string CookieName { get; set; }

    /// <summary>
    /// The number of seconds until the cookie set by the Load Balancer expires.
    /// This attribute is only returned when using "cookies" for the sticky sessions type.
    /// </summary>
    [JsonPropertyName("cookie_ttl_seconds")]
    public string CookieTtlInSeconds { get; set; }
}