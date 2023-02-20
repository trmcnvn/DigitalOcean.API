using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface ITagsClient {
    /// <summary>
    /// Retrieve all Tags in your account
    /// </summary>
    Task<IEnumerable<Tag>> GetAll();

    /// <summary>
    /// Retrieve an individual Tag by name
    /// </summary>
    Task<Tag> Get(string tagName);

    /// <summary>
    /// Create a new Tag
    /// </summary>
    Task<Tag> Create(string tagName);

    /// <summary>
    /// Tag existing resources of given resource id / type combination
    /// </summary>
    Task Tag(string tagName, Models.Requests.TagResources resources);

    /// <summary>
    /// Untag existing resources of given resource id / type combination
    /// </summary>
    Task Untag(string tagName, Models.Requests.TagResources resources);

    /// <summary>
    /// Delete an existing Tag
    /// </summary>
    Task Delete(string tagName);
}
