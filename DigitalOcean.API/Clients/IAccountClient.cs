using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IAccountClient {
        /// <summary>
        /// To show information about the current user's account.
        /// </summary>
        Task<Account> Get();
    }
}
