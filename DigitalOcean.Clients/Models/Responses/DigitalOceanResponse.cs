using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses;

public class Pages {
    public string Next { get; set; }
    public string Last { get; set; }
}

public class PaginatedResponse<T> {
    public Pages Links { get; set; }
    public Meta Meta { get; set; }
    public required string DataPropertyName { get; set; }
    protected IReadOnlyCollection<T> Data { get; set; }
}

public class Meta
{
    public long Total { get; set; }
}
