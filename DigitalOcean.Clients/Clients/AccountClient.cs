using System.Net.Http.Json;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class AccountClient : IAccountClient {
    private readonly IConnection _connection;
    private readonly ILogger<AccountClient> _logger;

    public AccountClient(IConnection connection, ILogger<AccountClient> logger) {
        _connection = connection;
        _logger = logger;
    }

    /// <summary>
    /// To show information about the current user's account.
    /// </summary>
    public async Task<Account> GetAsync(CancellationToken token = default)
    {
        var accountInfo = await _connection.ExecuteRequest<Account>("account", expectedRoot: "account",token: token);
        _logger.LogDebug("{Account}", accountInfo);
        return accountInfo;
    }
}
