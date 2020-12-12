using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Responses {
    public class Subscription {
        /// <summary>
        /// The subscription tier.
        /// </summary>
        public SubscriptionTier Tier { get; set; }

        /// <summary>
        /// The time at which the subscription was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The time at which the subscription was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
