using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Requests
{
    public class ContainerRegistryConfigure
    {
        /// <summary>
        /// A globally unique name for the container registry. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 63 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The slug of the subscription tier to sign up for. Valid values can be retrieved using the options endpoint.
        /// </summary>
        [JsonProperty("subscription_tier_slug")]
        public string SubscriptionTierSlug { get; set; }
    }
}
