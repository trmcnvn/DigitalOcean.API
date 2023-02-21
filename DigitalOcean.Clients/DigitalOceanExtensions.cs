using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using Microsoft.Extensions.Hosting;

namespace DigitalOcean.Clients;

public static class DigitalOceanExtensions {

}

public record DigitalOceanApiOptions {

    private CancellationTokenSource _stoppingTokenSource = new();
    public bool IsEnabled { get; set; }

    [Required]
    public string? ApiKey { get; set; }

    public CancellationToken StoppingToken => _stoppingTokenSource.Token;
    public CancellationTokenSource SetStoppingToken(CancellationToken token) => _stoppingTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
}

public class ApplicationLifeTimeHandler : DelegatingHandler {
    private CancellationTokenSource _stoppingToken = new();
    private readonly ILogger<ApplicationLifeTimeHandler> _logger;
    private AuthenticationHeaderValue? _authenticationHeaderValue;

    public ApplicationLifeTimeHandler(IOptionsMonitor<DigitalOceanApiOptions> optionsMonitor, ILogger<ApplicationLifeTimeHandler> logger) {
        _logger = logger;
        optionsMonitor.OnChange(opt => {
            _stoppingToken.Cancel();
            _stoppingToken.Dispose();
            _stoppingToken = CancellationTokenSource.CreateLinkedTokenSource(opt.StoppingToken);
            var newApiKey = new AuthenticationHeaderValue("Bearer", opt.ApiKey);
            _logger.LogDebug("Changing header from {Previous} to {Next}", _authenticationHeaderValue, newApiKey);
            _authenticationHeaderValue = newApiKey;
        });
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        _logger.LogTrace("Starting request");
        request.Headers.Authorization = _authenticationHeaderValue;
        _logger.LogTrace("Finished request");
        return await base.SendAsync(request, _stoppingToken.Token);

    }
}
