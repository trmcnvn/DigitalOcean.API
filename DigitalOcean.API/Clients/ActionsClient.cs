using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Action = DigitalOcean.API.Models.Responses.Action;

namespace DigitalOcean.API.Clients {
    public class ActionsClient : Connection, IActionsClient {
        public ActionsClient(IRestClient client) : base(client) {}

        #region IActionsClient Members

        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        public Task<IReadOnlyList<Action>> GetAll() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve an existing Action
        /// </summary>
        public Task<Action> Get(int actionId) {
            throw new NotImplementedException();
        }

        #endregion
    }
}