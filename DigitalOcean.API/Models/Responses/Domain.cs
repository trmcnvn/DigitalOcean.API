namespace DigitalOcean.API.Models.Responses {
    public class Domain {
        /// <summary>
        /// The name of the domain name itself. The string should be in the form of domain.TLD. For instance, example.com is a
        /// valid domain value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This value is the time to live for the records on this domain, in seconds. This defines the time frame that clients can
        /// cache queried information before a refresh should be requested.
        /// </summary>
        public int Ttl { get; set; }

        /// <summary>
        /// This attribute contains the complete contents of the zone file for the selected domain. Most individual domain records
        /// can be accessed through the /v2/domains/$DOMAIN_NAME/records endpoint. However, the SOA record for the domain is only
        /// available through the zone_file.
        /// </summary>
        public string ZoneFile { get; set; }
    }
}