using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalOcean.API.Exceptions;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Http {
    public class Connection : IConnection {
        public Connection(HttpClient client) {
            Client = client;
        }

        public HttpClient Client { get; }
        public IRateLimit Rates { get; private set; }
        public async Task<JsonDocument> ExecuteRaw(string endpoint, Dictionary<string, string>? parameters, object? data = null, HttpMethod? method = null) {
            var response = await Client.SendAsync(new HttpRequestMessage {
                Content = JsonContent.Create(data),
                Method = method ?? HttpMethod.Get,
                RequestUri = new Uri($"{Client.BaseAddress}/endpoint")
            });
            if (response.IsSuccessStatusCode) {
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonDocument.ParseAsync(responseStream);
            }

            var bodyContent = await response.Content.ReadAsStringAsync();
            var errorResponse = JsonSerializer.Deserialize<Error>(bodyContent);
            throw new ApiException(response.StatusCode, errorResponse ?? new Error(){Message = bodyContent});
        }

        public async Task<T> ExecuteRequest<T>(string endpoint, Dictionary<string, string>? parameters, object? data = null, string? expectedRoot = null, HttpMethod? method = null) where T : new() {
            var response = await ExecuteRaw(endpoint, parameters);
            var isPropertyAvailable = response.RootElement.TryGetProperty(expectedRoot ?? string.Empty, out var rootData);
            var deserializedData = rootData.Deserialize<T>();
            return isPropertyAvailable && deserializedData is not null
                ? deserializedData
                : throw new ApiException(statusCode: HttpStatusCode.OK, new Error() {
                    Message = rootData.ToString()
                });
        }

        public async Task<IEnumerable<T>> GetPaginated<T>(string endpoint, Dictionary<string, string>? parameters, string? expectedRoot = null) where T : new() {
            var response = await ExecuteRaw(endpoint, parameters);
            var dataList = new List<T?>();
            if (response.RootElement.TryGetProperty(expectedRoot ?? string.Empty, out var rootData)) {
                foreach (var data in rootData.EnumerateArray()) {
                    dataList.Add(data.Deserialize<T>());
                }

                return dataList.Where(d => d is not null).Select(d => (T)d!);
            }
            return Enumerable.Empty<T>();
        }
    }
}
