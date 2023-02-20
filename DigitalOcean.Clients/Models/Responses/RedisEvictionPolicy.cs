namespace DigitalOcean.API.Models.Responses;

public class RedisEvictionPolicy {
    /// <summary>
    /// A string specifying the desired eviction policy for the Redis cluster.
    /// </summary>
    [JsonPropertyName("eviction_policy")]
    public string EvictionPolicy { get; set; }
}
