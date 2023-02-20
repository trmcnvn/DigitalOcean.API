namespace DigitalOcean.Clients.Models.Requests; 

public class RedisEvictionPolicy {
    /// <summary>
    /// A string specifying the desired eviction policy for the Redis cluster.
    /// Valid vaules are: noeviction, allkeys_lru, allkeys_random, volatile_lru, volatile_random, or volatile_ttl.
    /// </summary>
    [JsonPropertyName("eviction_policy")]
    public string EvictionPolicy { get; set; }
}