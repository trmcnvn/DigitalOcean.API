using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface ITagsClient {
        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        Task<IReadOnlyList<Tag>> GetAll();

        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        Task<Tag> Get(string tagName);

        /// <summary>
        /// Create a new Tag
        /// </summary>
        Task<Tag> Create(string tagName);

        /// <summary>
        /// Update the name of a Tag
        /// </summary>
        Task<Tag> Update(string tagName, string newTagName);

        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        Task Tag(string tagName, List<KeyValuePair<string, string>> resources);

        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        Task Untag(string tagName, List<KeyValuePair<string, string>> resources);

        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        Task Delete(string tagName);
    }
}
