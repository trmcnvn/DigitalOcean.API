using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Image {
        /// <summary>
        /// The display name to be given to an image.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A URL from which the custom Linux virtual machine image may be retrieved. The image it points to must be in the
        /// raw, qcow2, vhdx, vdi, or vmdk format. It may be compressed using gzip or bzip2 and must be smaller than 100 GB
        /// after being decompressed.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The slug identifier for the region where the image will initially be available.
        /// </summary>
        [JsonProperty("region")]
        public string RegionSlug { get; set; }

        /// <summary>
        /// The name of a custom image's distribution.
        /// Currently, the valid values are "Arch Linux", "CentOS", "CoreOS", "Debian", "Fedora", "Fedora Atomic", "FreeBSD", "Gentoo",
        /// "openSUSE", "RancherOS", "Ubuntu", and "Unknown".
        /// Any other value will be accepted but ignored, and "Unknown" will be used in its place.
        /// </summary>
        [JsonProperty("distribution")]
        public string Distribution { get; set; }

        /// <summary>
        /// An optional free-form text field to describe an image.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to be applied to the image. Tag names may be for either existing or new tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
