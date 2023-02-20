namespace DigitalOcean.API.Models.Requests
{
    public class UpdateGarbageCollection
    {
        /// <summary>
        /// A boolean value indicating that the garbage collection should be cancelled.
        /// </summary>
        [JsonPropertyName("cancel")]
        public bool Cancel { get; set; }
    }
}
