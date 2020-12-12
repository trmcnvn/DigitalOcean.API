using Newtonsoft.Json;
using System.Diagnostics;

namespace DigitalOcean.API.Models.Responses {
    [DebuggerDisplay("Name = {Name}, RegistryName = {Registryname}, TagCount = {TagCount}")]
    public class ContainerRegistryRepository {
        /// <summary>
        /// A globally unique name for the container registry. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 63 characters.
        /// </summary>
        public string RegistryName { get; set; }

        /// <summary>
        /// The name of the repository.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest tag of the repository.
        /// </summary>
        public ContainerRegistryTag LatestTag { get; set; }

        /// <summary>
        /// The number of tags in the repository.
        /// </summary>
        public int TagCount { get; set; }
    }
}
