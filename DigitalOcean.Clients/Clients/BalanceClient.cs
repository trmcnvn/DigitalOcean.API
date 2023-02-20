using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class BalanceClient : IBalanceClient {
    private readonly IConnection _connection;

    public BalanceClient(IConnection connection) {
        _connection = connection;
    }


    public Task<Balance> GetAsync(CancellationToken cancellationToken = default)
        => _connection.ExecuteRequest<Balance>("customers/my/balance", null, null, null, token: cancellationToken);

}
