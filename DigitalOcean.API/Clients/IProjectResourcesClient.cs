using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IProjectResourcesClient {
        /// <summary>
        /// List all your resources in a project.
        /// </summary>
        Task<IReadOnlyList<ProjectResource>> GetResources(string projectId);

        /// <summary>
        /// List all your resources in the default project.
        /// </summary>
        Task<IReadOnlyList<ProjectResource>> GetDefaultResources();

        /// <summary>
        /// To assign resources to a project.
        /// </summary>
        Task<IReadOnlyList<ProjectResource>> AssignResources(string projectId, IEnumerable<string> uniformResourceNames);

        /// <summary>
        /// To assign resources to the default project.
        /// </summary>
        Task<IReadOnlyList<ProjectResource>> AssignDefaultResources(IEnumerable<string> uniformResourceNames);
    }
}
