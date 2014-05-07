using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class SizeInfo {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Sizes {
        public string status { get; set; }
        public List<SizeInfo> sizes { get; set; }
    }
}