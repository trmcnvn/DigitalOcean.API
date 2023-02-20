using Action = DigitalOcean.Clients.Models.Responses.Action;

namespace DigitalOcean.Clients.Interfaces;

public interface IFloatingIpActionsClient {
    /// <summary>
    /// Assign a Floating IP to a Droplet
    /// </summary>
    Task<Action> Assign(string ipAddress, long dropletId);

    /// <summary>
    /// Unassign a Floating IP
    /// </summary>
    Task<Action> Unassign(string ipAddress);

    /// <summary>
    /// Retrieve all actions that have been executed on a Floating IP
    /// </summary>
    Task<IEnumerable<Action>> GetActions(string ipAddress);

    /// <summary>
    /// Retreive the status of a Floating IP action
    /// </summary>
    Task<Action> GetAction(string ipAddress, long actionId);
}
