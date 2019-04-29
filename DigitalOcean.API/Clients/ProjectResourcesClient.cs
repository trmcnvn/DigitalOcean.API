using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class ProjectResourcesClient : IProjectResourcesClient {
        private readonly IConnection _connection;

        public ProjectResourcesClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// List all your resources in a project.
        /// </summary>
        public Task<IReadOnlyList<ProjectResource>> GetResources(string projectId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "project_id", Value = projectId, Type = ParameterType.UrlSegment }
            };
            return _connection.GetPaginated<ProjectResource>("projects/{project_id}/resources", parameters, "resources");
        }

        /// <summary>
        /// List all your resources in the default project.
        /// </summary>
        public Task<IReadOnlyList<ProjectResource>> GetDefaultResources() {
            return _connection.GetPaginated<ProjectResource>("projects/default/resources", null, "resources");
        }

        /// <summary>
        /// To assign resources to a project.
        /// </summary>
        public Task<IReadOnlyList<ProjectResource>> AssignResources(string projectId, IEnumerable<string> uniformResourceNames) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "project_id", Value = projectId, Type = ParameterType.UrlSegment }
            };
            var data = new {
                resources = uniformResourceNames
            };
            return _connection.ExecuteRequest<List<ProjectResource>>("projects/{project_id}/resources", parameters, data, "resources", Method.POST)
                .ToReadOnlyListAsync();
        }

        /// <summary>
        /// To assign resources to the default project.
        /// </summary>
        public Task<IReadOnlyList<ProjectResource>> AssignDefaultResources(IEnumerable<string> uniformResourceNames) {
            var data = new {
                resources = uniformResourceNames
            };
            return _connection.ExecuteRequest<List<ProjectResource>>("projects/default/resources", null, data, "resources", Method.POST)
                .ToReadOnlyListAsync();
        }
    }
}
