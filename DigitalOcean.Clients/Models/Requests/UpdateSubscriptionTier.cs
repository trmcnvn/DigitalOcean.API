namespace DigitalOcean.Clients.Models.Requests; 

public class UpdateSubscriptionTier
{
    /// <summary>
    /// The slug of the new tier for the subscription. Valid values can be retrieved using the options endpoint.
    /// </summary>
    [JsonPropertyName("tier_slug")]
    public string TierSlug { get; set; }
}