using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IBalanceClient
{
    /// <summary>
    /// Retrieve the balances on a customer's account.
    /// </summary>
    Task<Balance> GetAsync(CancellationToken cancellationToken = default);
}
