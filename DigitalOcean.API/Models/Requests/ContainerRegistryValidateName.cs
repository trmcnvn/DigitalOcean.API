using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Models.Requests
{
    public class ContainerRegistryValidateName
    {
        /// <summary>
        /// A globally unique name for the container registry. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 63 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
