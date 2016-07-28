using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Responses {
    public class Tag {
        /// <summary>
        /// The name of the tag. The supported characters for names include alphanumeric characters, dashes, and underscores.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An embedded object containing key value pairs of resource type and resource statistics.
        /// </summary>
        public Resource Resources { get; set; }

        public class Resource {
            /// <summary>
            /// An embedded object containing key value pairs indicating count of tagged droplets and last tagged droplet
            /// </summary>
            public TaggedDroplets Droplets { get; set; }

            public class TaggedDroplets {
                /// <summary>
                /// A count of droplets tagged with this tag
                /// </summary>
                public int Count { get; set; }

                /// <summary>
                /// The last droplet to be tagged with this tag
                /// </summary>
                public Droplet LastTagged { get; set; }
            }
        }
    }
}
