using Action = DigitalOcean.Clients.Models.Responses.Action;

namespace DigitalOcean.Clients.Clients;

public class FloatingIpActionsClient : IFloatingIpActionsClient {
    private readonly IConnection _connection;

    public FloatingIpActionsClient(IConnection connection) {
        _connection = connection;
    }

    /// <summary>
    /// Assign a Floating IP to a Droplet
    /// </summary>
    public Task<Action> Assign(string ipAddress, long dropletId) {
        var body = new DigitalOcean.Clients.Models.Requests.FloatingIpAction {
            Type = "assign",
            DropletId = dropletId
        };
        return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions", null, body, "action", HttpMethod.Post);
    }

    /// <summary>
    /// Retreive the status of a Floating IP action
    /// </summary>
    public Task<Action> GetAction(string ipAddress, long actionId) {
        return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions/{actionId}", null, null, "action");
    }

    /// <summary>
    /// Retrieve all actions that have been executed on a Floating IP
    /// </summary>
    public Task<IEnumerable<Action>> GetActions(string ipAddress) {
        return _connection.GetPaginated<Action>("floating_ips/{ip}/actions", null, "actions");
    }

    /// <summary>
    /// Unassign a Floating IP
    /// </summary>
    public Task<Action> Unassign(string ipAddress) {
        var body = new DigitalOcean.Clients.Models.Requests.FloatingIpAction {
            Type = "unassign"
        };
        return _connection.ExecuteRequest<Action>("floating_ips/{ip}/actions", null, body, "action", HttpMethod.Post);
    }
}
