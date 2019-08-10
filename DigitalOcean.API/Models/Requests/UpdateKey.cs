using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateKey {
        /// <summary>
        /// The name to give the new SSH key in your account.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
