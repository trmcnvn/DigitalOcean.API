using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public class ActionsClient : IActionsClient {
        private readonly IConnection _connection;

        public ActionsClient(IConnection connection) {
            _connection = connection;
        }

        #region IActionsClient Members

        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        public async Task<IReadOnlyList<Action>> GetAll() {
            var enumerable = await _connection.GetPaginated<Action>("actions", null, "actions");
            return enumerable.ToList();
        }

        /// <summary>
        /// Retrieve an existing Action
        /// </summary>
        public Task<Action> Get(long actionId) {
            return _connection.ExecuteRequest<Action>($"actions/{actionId}", null, null, "action");
        }

        #endregion
    }
}
