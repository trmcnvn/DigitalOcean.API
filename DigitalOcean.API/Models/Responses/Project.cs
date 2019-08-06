using System;

namespace DigitalOcean.API.Models.Responses {
    /// <summary>
    /// Projects allow you to organize your resources into groups that fit the way you work. You can group resources (like Droplets,
    /// Spaces, Load Balancers, domains, and Floating IPs) in ways that align with the applications you host on DigitalOcean.
    /// </summary>
    public class Project {
        /// <summary>
        /// The unique universal identifier of this project.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The unique universal identifier of the project owner.
        /// </summary>
        public string OwnerUuid { get; set; }

        /// <summary>
        /// The integer id of the project owner.
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// The human-readable name for the project. The maximum length is 175 characters and the name must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the project. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The purpose of the project. The maximum length is 255 characters.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// The environment of the project's resources.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// If true, all resources will be added to this project if no project is specified.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the project was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the project was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
