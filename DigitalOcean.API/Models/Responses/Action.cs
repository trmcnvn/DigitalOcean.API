using System;

namespace DigitalOcean.API.Models.Responses {
    /// <summary>
    /// Actions are records of events that have occurred on the resources in your account. These can be things like rebooting a
    /// Droplet, or transferring an image to a new region.
    /// </summary>
    public class Action {
        /// <summary>
        /// A unique numeric ID that can be used to identify and reference an action.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The current status of the action. This can be "in-progress", "completed", or "errored".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This is the type of action that the object represents. For example, this could be "transfer" to represent the state of
        /// an image transfer action.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the action was initiated.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the action was completed.
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// A unique identifier for the resource that the action is associated with.
        /// </summary>
        public int? ResourceId { get; set; }

        /// <summary>
        /// The type of resource that the action is associated with.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Embedded region object
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// A slug representing the region where the action occurred.
        /// </summary>
        public string RegionSlug { get; set; }
    }
}
