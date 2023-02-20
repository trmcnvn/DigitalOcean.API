namespace DigitalOcean.Clients.Models.Responses;

public record Interface {
    public string IpAddress { get; set; }
    public string Netmask { get; set; }
    public string Gateway { get; set; }
    public string Type { get; set; }
}

public record Network {
    public IEnumerable<Interface> V4 { get; set; } = Enumerable.Empty<Interface>();
    public IEnumerable<Interface> V6 { get; set; } = Enumerable.Empty<Interface>();
}
