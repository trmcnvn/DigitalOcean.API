using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Interface {
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Type { get; set; }
    }

    public class Network {
        public List<Interface> v4 { get; set; }
        public List<Interface> v6 { get; set; }
    }
}