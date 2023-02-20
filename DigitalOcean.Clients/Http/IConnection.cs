using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigitalOcean.API.Http {
    public interface IConnection {
        HttpClient Client { get; }
        IRateLimit Rates { get; }

        Task<JsonDocument> ExecuteRaw(string endpoint, Dictionary<string, string>? parameters = null, object? data = null, HttpMethod? method = null);

        Task<T> ExecuteRequest<T>(string endpoint, Dictionary<string, string>? parameters,
            object? data = null, string? expectedRoot = null, HttpMethod? method = null) where T : new();

        Task<IEnumerable<T>> GetPaginated<T>(string endpoint, Dictionary<string, string>? parameters,
            string? expectedRoot = null) where T : new();
    }
}
