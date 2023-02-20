using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using DigitalOcean.Clients.Models.Responses;

namespace DigitalOcean.Clients.Clients;

public class AccountClient : IAccountClient {
    private readonly HttpClient _client;

    public AccountClient(IHttpClientFactory clientFactory) {
        _client = clientFactory.CreateClient("DigitalOcean");
    }

    /// <summary>
    /// To show information about the current user's account.
    /// </summary>
    public async Task<Account> GetAsync(CancellationToken token = default)
    {
        var response = await _client.GetAsync("account", token);
        response.EnsureSuccessStatusCode();
        var responseJson = await response.Content.ReadFromJsonAsync<JsonDocument>(cancellationToken: token) ?? throw new InvalidOperationException();
        var accountInfo = responseJson.RootElement.TryGetProperty("account", out var accountJson)
            ? accountJson.Deserialize<Account>(new JsonSerializerOptions() {
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
            })
            : throw new InvalidOperationException();

        return accountInfo ?? throw new InvalidOperationException();
    }
}

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var stringBuilder = new StringBuilder();
        name = name.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            return string.Empty;
        }

        stringBuilder.Append(char.ToLowerInvariant(name[0]));

        foreach (var c in name[1..])
        {
            if (char.IsUpper(c))
            {
                stringBuilder.Append('_');
            }


            if (c == ' ')
            {
                break;
            }

            stringBuilder.Append(char.ToLowerInvariant(c));
        }

        return stringBuilder.ToString();
    }
}
