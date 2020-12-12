using System;
using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Name = {Name}")]
    public class ContainerRegistry {
        /// <summary>
        /// The name of the container registry to validate.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the registry was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The amount of storage used in the registry.
        /// </summary>
        public int StorageUsageBytes { get; set; }

        /// <summary>
        /// The time at which the storage usage was updated. Storage usage is calculated asynchronously, and may not immediately reflect pushes to the registry.
        /// </summary>
        public string StorageUsageBytesUpdatedAt { get; set; }
    }
}
