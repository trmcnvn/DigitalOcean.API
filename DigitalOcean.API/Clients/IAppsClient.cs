using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IAppsClient {
        Task<IReadOnlyList<App>> ListAllApps();
        Task<App> RetrieveAnExistingApp(string appId);
        Task<IReadOnlyList<Deployment>> ListAppDeployments(string appId);
        Task<Deployment> RetrieveAnAppDeployment(string appId, string deploymentId);
        Task DeleteAnApp(string appId);
    }
}
