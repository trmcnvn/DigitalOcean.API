namespace DigitalOcean.API.Models.Requests
{
    public class ContainerRegistryConfigure
    {
        /// <summary>
        /// A globally unique name for the container registry. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 63 characters.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The slug of the subscription tier to sign up for. Valid values can be retrieved using the options endpoint.
        /// </summary>
        [JsonPropertyName("subscription_tier_slug")]
        public string SubscriptionTierSlug { get; set; }
    }
}
