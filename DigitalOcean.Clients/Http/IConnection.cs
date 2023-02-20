using System.Text.Json;

namespace DigitalOcean.Clients.Http;

public interface IConnection {
    HttpClient Client { get; }
    IRateLimit Rates { get; }

    Task<JsonDocument> ExecuteRaw(string endpoint, Dictionary<string, string>? parameters = null, object? data = null, HttpMethod? method = null, CancellationToken token = default);

    Task<T> ExecuteRequest<T>(string endpoint, Dictionary<string, string>? parameters,
        object? data = null, string? expectedRoot = null, HttpMethod? method = null, CancellationToken token = default) where T : new();

    Task<IEnumerable<T>> GetPaginated<T>(string endpoint, Dictionary<string, string>? parameters,
        string? expectedRoot = null, CancellationToken token = default) where T : new();
}
