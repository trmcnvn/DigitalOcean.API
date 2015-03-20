using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Image {
        /// <summary>
        /// A unique number that can be used to identify and reference a specific image.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The display name that has been given to an image. This is what is shown in the control panel and is generally a
        /// descriptive title for the image in question.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The kind of image, describing the duration of how long the image is stored. This is one of "snapshot", "temporary" or "backup".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// This attribute describes the base distribution used for this image.
        /// </summary>
        public string Distribution { get; set; }

        /// <summary>
        /// A uniquely identifying string that is associated with each of the DigitalOcean-provided public images. These can be
        /// used to reference a public image as an alternative to the numeric id.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// This is a boolean value that indicates whether the image in question is public or not. An image that is public is
        /// available to all accounts. A non-public image is only accessible from your account.
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// This attribute is an array of the regions that the image is available in. The regions are represented by their
        /// identifying slug values.
        /// </summary>
        public List<string> Regions { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the image was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Contains the value of the minimum size droplet required for that image.
        /// </summary>
        public int MinDiskSize { get; set; }
    }
}