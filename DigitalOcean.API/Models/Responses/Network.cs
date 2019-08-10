using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Interface {
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Type { get; set; }
    }

    public class Network {
        public List<Interface> V4 { get; set; }
        public List<Interface> V6 { get; set; }
    }
}
