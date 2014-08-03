using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Size {
        /// <summary>
        /// A human-readable string that is used to uniquely identify each size.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The amount of RAM available to Droplets created with this size. This value is given in megabytes.
        /// </summary>
        public int Memory { get; set; }

        /// <summary>
        /// The number of virtual CPUs that are allocated to Droplets with this size.
        /// </summary>
        public int Vcpus { get; set; }

        /// <summary>
        /// This is the amount of disk space set aside for Droplets created with this size. The value is given in gigabytes.
        /// </summary>
        public int Disk { get; set; }

        /// <summary>
        /// The amount of transfer bandwidth that is available for Droplets created in this size. This only counts traffic on the
        /// public interface. The value is given in terabytes
        /// </summary>
        public double Transfer { get; set; }

        /// <summary>
        /// This attribute describes the monthly cost of this Droplet size if the Droplet is kept for an entire month. The value is
        /// measured in US dollars.
        /// </summary>
        public double PriceMontly { get; set; }

        /// <summary>
        /// This describes the price of the Droplet size as measured hourly. The value is measured in US dollars.
        /// </summary>
        public double PriceHourly { get; set; }

        /// <summary>
        /// An array that contains the region slugs where this size is available for Droplet creates.
        /// </summary>
        public List<string> Regions { get; set; }
    }
}