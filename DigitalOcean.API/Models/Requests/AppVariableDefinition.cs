using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppVariableDefinition {
        /// <summary>
        /// ^[_A-Za-z][_A-Za-z0-9]*$
        /// The variable name
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Enum: "UNSET" "RUN_TIME" "BUILD_TIME" "RUN_AND_BUILD_TIME"
        /// RUN_TIME: Made available only at run-time
        /// BUILD_TIME: Made available only at build-time
        /// RUN_AND_BUILD_TIME: Made available at both build and run-time
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Enum: "GENERAL" "SECRET"
        /// GENERAL: A plain-text environment variable
        /// SECRET: A secret encrypted environment variable
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The value. If the type is SECRET, the value will be encrypted on first submission. On following submissions, the encrypted value should be used.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
