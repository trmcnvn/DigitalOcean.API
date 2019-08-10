using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Size {
        /// <summary>
        /// A human-readable string that is used to uniquely identify each size.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The amount of transfer bandwidth that is available for Droplets created in this size. This only counts traffic on the
        /// public interface. The value is given in terabytes
        /// </summary>
        public double Transfer { get; set; }

        /// <summary>
        /// This attribute describes the monthly cost of this Droplet size if the Droplet is kept for an entire month. The value is
        /// measured in US dollars.
        /// </summary>
        public Decimal PriceMonthly { get; set; }

        /// <summary>
        /// This describes the price of the Droplet size as measured hourly. The value is measured in US dollars.
        /// </summary>
        public Decimal PriceHourly { get; set; }

        /// <summary>
        /// The amount of RAM allocated to Droplets created of this size. The value is represented in megabytes
        /// </summary>
        public int Memory { get; set; }

        /// <summary>
        /// The number of virtual CPUs allocated to Droplets of this size.
        /// </summary>
        public int Vcpus { get; set; }

        /// <summary>
        /// The amount of disk space set aside for Droplets of this size. The value is represented in gigabytes.
        /// </summary>
        public int Disk { get; set; }

        /// <summary>
        /// An array that contains the region slugs where this size is available for Droplet creates.
        /// </summary>
        public List<string> Regions { get; set; }

        /// <summary>
        /// This is a boolean value that represents whether new Droplets can be created with this size.
        /// </summary>
        public bool Available { get; set; }
    }
}
