using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Responses {
    public class GarbageCollection {
        /// <summary>
        /// A string specifying the UUID of the garbage collection.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// The name of the container registry.
        /// </summary>
        public string RegistryName { get; set; }

        /// <summary>
        /// The current status of this garbage collection. Valid values include: 'requested','waiting for write JWTs to expire','scanning manifests',
        /// 'deleting unreferenced blobs''cancelling','failed','succeeded','cancelled'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The time the garbage collection was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The time the garbage collection was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// The number of blobs deleted as a result of this garbage collection.
        /// </summary>
        public int BlobsDeleted { get; set; }

        /// <summary>
        /// The number of bytes freed as a result of this garbage collection.
        /// </summary>
        public int FreedBytes { get; set; }
    }
}
