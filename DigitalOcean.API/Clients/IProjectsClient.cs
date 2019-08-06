using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IProjectsClient {
        /// <summary>
        /// To list all your projects.
        /// </summary>
        Task<IReadOnlyList<Project>> GetAll();

        /// <summary>
        /// To create a project.
        /// </summary>
        Task<Project> Create(Models.Requests.Project project);

        /// <summary>
        /// To get a project.
        /// </summary>
        Task<Project> Get(string projectId);

        /// <summary>
        /// To get the default project.
        /// </summary>
        Task<Project> GetDefault();

        /// <summary>
        /// To update a project.
        /// </summary>
        Task<Project> Update(string projectId, Models.Requests.UpdateProject updateProject);

        /// <summary>
        /// To update the default project.
        /// </summary>
        Task<Project> UpdateDefault(Models.Requests.UpdateProject updateProject);

        /// <summary>
        /// To update only specific attributes of a project.
        /// </summary>
        Task<Project> Patch(string projectId, Models.Requests.PatchProject patchProject);

        /// <summary>
        /// To update only specific attributes of the default project.
        /// </summary>
        Task<Project> PatchDefault(Models.Requests.PatchProject patchProject);
    }
}
