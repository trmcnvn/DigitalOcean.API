using System.Net.Http.Headers;

namespace DigitalOcean.Clients.Http; 

public class RateLimit : IRateLimit {
    public RateLimit(HttpHeaders headers) {
        Limit = GetHeaderValue(headers, "Ratelimit-Limit");
        Remaining = GetHeaderValue(headers, "Ratelimit-Remaining");
        Reset = GetHeaderValue(headers, "Ratelimit-Reset");
    }

    #region IRateLimit Members

    /// <summary>
    /// The number of requests that can be made per hour.
    /// </summary>
    public int Limit { get; private set; }

    /// <summary>
    /// The number of requests that remain before you hit your request limit.
    /// </summary>
    public int Remaining { get; private set; }

    /// <summary>
    /// This represents the time when the oldest request will expire. The value is given in Unix epoch time.
    /// </summary>
    public int Reset { get; private set; }

    #endregion

    private static int GetHeaderValue(HttpHeaders headers, string name) {
        var header = headers.FirstOrDefault(x => x.Key == name);
        return int.TryParse(header.Value.ToString(), out var value) ? value : 0;
    }
}