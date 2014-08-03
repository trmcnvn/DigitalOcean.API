namespace DigitalOcean.API.Models.Responses {
    public class Interface {
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Type { get; set; }
    }

    public class Network {
        public Interface v4 { get; set; }
        public Interface v6 { get; set; }
    }
}