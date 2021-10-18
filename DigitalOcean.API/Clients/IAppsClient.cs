using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IAppsClient {
        Task<IReadOnlyList<App>> ListAllApps();
        Task<App> RetrieveExistingApp(string appId);
        Task<IReadOnlyList<Deployment>> ListAppDeployments(string appId);
        Task<Deployment> RetrieveAppDeployment(string appId, string deploymentId);
        Task DeleteApp(string appId);

        Task<App> CreateNewApp(Specs specs);
        Task<Deployment> CreateNewDeployment(string appId, ForceBuildApp forceBuild);
        Task<Deployment> CancelDeployment(string appId, string deploymentId);
    }
}
