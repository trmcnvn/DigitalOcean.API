using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Requests
{
    public class UpdateSubscriptionTier
    {
        /// <summary>
        /// The slug of the new tier for the subscription. Valid values can be retrieved using the options endpoint.
        /// </summary>
        [JsonProperty("tier_slug")]
        public string TierSlug { get; set; }
    }
}
