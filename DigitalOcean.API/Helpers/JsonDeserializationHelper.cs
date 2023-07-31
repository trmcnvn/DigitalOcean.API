using Newtonsoft.Json.Linq;
using RestSharp;

namespace DigitalOcean.API.Helpers {
    internal class JsonDeserializationHelper {

        public static T DeserializeWithRootElementName<T>(string json, string rootElement) {
            var parsedJson = JObject.Parse(json);
            if (rootElement == null || !parsedJson.ContainsKey(rootElement))
                return (T)parsedJson.ToObject(typeof(T));

            return (T)parsedJson[rootElement].ToObject(typeof(T));
        }
    }
}
