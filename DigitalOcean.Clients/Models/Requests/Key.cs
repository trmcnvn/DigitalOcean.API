namespace DigitalOcean.API.Models.Requests {
    public class Key {
        /// <summary>
        /// The name to give the new SSH key in your account.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A string containing the entire public key.
        /// </summary>
        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; }
    }
}
