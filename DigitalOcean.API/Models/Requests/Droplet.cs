using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Droplet {
        /// <summary>
        /// The human-readable string you wish to use when displaying the Droplet name. The name, if set to a domain name managed
        /// in the DigitalOcean DNS management system, will configure a PTR record for the Droplet. The name set during creation
        /// will also determine the hostname for the Droplet in its internal configuration.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The unique slug identifier for the region that you wish to deploy in.
        /// </summary>
        [JsonProperty("region")]
        public string RegionSlug { get; set; }

        /// <summary>
        /// The unique slug identifier for the size that you wish to select for this Droplet.
        /// </summary>
        [JsonProperty("size")]
        public string SizeSlug { get; set; }

        /// <summary>
        /// The image ID of a public or private image, or the unique slug identifier for a public image. This image will be the
        /// base image for your Droplet.
        /// </summary>
        [JsonProperty("image")]
        public object ImageIdOrSlug { get; set; }

        /// <summary>
        /// An array containing the IDs or fingerprints of the SSH keys that you wish to embed in the Droplet's root account upon
        /// creation.
        /// </summary>
        [JsonProperty("ssh_keys")]
        public List<object> SshIdsOrFingerprints { get; set; }

        /// <summary>
        /// A boolean indicating whether automated backups should be enabled for the Droplet. Automated backups can only be enabled
        /// when the Droplet is created.
        /// </summary>
        [JsonProperty("backups")]
        public bool Backups { get; set; }

        /// <summary>
        /// A boolean indicating whether IPv6 is enabled on the Droplet.
        /// </summary>
        [JsonProperty("ipv6")]
        public bool Ipv6 { get; set; }

        /// <summary>
        /// A boolean indicating whether private networking is enabled for the Droplet. Private networking is currently only
        /// available in certain regions.
        /// </summary>
        [JsonProperty("private_networking")]
        public bool PrivateNetworking { get; set; }
        
        /// <summary>
        /// A string containing a YAML formatted Cloud-Init script
        /// </summary>
        [JsonProperty("user_data")]
        public string UserData { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the Droplet after it is created. Tag names can either be existing or new tags.
        /// creation.
        /// </summary>
        [JsonProperty("tags")]
        public List<object> Tags { get; set; }
    }
}
