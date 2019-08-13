using System;

namespace DigitalOcean.API.Models.Responses {
    public class KubernetesNode {
        /// <summary>
        /// A unique ID that can be used to identify and reference the node.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An automatically generated, human-readable name for the node.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An object containing a "state" attribute whose value is set to a string indicating the current status of the node. Potential values include running, provisioning, and errored.
        /// </summary>
        public KubernetesNodeStatus Status { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the node was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the node was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
