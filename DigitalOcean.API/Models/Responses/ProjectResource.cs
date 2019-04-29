using System;

namespace DigitalOcean.API.Models.Responses {
    public class ProjectResource {
        /// <summary>
        /// The uniform resource name of the resource.
        /// </summary>
        public string Urn { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the project was created.
        /// </summary>
        public DateTime AssignedAt { get; set; }

        /// <summary>
        /// The links object contains the self object, which contains the resource relationship.
        /// </summary>
        public SelfLink Links { get; set; }

        /// <summary>
        /// The status of assigning and fetching the resources.
        /// </summary>
        public string Status { get; set; }

        public class SelfLink {
            public string Self { get; set; }
        }
    }
}
