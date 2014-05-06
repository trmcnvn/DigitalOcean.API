using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class RegionInfo {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Regions {
        public string status { get; set; }
        public IList<RegionInfo> regions { get; set; }
    }
}