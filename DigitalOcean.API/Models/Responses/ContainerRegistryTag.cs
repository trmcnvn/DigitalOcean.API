using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Tag = {Tag}, Repository = {Repository}, RegistryName = {RegistryName}")]
    public class ContainerRegistryTag {
        /// <summary>
        /// The name of the container registry.
        /// </summary>
        public string RegistryName { get; set; }

        /// <summary>
        /// The name of the repository.
        /// </summary>
        public string RepositoryName { get; set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// The digest of the manifest associated with the tag.
        /// </summary>
        public string ManifestDigest { get; set; }

        /// <summary>
        /// The compressed size of the tag in bytes.
        /// </summary>
        public int CompressedSizeBytes { get; set; }

        /// <summary>
        /// The uncompressed size of the tag in bytes (this size is calculated asynchronously so it may not be immediately available).
        /// </summary>
        public int SizeBytes { get; set; }

        /// <summary>
        /// The time the tag was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
