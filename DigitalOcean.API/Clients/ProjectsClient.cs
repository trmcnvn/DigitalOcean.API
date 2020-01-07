using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class ProjectsClient : IProjectsClient {
        private readonly IConnection _connection;

        public ProjectsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To list all your projects.
        /// </summary>
        public Task<IReadOnlyList<Project>> GetAll() {
            return _connection.GetPaginated<Project>("projects", null, "projects");
        }

        /// <summary>
        /// To create a project.
        /// </summary>
        public Task<Project> Create(Models.Requests.Project project) {
            return _connection.ExecuteRequest<Project>("projects", null, project, "project", Method.POST);
        }

        /// <summary>
        /// To get a project.
        /// </summary>
        public Task<Project> Get(string projectId) {
            var parameters = new List<Parameter> {
                new Parameter("project_id", projectId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Project>("projects/{project_id}", parameters, null, "project");
        }

        /// <summary>
        /// To get the default project.
        /// </summary>
        public Task<Project> GetDefault() {
            return _connection.ExecuteRequest<Project>("projects/default", null, null, "project");
        }

        /// <summary>
        /// To update a project.
        /// </summary>
        public Task<Project> Update(string projectId, Models.Requests.UpdateProject updateProject) {
            var parameters = new List<Parameter> {
                new Parameter("project_id", projectId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Project>("projects/{project_id}", parameters, updateProject, "project", Method.PUT);
        }

        /// <summary>
        /// To update the default project.
        /// </summary>
        public Task<Project> UpdateDefault(Models.Requests.UpdateProject updateProject) {
            // implied to always be true
            updateProject.IsDefault = true;
            return _connection.ExecuteRequest<Project>("projects/default", null, updateProject, "project", Method.PUT);
        }

        /// <summary>
        /// To update only specific attributes of a project.
        /// </summary>
        public Task<Project> Patch(string projectId, Models.Requests.PatchProject patchProject) {
            var parameters = new List<Parameter> {
                new Parameter("project_id", projectId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Project>("projects/{project_id}", parameters, patchProject, "project", Method.PATCH);
        }

        /// <summary>
        /// To update only specific attributes of the default project.
        /// </summary>
        public Task<Project> PatchDefault(Models.Requests.PatchProject patchProject) {
            // implied to always be true
            patchProject.IsDefault = true;
            return _connection.ExecuteRequest<Project>("projects/default", null, patchProject, "project", Method.PATCH);
        }
    }
}

