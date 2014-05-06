using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class DropletInfo {
        public int id { get; set; }
        public string name { get; set; }
        public int image_id { get; set; }
        public int size_id { get; set; }
        public int region_id { get; set; }
        public bool backups_active { get; set; }
        public IList<object> backups { get; set; }
        public IList<object> snapshots { get; set; } 
        public string ip_address { get; set; }
        public string private_ip_address { get; set; }
        public bool locked { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
    }

    public class Droplets {
        public string status { get; set; }
        public List<DropletInfo> droplets { get; set; }
    }

    public class Droplet {
        public string status { get; set; }
        public DropletInfo droplet { get; set; }
    }

    public class NewDropletInfo {
        public int id { get; set; }
        public string name { get; set; }
        public int image_id { get; set; }
        public int size_id { get; set; }
        public int event_id { get; set; }
    }

    public class NewDroplet {
        public string status { get; set; }
        public NewDropletInfo droplet { get; set; }
    }
}