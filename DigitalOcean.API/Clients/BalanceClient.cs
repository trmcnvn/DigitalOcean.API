using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public class BalanceClient : IBalanceClient {
        private readonly IConnection _connection;

        public BalanceClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To retrieve the balances on a customer's account.
        /// </summary>
        public Task<Balance> Get() {
            return _connection.ExecuteRequest<Balance>("customers/my/balance", null, null, null);
        }
    }
}
