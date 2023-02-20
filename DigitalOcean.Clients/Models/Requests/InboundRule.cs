namespace DigitalOcean.Clients.Models.Requests; 

public class InboundRule {
    /// <summary>
    /// The type of traffic to be allowed. This may be one of "tcp", "udp", or "icmp".
    /// </summary>
    [JsonPropertyName("protocol")]
    public string Protocol { get; set; }

    /// <summary>
    /// The ports on which traffic will be allowed specified as a string containing a single port, a range (e.g. "8000-9000"), or "all" to open all ports for a protocol. This parameter should be omited for ICMP rules.
    /// </summary>
    [JsonPropertyName("ports")]
    public string Ports { get; set; }

    /// <summary>
    /// An object specifying locations from which inbound traffic will be accepted. (See below for the available keys and the types.)
    /// </summary>
    [JsonPropertyName("sources")]
    public SourceLocation Sources { get; set; }
}