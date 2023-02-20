using DigitalOcean.Clients.Models.Requests;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients.Imports;

public class AppsClient : IAppsClient {
    private readonly IConnection _connection;

    public AppsClient(IConnection connection) {
        _connection = connection;
    }

    #region IAppsClient Members

    public Task<IEnumerable<App>> ListAllApps() {
        return _connection.GetPaginated<App>("apps", null, "apps");
    }

    public Task<App> RetrieveExistingApp(string appId) {
        return _connection.ExecuteRequest<App>($"apps/{appId}", null, null, "app");
    }

    public Task<IEnumerable<Deployment>> ListAppDeployments(string appId) {
        return _connection.GetPaginated<Deployment>($"apps/{appId}/deployments", null, "deployments");
    }

    public Task<Deployment> RetrieveAppDeployment(string appId, string deploymentId) {
        return _connection.ExecuteRequest<Deployment>($"apps/{appId}/deployments/{deploymentId}", null, null,
            "deployment");
    }

    public Task DeleteApp(string appId) {
        return _connection.ExecuteRaw($"apps/{appId}", null, null, HttpMethod.Delete);
    }

    public Task<App> CreateNewApp(Specs specs) {
        return _connection.ExecuteRequest<App>("apps", null, specs, "app", HttpMethod.Post);
    }

    public Task<Deployment> CreateNewDeployment(string appId, ForceBuildApp forceBuild) {
        return _connection.ExecuteRequest<Deployment>($"apps/{appId}/deployments", null,
            forceBuild, "deployment", HttpMethod.Post);
    }

    public Task<Deployment> CancelDeployment(string appId, string deploymentId) {
        return _connection.ExecuteRequest<Deployment>($"apps/{appId}/deployments/{deploymentId}", null, null,
            "deployment", HttpMethod.Post);
    }

    #endregion
}
