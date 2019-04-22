using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

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
        public Task<IReadOnlyList<Action>> GetAll() {
            return _connection.GetPaginated<Action>("actions", null, "actions");
        }

        /// <summary>
        /// Retrieve an existing Action
        /// </summary>
        public Task<Action> Get(int actionId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = actionId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Action>("actions/{id}", parameters, null, "action");
        }

        #endregion
    }
}
