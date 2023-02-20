using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using DigitalOcean.Clients.Clients;
using DigitalOcean.Clients.Exceptions;
using DigitalOcean.Clients.Models.Responses;
using Microsoft.Extensions.Logging;

namespace DigitalOcean.Clients.Http;

public class Connection : IConnection {
    private readonly ILogger<Connection> _logger;

    private static readonly JsonSerializerOptions _serializerOptions = new() {
        PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
    };

    public Connection(HttpClient client, ILogger<Connection> logger) {
        _logger = logger;
        Client = client;
    }

    public HttpClient Client { get; }
    public IRateLimit Rates { get; private set; }
    public async Task<JsonDocument> ExecuteRaw(string endpoint, Dictionary<string, string>? parameters, object? data = null, HttpMethod? method = null, CancellationToken token = default) {
        var response = await Client.SendAsync(new HttpRequestMessage {
            Content = JsonContent.Create(data),
            Method = method ?? HttpMethod.Get,
            RequestUri = new Uri($"{Client.BaseAddress}{endpoint}")
        }, token);
        if (response.IsSuccessStatusCode) {
            if (response.StatusCode == HttpStatusCode.NoContent) {
                return JsonDocument.Parse("{}");
            }
            var responseStream = await response.Content.ReadAsStreamAsync(token);
            var jsonDocument = await JsonDocument.ParseAsync(responseStream, cancellationToken: token);
            if (_logger.IsEnabled(LogLevel.Debug)) {
                _logger.LogDebug("Successfully hit {Url} and received {Json}", response.RequestMessage?.RequestUri, jsonDocument.RootElement);
            }
            return jsonDocument;
        }

        var bodyContent = await response.Content.ReadAsStringAsync(token);
        var errorResponse = JsonSerializer.Deserialize<Error>(bodyContent, _serializerOptions);
        throw new ApiException(response.StatusCode, errorResponse ?? new Error(){Message = bodyContent});
    }

    public async Task<T> ExecuteRequest<T>(string endpoint, Dictionary<string, string>? parameters, object? data = null, string? expectedRoot = null, HttpMethod? method = null, CancellationToken token = default) where T : new() {
        using var response = await ExecuteRaw(endpoint, parameters, data: data, token: token, method: method);
        var deserializedData = default(T);
        if (string.IsNullOrWhiteSpace(expectedRoot)) {
            deserializedData = response.RootElement.Deserialize<T>(_serializerOptions);
        }
        else if( response.RootElement.TryGetProperty(expectedRoot, out var rootData)) {
            deserializedData = rootData.Deserialize<T>(_serializerOptions);
        }
        return deserializedData ?? throw new ApiException(statusCode: HttpStatusCode.OK, new Error() {
                Message = response.RootElement.ToString()
            });
    }

    public async Task<IEnumerable<T>> GetPaginated<T>(string endpoint, Dictionary<string, string>? parameters, string? expectedRoot = null, CancellationToken token = default) where T : new() {
        using var response = await ExecuteRaw(endpoint, parameters, token: token);
        var dataList = new List<T?>();
        var page = response.RootElement.Deserialize<PaginatedResponse>(_serializerOptions) ?? new PaginatedResponse();
        if (page.Data.TryGetValue(expectedRoot ?? string.Empty, out var rootData)) {
            dataList.AddRange(rootData.EnumerateArray().Select(data => data.Deserialize<T>(_serializerOptions)));
            return dataList.Where(d => d is not null).Select(d => (T)d!);
        }
        return Enumerable.Empty<T>();
    }
}
