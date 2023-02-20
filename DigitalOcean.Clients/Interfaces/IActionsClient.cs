namespace DigitalOcean.Clients.Interfaces;

public interface IActionsClient {
    /// <summary>
    /// Retrieve all actions that have been executed on the current account.
    /// </summary>
    Task<IEnumerable<DigitalOcean.Clients.Models.Responses.Action>> GetAll();

    /// <summary>
    /// Retrieve an existing action
    /// </summary>
    Task<DigitalOcean.Clients.Models.Responses.Action> Get(long actionId);
}
