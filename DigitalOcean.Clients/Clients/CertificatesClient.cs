using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class CertificatesClient : ICertificatesClient {
    private readonly IConnection _connection;

    public CertificatesClient(IConnection connection) {
        _connection = connection;
    }


    public async Task<IEnumerable<Certificate>> GetAllAsync(CancellationToken cancellationToken = default) {
        return await _connection.GetPaginated<Certificate>("certificates", null, "certificates", cancellationToken);
    }


    public Task<Certificate> GetAsync(string certificateId, CancellationToken cancellationToken = default) {
        return _connection.ExecuteRequest<Certificate>($"certificates/{certificateId}", null, null, "certificate", token: cancellationToken);

    }

    public async Task<Certificate> CreateAsync(Models.Requests.Certificate certificate, CancellationToken cancellationToken = default) {
        return await _connection.ExecuteRequest<Certificate>($"certificates", null, certificate, "certificate", HttpMethod.Post, cancellationToken);

    }

    public Task DeleteAsync(string certificateId, CancellationToken cancellationToken = default) {
        return _connection.ExecuteRaw($"certificates/{certificateId}", null, null, HttpMethod.Delete, cancellationToken);
    }
}
