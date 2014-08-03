using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Droplet {
        /// <summary>
        /// A unique identifier for each Droplet instance.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human-readable name set for the Droplet instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Memory of the Droplet in megabytes.
        /// </summary>
        public int Memory { get; set; }

        /// <summary>
        /// The number of virtual CPUs.
        /// </summary>
        public int Vcpus { get; set; }

        /// <summary>
        /// The size of the Droplet's disk in gigabytes.
        /// </summary>
        public int Disk { get; set; }

        /// <summary>
        /// The region that the Droplet instance is deployed in.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// The base image used to create the Droplet instance.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// The current kernel.
        /// </summary>
        public Kernel Kernel { get; set; }

        /// <summary>
        /// The size of the Droplet instance.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// A boolean value indicating whether the Droplet has been locked, preventing actions by users.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the Droplet was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// A status string indicating the state of the Droplet instance. This may be "new", "active", "off", or "archive".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The details of the network that are configured for the Droplet instance. This is an object that contains keys for IPv4
        /// and IPv6. The value of each of these is an array that contains objects describing an individual IP resource allocated
        /// to the Droplet. These will define attributes like the IP address, netmask, and gateway of the specific network
        /// depending on the type of network it is.
        /// </summary>
        public Network Networks { get; set; }

        /// <summary>
        /// An array of backup IDs of any backups that have been taken of the Droplet instance. Droplet backups are enabled at the
        /// time of the instance creation.
        /// </summary>
        public List<int> BackupIds { get; set; }

        /// <summary>
        /// An array of snapshot IDs of any snapshots created from the Droplet instance.
        /// </summary>
        public List<int> SnapshotIds { get; set; }

        /// <summary>
        /// An array of action IDs of any actions that have been taken on this Droplet.
        /// </summary>
        public List<int> ActionIds { get; set; }

        /// <summary>
        /// An array of features enabled on this Droplet.
        /// </summary>
        public List<string> Features { get; set; }
    }
}