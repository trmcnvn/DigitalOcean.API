﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
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
                new Parameter("project_id", projectId, ParameterType.UrlSegment)
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
        public Task<IReadOnlyList<ProjectResource>> AssignResources(string projectId, AssignResourceNames resources) {
            var parameters = new List<Parameter> {
                new Parameter("project_id", projectId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<List<ProjectResource>>("projects/{project_id}/resources", parameters, resources, "resources", Method.POST)
                .ToReadOnlyListAsync();
        }

        /// <summary>
        /// To assign resources to the default project.
        /// </summary>
        public Task<IReadOnlyList<ProjectResource>> AssignDefaultResources(AssignResourceNames resources) {
            return _connection.ExecuteRequest<List<ProjectResource>>("projects/default/resources", null, resources, "resources", Method.POST)
                .ToReadOnlyListAsync();
        }
    }
}
