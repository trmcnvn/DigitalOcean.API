namespace DigitalOcean.Clients.Models.Responses; 

public class ReservedIp {
    /// <summary>
    /// The public IP address of the Floating IP. It also serves as its identifier.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// The region that the Floating IP is reserved to.
    /// </summary>
    public Region Region { get; set; }

    /// <summary>
    /// The Droplet that the Floating IP has been assigned to.
    /// </summary>
    public Droplet Droplet { get; set; }
}