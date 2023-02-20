namespace DigitalOcean.API.Models.Requests
{
    public class ContainerRegistryValidateName
    {
        /// <summary>
        /// A globally unique name for the container registry. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 63 characters.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
