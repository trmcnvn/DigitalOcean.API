namespace DigitalOcean.Clients.Models.Requests; 

public class Droplet {
    /// <summary>
    /// The human-readable string you wish to use when displaying the Droplet name. The name, if set to a domain name managed
    /// in the DigitalOcean DNS management system, will configure a PTR record for the Droplet. The name set during creation
    /// will also determine the hostname for the Droplet in its internal configuration.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The unique slug identifier for the region that you wish to deploy in.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; }

    /// <summary>
    /// The unique slug identifier for the size that you wish to select for this Droplet.
    /// </summary>
    [JsonPropertyName("size")]
    public string Size { get; set; }

    /// <summary>
    /// The image ID of a public or private image, or the unique slug identifier for a public image. This image will be the
    /// base image for your Droplet. Integer (if using an image ID), or String (if using a public image slug).
    /// </summary>
    [JsonPropertyName("image")]
    public object Image { get; set; }

    /// <summary>
    /// An array containing the IDs or fingerprints of the SSH keys that you wish to embed in the Droplet's root account upon
    /// creation.
    /// </summary>
    [JsonPropertyName("ssh_keys")]
    public List<object> SshKeys { get; set; }

    /// <summary>
    /// A boolean indicating whether automated backups should be enabled for the Droplet. Automated backups can only be enabled
    /// when the Droplet is created.
    /// </summary>
    [JsonPropertyName("backups")]
    public bool? Backups { get; set; }

    /// <summary>
    /// A boolean indicating whether IPv6 is enabled on the Droplet.
    /// </summary>
    [JsonPropertyName("ipv6")]
    public bool? Ipv6 { get; set; }

    /// <summary>
    /// A boolean indicating whether private networking is enabled.
    /// When VPC is enabled on an account, this will provision the Droplet inside of your account's default VPC for the region.
    /// Use the "vpc_uuid" attribute to specify a different VPC.
    /// </summary>
    [JsonPropertyName("private_networking")]
    public bool? PrivateNetworking { get; set; }

    /// <summary>
    /// A boolean indicating whether to install the DigitalOcean agent for monitoring.
    /// </summary>
    [JsonPropertyName("monitoring")]
    public bool? Monitoring { get; set; }

    /// <summary>
    /// A string containing 'user data' which may be used to configure the Droplet on first boot, often a 'cloud-config' file or Bash script.
    /// It must be plain text and may not exceed 64 KiB in size.
    /// </summary>
    [JsonPropertyName("user_data")]
    public string UserData { get; set; }

    /// <summary>
    /// A flat array of tag names as strings to apply to the Droplet after it is created. Tag names can either be existing or new tags.
    /// creation.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    /// A flat array including the unique string identifier for each Block Storage volume to be attached to the Droplet.
    /// At the moment a volume can only be attached to a single Droplet.
    /// </summary>
    [JsonPropertyName("volumes")]
    public List<string> Volumes { get; set; }

    /// <summary>
    /// A string specifying the UUID of the VPC to which the Droplet will be assigned.
    /// If excluded, beginning on April 7th, 2020, the Droplet will be assigned to your account's default VPC for the region.
    /// </summary>
    [JsonPropertyName("vpc_uuid")]
    public string VpcUuid { get; set; }
}