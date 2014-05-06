using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class ImageInfo {
        public int id { get; set; }
        public string name { get; set; }
        public string distribution { get; set; }
        public string slug { get; set; }
        public bool @public { get; set; }
    }

    public class Images {
        public string status { get; set; }
        public IList<ImageInfo> images { get; set; }
    }

    public class Image {
        public string status { get; set; }
        public ImageInfo image { get; set; }
    }
}