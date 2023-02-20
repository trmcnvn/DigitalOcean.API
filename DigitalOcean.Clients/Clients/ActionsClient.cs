namespace DigitalOcean.Clients.Clients;

public class ActionsClient : IActionsClient {
    private readonly IConnection _connection;

    public ActionsClient(IConnection connection) {
        _connection = connection;
    }

    #region IActionsClient Members

    /// <summary>
    /// Retrieve all actions that have been executed on the current account.
    /// </summary>
    public async Task<IEnumerable<DigitalOcean.Clients.Models.Responses.Action>> GetAll() {
        var enumerable = await _connection.GetPaginated<DigitalOcean.Clients.Models.Responses.Action>("actions", null, "actions");
        return enumerable.ToList();
    }

    /// <summary>
    /// Retrieve an existing Action
    /// </summary>
    public Task<DigitalOcean.Clients.Models.Responses.Action> Get(long actionId) {
        return _connection.ExecuteRequest<DigitalOcean.Clients.Models.Responses.Action>($"actions/{actionId}", null, null, "action");
    }

    #endregion
}
