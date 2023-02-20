using System.Text.Json;

namespace DigitalOcean.Clients.Models.Responses;

public class Pages {
    public string Next { get; set; }
    public string Last { get; set; }
}

public class PageLinks {
    public Pages Pages { get; set; }
}
public class PaginatedResponse {
    public PageLinks Links { get; set; }
    public Meta Meta { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> Data { get; set; } = new();
}

public class Meta
{
    public long Total { get; set; }
}
