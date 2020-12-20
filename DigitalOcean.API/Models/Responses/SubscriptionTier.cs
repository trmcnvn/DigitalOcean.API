using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Responses
{
    public class SubscriptionTier
    {
        /// <summary>
        /// The human-readable name of the tier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug used in the API to request the tier.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The number of repositories that can be created in a registry with the tier.
        /// </summary>
        public int IncludedRepositories { get; set; }

        /// <summary>
        /// The amount of storage, in bytes, included in the tier.
        /// </summary>
        public int IncludedStorageBytes { get; set; }

        /// <summary>
        /// A boolean value indicating whether the included storage for the tier can be exceeded. If true, any storage overage is billable.
        /// </summary>
        public bool AllowStorageOverage { get; set; }

        /// <summary>
        /// The amount of monthly transfer, in bytes, included in the tier. Unlimited transfer within DigitalOcean's network is included in all tiers.
        /// </summary>
        public int IncludedBandwidthBytes { get; set; }

        /// <summary>
        /// The monthly price of subscriptions using the tier in US cents.
        /// </summary>
        public int MonthlyPriceInCents { get; set; }

        /// <summary>
        /// A boolean value indicating whether an existing subscription can be updated to use this tier. Present only in tiers returned as part of the options endpoint.
        /// </summary>
        public bool Eligible { get; set; }

        /// <summary>
        /// When `eligibility` is false, a list of reasons why the tier is not available for selection. Valid values include: 'OverRepositoryLimit','OverStorageLimit'.
        /// </summary>
        public string[] EligibilityReasons { get; set; }
    }
}
