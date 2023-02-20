using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Interfaces;

public interface IAccountClient {
    /// <summary>
    /// To show information about the current user's account.
    /// </summary>
    Task<Account> GetAsync(CancellationToken cancellationToken = default);
}
