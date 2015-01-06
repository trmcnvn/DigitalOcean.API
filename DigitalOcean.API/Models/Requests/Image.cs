using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public enum ImageType {
        All,
        Application,
        Distribution
    }

    public class Image {
        /// <summary>
        /// The new name that you would like to use for the image.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}