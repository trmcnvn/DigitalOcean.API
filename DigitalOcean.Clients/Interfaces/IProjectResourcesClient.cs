using DigitalOcean.Clients.Models.Requests;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IProjectResourcesClient {
    /// <summary>
    /// List all your resources in a project.
    /// </summary>
    Task<IEnumerable<ProjectResource>> GetResources(string projectId);

    /// <summary>
    /// List all your resources in the default project.
    /// </summary>
    Task<IEnumerable<ProjectResource>> GetDefaultResources();

    /// <summary>
    /// To assign resources to a project.
    /// </summary>
    Task<IEnumerable<ProjectResource>> AssignResources(string projectId, AssignResourceNames resources);

    /// <summary>
    /// To assign resources to the default project.
    /// </summary>
    Task<IEnumerable<ProjectResource>> AssignDefaultResources(AssignResourceNames resources);
}
