using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using DigitalOcean.API.Models.Requests;
using RestSharp;
using AppSpec = DigitalOcean.API.Models.Requests.AppSpec;

namespace DigitalOcean.API.Clients {
    public class AppsClient : IAppsClient {
        private readonly IConnection _connection;

        public AppsClient(IConnection connection) {
            _connection = connection;
        }

        #region IAppsClient Members

        public Task<IReadOnlyList<App>> ListAllApps() {
            return _connection.GetPaginated<App>("apps", null, "apps");
        }

        public Task<App> RetrieveExistingApp(string appId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId)
            };
            return _connection.ExecuteRequest<App>("apps/{appId}", parameters, null, "app");
        }

        public Task<IReadOnlyList<Deployment>> ListAppDeployments(string appId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId)
            };
            return _connection.GetPaginated<Deployment>("apps/{appId}/deployments", parameters, "deployments");
        }

        public Task<Deployment> RetrieveAppDeployment(string appId, string deploymentId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId),
                new UrlSegmentParameter("deploymentId", deploymentId)
            };
            return _connection.ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters, null,
                "deployment");
        }

        public Task DeleteApp(string appId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId)
            };
            return _connection.ExecuteRaw("apps/{appId}", parameters, null, Method.Delete);
        }

        public Task<App> CreateNewApp(Specs specs) {
            return _connection.ExecuteRequest<App>("apps", null, specs, "app", Method.Post);
        }

        public Task<Deployment> CreateNewDeployment(string appId, ForceBuildApp forceBuild) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId)
            };

            return _connection.ExecuteRequest<Deployment>("apps/{appId}/deployments", parameters,
                forceBuild, "deployment", Method.Post);
        }

        public Task<Deployment> CancelDeployment(string appId, string deploymentId) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter("appId", appId),
                new UrlSegmentParameter("deploymentId", deploymentId)
            };
            return _connection.ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters, null,
                "deployment", Method.Post);
        }

        #endregion
    }
}
