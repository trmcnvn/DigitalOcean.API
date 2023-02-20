namespace DigitalOcean.Clients.Models.Requests; 

public class AppDomainSpec {
    /// <summary>
    /// [ 4 .. 253 ] characters ^((xn--)?[a-zA-Z0-9]+(-[a-zA-Z0-9]+)*\.)+[a-zA-Z]{2,}\.?$
    ///The hostname for the domain
    /// </summary>
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    ///Enum: "UNSPECIFIED" "DEFAULT" "PRIMARY" "ALIAS"
    /// DEFAULT: The default .ondigitalocean.app domain assigned to this app
    /// PRIMARY: The primary domain for this app that is displayed as the default in the control panel, used in bindable environment variables, and any other places that reference an app's live URL. Only one domain may be set as primary.
    /// ALIAS: A non-primary domains
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Indicates whether the domain includes all sub-domains, in addition to the given domain
    /// </summary>
    [JsonPropertyName("wildcard")]
    public bool Wildcard { get; set; }

    /// <summary>
    /// Optional. If the domain uses DigitalOcean DNS and you would like App Platform to automatically manage it for you, set this to the name of the domain on your account.
    ///For example, If the domain you are adding is app.domain.com, the zone could be domain.com.
    /// </summary>
    [JsonPropertyName("zone")]
    public string Zone { get; set; }
}