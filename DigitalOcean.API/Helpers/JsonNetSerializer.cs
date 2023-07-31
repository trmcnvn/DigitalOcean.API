using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace DigitalOcean.API.Helpers {
    internal class JsonNetSerializer : ISerializer {
        private readonly JsonSerializer _serializer;

        public JsonNetSerializer() {
            ContentType = ContentType.Json;
            _serializer = new JsonSerializer {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        #region ISerializer Members

        public string Serialize(object obj) {
            using (var stringWriter = new StringWriter()) {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter)) {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';
                    _serializer.Serialize(jsonTextWriter, obj);
                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public ContentType ContentType { get; set; }

        #endregion
    }
}
