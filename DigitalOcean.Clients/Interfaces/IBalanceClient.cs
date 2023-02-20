using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IBalanceClient
    {
        /// <summary>
        /// Retrieve the balances on a customer's account.
        /// </summary>
        Task<Balance> Get();
    }
}
