using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class ReservedIpsClient : IReservedIpsClient {
    private readonly IConnection _connection;

    public ReservedIpsClient(IConnection connection) {
        _connection = connection;
    }

    /// <summary>
    /// A Floating IP must be either assigned to a Droplet or reserved to a region
    /// </summary>
    public Task<ReservedIp> Create(DigitalOcean.Clients.Models.Requests.ReservedIp reservedIp) {
        return _connection.ExecuteRequest<ReservedIp>("reserved_ips", null, reservedIp, "floating_ip", HttpMethod.Post);
    }

    /// <summary>
    /// Delete a Floating IP
    /// </summary>
    public Task Delete(string ip) {
        return _connection.ExecuteRaw($"reserved_ips/{ip}", null, null, HttpMethod.Delete);
    }

    /// <summary>
    /// Retreive a individual Floating IP
    /// </summary>
    public Task<ReservedIp> Get(string ip) {
    return _connection.ExecuteRequest<ReservedIp>($"reserved_ips/{ip}", null, null, "floating_ip");
}

/// <summary>
/// Retreive all Floating IPs available on your account
/// </summary>
public Task<IEnumerable<ReservedIp>> GetAll() {
    return _connection.GetPaginated<ReservedIp>("reserved_ips", null, "reserved_ips");
}

}
