namespace DigitalOcean.API.Models.Requests {
    public class UpdateVpc {
        /// <summary>
        /// The name of the VPC.
        /// Must be unique and contain alphanumeric characters, dashes, and periods only.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A free-form text field for describing the VPC's purpose.
        /// It may be a maximum of 255 characters.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
