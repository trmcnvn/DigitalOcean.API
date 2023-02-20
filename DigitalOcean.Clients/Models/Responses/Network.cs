using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class InterfaceV4 {
    public string IpAddress { get; set; }
    public string Netmask { get; set; }
    public string Gateway { get; set; }
    public string Type { get; set; }
}

public class InterfaceV6 {
    public string IpAddress { get; set; }
    public int Netmask { get; set; }
    public string Gateway { get; set; }
    public string Type { get; set; }
}

public class Network {
    public List<InterfaceV4> V4 { get; set; }
    public List<InterfaceV6> V6 { get; set; }
}