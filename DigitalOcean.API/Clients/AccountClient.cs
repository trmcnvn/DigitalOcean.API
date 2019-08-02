using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public class AccountClient : IAccountClient {
        private readonly IConnection _connection;

        public AccountClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// To show information about the current user's account.
        /// </summary>
        public Task<Account> Get() {
            return _connection.ExecuteRequest<Account>("/account", null, null, "account");
        }
    }
}
