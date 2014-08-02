using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IActionsClient {
        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        Task<IReadOnlyList<Action>> GetAll();

        /// <summary>
        /// Retrieve an existing action
        /// </summary>
        Task<Action> Get(int actionId);
    }
}