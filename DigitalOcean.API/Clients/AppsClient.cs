using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

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

        public Task<App> RetrieveAnExistingApp(string appId) {
            var parameters = new List<Parameter> {
                new Parameter("appId", appId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<App>("apps/{appId}", parameters, null, "app");
        }

        public Task<IReadOnlyList<Deployment>> ListAppDeployments(string appId) {
            var parameters = new List<Parameter> {
                new Parameter("appId", appId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Deployment>("apps/{appId}/deployments", parameters, "deployments");
        }

        public Task<Deployment> RetrieveAnAppDeployment(string appId, string deploymentId) {
            var parameters = new List<Parameter> {
                new Parameter("appId", appId, ParameterType.UrlSegment),
                new Parameter("deploymentId", deploymentId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters,null, "deployment");
        }

        public Task DeleteAnApp(string appId) {
            var parameters = new List<Parameter> {
                new Parameter("appId", appId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("apps/{appId}", parameters, null, Method.DELETE);
        }

        #endregion
    }
}
