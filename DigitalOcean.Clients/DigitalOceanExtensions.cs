using System.Net.Http.Headers;
using DigitalOcean.Clients.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DigitalOcean.Clients;

public static class DigitalOceanExtensions {
    public static IServiceCollection AddAllClients(this IServiceCollection builder, string apiKey = "") {
        builder.AddTransient<ApplicationLifeTimeHandler>();
        builder.AddHttpClient<IConnection, Connection>("DigitalOcean")
            .ConfigureHttpClient(c => {
                c.BaseAddress = new Uri(DigitalOceanClient.DIGITAL_OCEAN_API_URL);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            })
            .AddHttpMessageHandler<ApplicationLifeTimeHandler>();

        builder.AddTransient<IAccountClient, AccountClient>();
        builder.AddTransient<IActionsClient, ActionsClient>();
        builder.AddTransient<IDomainsClient, DomainsClient>();
        builder.AddTransient<IBalanceClient, BalanceClient>();
        builder.AddTransient<IDropletsClient, DropletsClient>();
        builder.AddTransient<IDomainRecordsClient, DomainRecordsClient>();
        builder.AddTransient<IReservedIpsClient, ReservedIpsClient>();
        builder.AddTransient<IKeysClient, KeysClient>();
        builder.AddTransient<ICertificatesClient, CertificatesClient>();
        builder.AddTransient<IFloatingIpActionsClient, FloatingIpActionsClient>();
        return builder;
    }
}

public class ApplicationLifeTimeHandler : DelegatingHandler {
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public ApplicationLifeTimeHandler(IHostApplicationLifetime hostApplicationLifetime) {
        _hostApplicationLifetime = hostApplicationLifetime;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        return await base.SendAsync(request, _hostApplicationLifetime.ApplicationStopping);
    }
}
