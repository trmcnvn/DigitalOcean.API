namespace DigitalOcean.API.Models.Responses;

public class Pages {
    public string Next { get; set; }
    public string Last { get; set; }
}

public class Pagination {
    public Pages Links { get; set; }
}
