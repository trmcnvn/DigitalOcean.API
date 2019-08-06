using System;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Project {
        /// <summary>
        /// The human-readable name for the project. The maximum length is 175 characters and the name must be unique.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the project. The maximum length is 255 characters.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The purpose of the project. The maximum length is 255 characters. For examples of valid purposes, see <see cref="Purposes"/>
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// The environment of the project's resources. List of valid environments, see <see cref="Enviroments"/>
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }

        /// <summary>
        /// The purpose attribute can have one of the following values.
        /// If specify another value for purpose, for example "your custom purpose",
        /// your purpose will be stored as Other: your custom purpose
        /// </summary>
        public static class Purposes {
            public const string Trying = "Just trying out DigitalOcean";
            public const string Educational = "Class project / Educational purposes";
            public const string Website = "Website or blog";
            public const string WebApp = "Web Application";
            public const string ServiceOrApi = "Service or API";
            public const string Mobile = "Mobile Application";
            public const string DataProcessing = "Machine learning / AI / Data processing";
            public const string IoT = "IoT";
            public const string Operational = "Operational / Developer tooling";
        }

        /// <summary>
        /// The environment attribute must have one of the following values.
        /// If another value is specified, a 400 Bad Request is returned.
        /// </summary>
        public static class Enviroments {
            public const string Development = "Development";
            public const string Staging = "Staging";
            public const string Production = "Production";
        }
    }
}
