using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Requests
{
    public class UpdateGarbageCollection
    {
        /// <summary>
        /// A boolean value indicating that the garbage collection should be cancelled.
        /// </summary>
        [JsonProperty("cancel")]
        public bool Cancel { get; set; }
    }
}
