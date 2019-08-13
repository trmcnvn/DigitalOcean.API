using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Droplets {
        /// <summary>
        /// An array of human human-readable strings you wish to use when displaying the Droplet name.
        /// Each name, if set to a domain name managed in the DigitalOcean DNS management system, will configure a PTR record for the Droplet.
        /// Each name set during creation will also determine the hostname for the Droplet in its internal configuration.
        /// </summary>
        [JsonProperty("names")]
        public List<string> Names { get; set; }

        /// <summary>
        /// The unique slug identifier for the region that you wish to deploy in.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The unique slug identifier for the size that you wish to select for this Droplet.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// The image ID of a public or private image, or the unique slug identifier for a public image. This image will be the
        /// base image for your Droplet. Integer (if using an image ID), or String (if using a public image slug).
        /// </summary>
        [JsonProperty("image")]
        public object Image { get; set; }

        /// <summary>
        /// An array containing the IDs or fingerprints of the SSH keys that you wish to embed in the Droplet's root account upon
        /// creation.
        /// </summary>
        [JsonProperty("ssh_keys")]
        public List<object> SshKeys { get; set; }

        /// <summary>
        /// A boolean indicating whether automated backups should be enabled for the Droplet. Automated backups can only be enabled
        /// when the Droplet is created.
        /// </summary>
        [JsonProperty("backups")]
        public bool? Backups { get; set; }

        /// <summary>
        /// A boolean indicating whether IPv6 is enabled on the Droplet.
        /// </summary>
        [JsonProperty("ipv6")]
        public bool? Ipv6 { get; set; }

        /// <summary>
        /// A boolean indicating whether private networking is enabled for the Droplet. Private networking is currently only
        /// available in certain regions.
        /// </summary>
        [JsonProperty("private_networking")]
        public bool? PrivateNetworking { get; set; }

        /// <summary>
        /// A boolean indicating whether to install the DigitalOcean agent for monitoring.
        /// </summary>
        [JsonProperty("monitoring")]
        public bool? Monitoring { get; set; }

        /// <summary>
        /// A string containing 'user data' which may be used to configure the Droplet on first boot, often a 'cloud-config' file or Bash script.
        /// It must be plain text and may not exceed 64 KiB in size.
        /// </summary>
        [JsonProperty("user_data")]
        public string UserData { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the Droplet after it is created. Tag names can either be existing or new tags.
        /// creation.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
