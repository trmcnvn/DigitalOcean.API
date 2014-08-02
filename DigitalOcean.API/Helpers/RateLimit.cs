using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace DigitalOcean.API.Extensions {
    internal class RateLimit {
        public int Limit { get; private set; }
        public int Remaining { get; private set; }

        public RateLimit(IList<Parameter> headers) {
            Limit = GetHeaderValue(headers, "RateLimit-Limit");
            Remaining = GetHeaderValue(headers, "RateLimit-Remaining");
        }

        private static int GetHeaderValue(IEnumerable<Parameter> headers, string name) {
            var header = headers.FirstOrDefault(x => x.Name == name);
            int value;
            return header != null && int.TryParse(header.Value.ToString(), out value) ? value : 0;
        }
    }
}