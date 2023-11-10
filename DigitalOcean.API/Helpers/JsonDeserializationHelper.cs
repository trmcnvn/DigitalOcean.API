using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace DigitalOcean.API.Helpers {
    internal class JsonDeserializationHelper {

        public static JsonSerializerSettings DeserializerSettings { get; private set; } = new JsonSerializerSettings() {
            DateFormatString = "yyyy-MM-ddTHH:mm:ssZ",
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() }
        };

        public static JsonSerializer Deserializer { get; private set; } = JsonSerializer.Create(DeserializerSettings);

        public static T DeserializeWithRootElementName<T>(JObject parsedJson, string rootElement, JsonSerializer deserializer = null) {
            if (parsedJson == null) throw new ArgumentNullException(nameof(parsedJson));

            var desrializerObj = deserializer ?? Deserializer;
            if (rootElement == null)
                return parsedJson.ToObject<T>(desrializerObj);
            else if (!parsedJson.ContainsKey(rootElement))
                return (T)Activator.CreateInstance(typeof(T));

            return parsedJson[rootElement].ToObject<T>(desrializerObj);
        }
    }
}
