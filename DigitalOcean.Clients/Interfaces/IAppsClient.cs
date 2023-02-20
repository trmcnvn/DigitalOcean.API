using DigitalOcean.Clients.Models.Requests;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IAppsClient {
    Task<IEnumerable<App>> ListAllApps();
    Task<App> RetrieveExistingApp(string appId);
    Task<IEnumerable<Deployment>> ListAppDeployments(string appId);
    Task<Deployment> RetrieveAppDeployment(string appId, string deploymentId);
    Task DeleteApp(string appId);

    Task<App> CreateNewApp(Specs specs);
    Task<Deployment> CreateNewDeployment(string appId, ForceBuildApp forceBuild);
    Task<Deployment> CancelDeployment(string appId, string deploymentId);
}
