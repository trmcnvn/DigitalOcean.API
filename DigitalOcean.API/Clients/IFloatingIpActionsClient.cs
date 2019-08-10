using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IFloatingIpActionsClient {
        /// <summary>
        /// Assign a Floating IP to a Droplet
        /// </summary>
        Task<Action> Assign(string ipAddress, int dropletId);

        /// <summary>
        /// Unassign a Floating IP
        /// </summary>
        Task<Action> Unassign(string ipAddress);

        /// <summary>
        /// Retrieve all actions that have been executed on a Floating IP
        /// </summary>
        Task<IReadOnlyList<Action>> GetActions(string ipAddress);

        /// <summary>
        /// Retreive the status of a Floating IP action
        /// </summary>
        Task<Action> GetAction(string ipAddress, int actionId);
    }
}
